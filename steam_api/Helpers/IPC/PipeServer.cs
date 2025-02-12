﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SKYNET.IPC
{
    /// <summary>
    /// Wraps a <see cref="NamedPipeServerStream"/> and provides multiple simultaneous client connection handling.
    /// </summary>
    /// <typeparam name="T">Reference type to read/write from the named pipe</typeparam>
    public sealed class PipeServer<T>
    {
        /// <summary>
        /// Name of pipe
        /// </summary>
        public string PipeName { get; }

        /// <summary>
        /// CreatePipeStreamFunc
        /// </summary>
        public Func<string, NamedPipeServerStream>? CreatePipeStreamFunc { get; set; }

        /// <summary>
        /// PipeStreamInitializeAction
        /// </summary>
        public Action<NamedPipeServerStream>? PipeStreamInitializeAction { get; set; }

        /// <summary>
        /// Indicates whether to wait for a name to be released when calling StartAsync()
        /// </summary>
        public bool WaitFreePipe { get; set; }

        /// <summary>
        /// All connections(include disconnected clients)
        /// </summary>
        private List<PipeConnection<T>> Connections { get; } = new List<PipeConnection<T>>();

        /// <summary>
        /// Connected clients
        /// </summary>
        public IReadOnlyCollection<PipeConnection<T>> ConnectedClients => Connections
            .Where(connection => connection.IsConnected)
            .ToList();

        /// <summary>
        /// IsStarted
        /// </summary>
        public bool IsStarted => ListenWorker != null && !ListenWorker.Task.IsCompleted && !ListenWorker.Task.IsCanceled && !ListenWorker.Task.IsFaulted;


        private TaskWorker? ListenWorker { get; set; }

        private volatile bool _isDisposed;

        /// <summary>
        /// Invoked whenever a client connects to the server.
        /// </summary>
        public event EventHandler<ConnectionEventArgs<T>>? ClientConnected;

        /// <summary>
        /// Invoked whenever a client disconnects from the server.
        /// </summary>
        public event EventHandler<ConnectionEventArgs<T>>? ClientDisconnected;

        /// <summary>
        /// Invoked whenever a client sends a message to the server.
        /// </summary>
        public event EventHandler<ConnectionMessageEventArgs<T>>? MessageReceived;

        /// <summary>
        /// Invoked whenever an exception is thrown during a read or write operation.
        /// </summary>
        public event EventHandler<ExceptionEventArgs>? ExceptionOccurred;

        private void OnClientConnected(ConnectionEventArgs<T> args)
        {
            ClientConnected?.Invoke(this, args);
        }

        private void OnClientDisconnected(ConnectionEventArgs<T> args)
        {
            ClientDisconnected?.Invoke(this, args);
        }

        private void OnMessageReceived(ConnectionMessageEventArgs<T> args)
        {
            MessageReceived?.Invoke(this, args);
        }

        private void OnExceptionOccurred()
        {
            ExceptionOccurred?.Invoke(this, new ExceptionEventArgs());
        }

        /// <summary>
        /// Constructs a new <c>NamedPipeServer</c> object that listens for client connections on the given <paramref name="pipeName"/>.
        /// </summary>
        /// <param name="pipeName">Name of the pipe to listen on</param>
        /// <param name="formatter">Default formatter - <see cref="BinaryFormatter"/></param>
        public PipeServer(string pipeName)
        {
            PipeName = pipeName;
        }

        /// <summary>
        /// Begins listening for client connections in a separate background thread.
        /// This method waits when pipe will be created(or throws exception).
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="IOException"></exception>
        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            if (IsStarted)
            {
                throw new InvalidOperationException("Server already started");
            }

            await StopAsync(cancellationToken).ConfigureAwait(false);

            var source = new TaskCompletionSource<bool>();
            using var registration = cancellationToken.Register(() => source.TrySetCanceled(cancellationToken));

            ListenWorker = new TaskWorker(async token =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        var connectionPipeName = $"{PipeName}_{Guid.NewGuid()}";

                        // Send the client the name of the data pipe to use
                        try
                        {
                            using var serverStream = CreatePipeStreamFunc?.Invoke(PipeName) ?? Create(PipeName);
                            {
                                PipeStreamInitializeAction?.Invoke(serverStream);

                                source.TrySetResult(true);

                                await serverStream.WaitForConnectionAsync(token).ConfigureAwait(false);

                                using var handshakeWrapper = new PipeStreamWrapper(serverStream);
                                {
                                    await handshakeWrapper.WriteAsync(Encoding.UTF8.GetBytes(connectionPipeName), token)
                                        .ConfigureAwait(false);
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            if (WaitFreePipe)
                            {
                                throw;
                            }

                            source.TrySetException(exception);
                            break;
                        }

                        // Wait for the client to connect to the data pipe
                        var connectionStream = CreatePipeStreamFunc?.Invoke(connectionPipeName) ?? Create(connectionPipeName);

                        PipeStreamInitializeAction?.Invoke(connectionStream);

                        try
                        {
                            await connectionStream.WaitForConnectionAsync(token).ConfigureAwait(false);
                        }
                        catch
                        {
                            connectionStream.Dispose();
                            throw;
                        }

                        // Add the client's connection to the list of connections
                        var connection = new PipeConnection<T>(connectionStream, connectionPipeName);
                        connection.MessageReceived += (_, args) => OnMessageReceived(args);
                        connection.Disconnected += (_, args) => OnClientDisconnected(args);
                        connection.ExceptionOccurred += (_, args) => OnExceptionOccurred();
                        connection.Start();

                        Connections.Add(connection);

                        OnClientConnected(new ConnectionEventArgs<T>(connection));
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    // Catch the IOException that is raised if the pipe is broken or disconnected.
                    catch (IOException)
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(1), token).ConfigureAwait(false);
                    }
                    catch (Exception exception)
                    {
                        OnExceptionOccurred();
                        break;
                    }
                }
            });

            try
            {
                await source.Task.ConfigureAwait(false);
            }
            catch (Exception)
            {
                await StopAsync(cancellationToken).ConfigureAwait(false);

                throw;
            }
        }

        /// <summary>
        /// Sends a message to all connected clients asynchronously.
        /// This method returns immediately, possibly before the message has been sent to all clients.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cancellationToken"></param>
        public async Task WriteAsync(T value, CancellationToken cancellationToken = default)
        {
            await WriteAsync(value, predicate: null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a message to all connected clients asynchronously.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        public async Task WriteAsync(T value, Predicate<PipeConnection<T>>? predicate, CancellationToken cancellationToken = default)
        {
            var tasks = Connections
                .Where(connection => connection.IsConnected && (predicate == null || predicate(connection)))
                .Select(connection => connection.WriteAsync(value, cancellationToken))
                .ToList();

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a message to the given client by pipe name.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pipeName"></param>
        /// <param name="cancellationToken"></param>
        public async Task WriteAsync(T value, string pipeName, CancellationToken cancellationToken = default)
        {
            await WriteAsync(value, connection => connection.PipeName == pipeName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Closes all open client connections and stops listening for new ones.
        /// </summary>
        public async Task StopAsync(CancellationToken _ = default)
        {
            if (ListenWorker != null)
            {
                await ListenWorker.StopAsync().ConfigureAwait(false);

                ListenWorker = null;
            }

            var tasks = Connections
                .Select(connection => connection.StopAsync())
                .ToList();

            Connections.Clear();

            await Task.WhenAll(tasks).ConfigureAwait(false);
        }


        /// <summary>
        /// Dispose internal resources
        /// </summary>
        public async void DisposeAsync()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;

            await StopAsync().ConfigureAwait(false);
        }

        // Pipe Server Factory
        public static async Task<NamedPipeServerStream> CreateAndWaitAsync(string pipeName, CancellationToken cancellationToken = default)
        {
            var pipe = Create(pipeName);

            try
            {
                await pipe.WaitForConnectionAsync(cancellationToken).ConfigureAwait(false);

                return pipe;
            }
            catch
            {
                pipe.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Creates new <see cref="NamedPipeServerStream"/>
        /// </summary>
        /// <param name="pipeName"></param>
        /// <returns></returns>
        public static NamedPipeServerStream Create(string pipeName)
        {
            return new NamedPipeServerStream(
                pipeName: pipeName,
                direction: PipeDirection.InOut,
                maxNumberOfServerInstances: 1,
                transmissionMode: PipeTransmissionMode.Byte,
                options: PipeOptions.Asynchronous | PipeOptions.WriteThrough,
                inBufferSize: 0,
                outBufferSize: 0);
        }

    }
}
