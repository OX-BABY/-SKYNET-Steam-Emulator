﻿using SKYNET.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Interface
{
    public interface ISteamNetworkingSockets
    {
        /// Creates a "server" socket that listens for clients to connect to by 
        /// calling ConnectByIPAddress, over ordinary UDP (IPv4 or IPv6)
        ///
        /// You must select a specific local port to listen on and set it
        /// the port field of the local address.
        ///
        /// Usually you will set the IP portion of the address to zero (IntPtr::Clear()).
        /// This means that you will not bind to any particular local interface (i.e. the same
        /// as INADDR_ANY in plain socket code).  Furthermore, if possible the socket will be bound
        /// in "dual stack" mode, which means that it can accept both IPv4 and IPv6 client connections.
        /// If you really do wish to bind a particular interface, then set the local address to the
        /// appropriate IPv4 or IPv6 IP.
        ///
        /// If you need to set any initial config options, pass them here.  See
        /// IntPtr for more about why this is preferable to
        /// setting the options "immediately" after creation.
        ///
        /// When a client attempts to connect, a SteamNetConnectionStatusChangedCallback_t
        /// will be posted.  The connection will be in the connecting state.
        uint CreateListenSocketIP(IntPtr localAddress, int nOptions, IntPtr pOptions);

        /// Creates a connection and begins talking to a "server" over UDP at the
        /// given IPv4 or IPv6 address.  The remote host must be listening with a
        /// matching call to CreateListenSocketIP on the specified port.
        ///
        /// A SteamNetConnectionStatusChangedCallback_t callback will be triggered when we start
        /// connecting, and then another one on either timeout or successful connection.
        ///
        /// If the server does not have any identity configured, then their network address
        /// will be the only identity in use.  Or, the network host may provide a platform-specific
        /// identity with or without a valid certificate to authenticate that identity.  (These
        /// details will be contained in the SteamNetConnectionStatusChangedCallback_t.)  It's
        /// up to your application to decide whether to allow the connection.
        ///
        /// By default, all connections will get basic encryption sufficient to prevent
        /// casual eavesdropping.  But note that without certificates (or a shared secret
        /// distributed through some other out-of-band mechanism), you don't have any
        /// way of knowing who is actually on the other end, and thus are vulnerable to
        /// man-in-the-middle attacks.
        ///
        /// If you need to set any initial config options, pass them here.  See
        /// IntPtr for more about why this is preferable to
        /// setting the options "immediately" after creation.
        uint ConnectByIPAddress(IntPtr address, int nOptions, IntPtr pOptions);

        #region STEAMNETWORKINGSOCKETS_ENABLE_SDR
        /// Like CreateListenSocketIP, but clients will connect using ConnectP2P
        ///
        /// nVirtualPort specifies how clients can connect to this socket using
        /// ConnectP2P.  It's very common for applications to only have one listening socket;
        /// in that case, use zero.  If you need to open multiple listen sockets and have clients
        /// be able to connect to one or the other, then nVirtualPort should be a small integer (<1000)
        /// unique to each listen socket you create.
        ///
        /// If you use this, you probably want to call ISteamNetworkingUtils::InitRelayNetworkAccess()
        /// when your app initializes
        ///
        /// If you need to set any initial config options, pass them here.  See
        /// IntPtr for more about why this is preferable to
        /// setting the options "immediately" after creation.
        uint CreateListenSocketP2P(int nVirtualPort, int nOptions, IntPtr pOptions);

        /// Begin connecting to a server that is identified using a platform-specific identifier.
        /// This uses the default rendezvous service, which depends on the platform and library
        /// configuration.  (E.g. on Steam, it goes through the steam backend.)  The traffic is relayed
        /// over the Steam Datagram Relay network.
        ///
        /// If you use this, you probably want to call ISteamNetworkingUtils::InitRelayNetworkAccess()
        /// when your app initializes
        ///
        /// If you need to set any initial config options, pass them here.  See
        /// IntPtr for more about why this is preferable to
        /// setting the options "immediately" after creation.
        uint ConnectP2P(IntPtr identityRemote, int nVirtualPort, int nOptions, IntPtr pOptions);
        #endregion

        /// Accept an incoming connection that has been received on a listen socket.
        ///
        /// When a connection attempt is received (perhaps after a few basic handshake
        /// packets have been exchanged to prevent trivial spoofing), a connection interface
        /// object is created in the k_ESteamNetworkingConnectionState_Connecting state
        /// and a SteamNetConnectionStatusChangedCallback_t is posted.  At this point, your
        /// application MUST either accept or close the connection.  (It may not ignore it.)
        /// Accepting the connection will transition it either into the connected state,
        /// or the finding route state, depending on the connection type.
        ///
        /// You should take action within a second or two, because accepting the connection is
        /// what actually sends the reply notifying the client that they are connected.  If you
        /// delay taking action, from the client's perspective it is the same as the network
        /// being unresponsive, and the client may timeout the connection attempt.  In other
        /// words, the client cannot distinguish between a delay caused by network problems
        /// and a delay caused by the application.
        ///
        /// This means that if your application goes for more than a few seconds without
        /// processing callbacks (for example, while loading a map), then there is a chance
        /// that a client may attempt to connect in that interval and fail due to timeout.
        ///
        /// If the application does not respond to the connection attempt in a timely manner,
        /// and we stop receiving communication from the client, the connection attempt will
        /// be timed out locally, transitioning the connection to the
        /// k_ESteamNetworkingConnectionState_ProblemDetectedLocally state.  The client may also
        /// close the connection before it is accepted, and a transition to the
        /// k_ESteamNetworkingConnectionState_ClosedByPeer is also possible depending the exact
        /// sequence of events.
        ///
        /// Returns k_EResultInvalidParam if the handle is invalid.
        /// Returns k_EResultInvalidState if the connection is not in the appropriate state.
        /// (Remember that the connection state could change in between the time that the
        /// notification being posted to the queue and when it is received by the application.)
        ///
        /// A note about connection configuration options.  If you need to set any configuration
        /// options that are common to all connections accepted through a particular listen
        /// socket, consider setting the options on the listen socket, since such options are
        /// inherited automatically.  If you really do need to set options that are connection
        /// specific, it is safe to set them on the connection before accepting the connection.
        EResult AcceptConnection(uint hConn);

        /// Disconnects from the remote host and invalidates the connection handle.
        /// Any unread data on the connection is discarded.
        ///
        /// nReason is an application defined code that will be received on the other
        /// end and recorded (when possible) in backend analytics.  The value should
        /// come from a restricted range.  (See ESteamNetConnectionEnd.)  If you don't need
        /// to communicate any information to the remote host, and do not want analytics to
        /// be able to distinguish "normal" connection terminations from "exceptional" ones,
        /// You may pass zero, in which case the generic value of
        /// k_ESteamNetConnectionEnd_App_Generic will be used.
        ///
        /// pszDebug is an optional human-readable diagnostic string that will be received
        /// by the remote host and recorded (when possible) in backend analytics.
        ///
        /// If you wish to put the socket into a "linger" state, where an attempt is made to
        /// flush any remaining sent data, use bEnableLinger=true.  Otherwise reliable data
        /// is not flushed.
        ///
        /// If the connection has already ended and you are just freeing up the
        /// connection interface, the reason code, debug string, and linger flag are
        /// ignored.
        bool CloseConnection(uint hPeer, int nReason, char pszDebug, bool bEnableLinger);

        /// Destroy a listen socket.  All the connections that were accepting on the listen
        /// socket are closed ungracefully.
        bool CloseListenSocket(uint hSocket);

        /// Set connection user data.  the data is returned in the following places
        /// - You can query it using GetConnectionUserData.
        /// - The SteamNetworkingmessage_t structure.
        /// - The IntPtr structure.  (Which is a member of SteamNetConnectionStatusChangedCallback_t.)
        ///
        /// Returns false if the handle is invalid.
        bool SetConnectionUserData(uint hPeer, uint nUserData);

        /// Fetch connection user data.  Returns -1 if handle is invalid
        /// or if you haven't set any userdata on the connection.
        uint GetConnectionUserData(uint hPeer);

        /// Set a name for the connection, used mostly for debugging
        void SetConnectionName(uint hPeer, char pszName);

        /// Fetch connection name.  Returns false if handle is invalid
        bool GetConnectionName(uint hPeer, char pszName, int nMaxLen);

        /// Send a message to the remote host on the specified connection.
        ///
        /// nSendFlags determines the delivery guarantees that will be provided,
        /// when data should be buffered, etc.  E.g. k_nSteamNetworkingSend_Unreliable
        ///
        /// Note that the semantics we use for messages are not precisely
        /// the same as the semantics of a standard "stream" socket.
        /// (SOCK_STREAM)  For an ordinary stream socket, the boundaries
        /// between chunks are not considered relevant, and the sizes of
        /// the chunks of data written will not necessarily match up to
        /// the sizes of the chunks that are returned by the reads on
        /// the other end.  The remote host might read a partial chunk,
        /// or chunks might be coalesced.  For the message semantics 
        /// used here, however, the sizes WILL match.  Each send call 
        /// will match a successful read call on the remote host 
        /// one-for-one.  If you are porting existing stream-oriented 
        /// code to the semantics of reliable messages, your code should 
        /// work the same, since reliable message semantics are more 
        /// strict than stream semantics.  The only caveat is related to 
        /// performance: there is per-message overhead to retain the 
        /// message sizes, and so if your code sends many small chunks 
        /// of data, performance will suffer. Any code based on stream 
        /// sockets that does not write excessively small chunks will 
        /// work without any changes. 
        ///
        /// The pOutMessageNumber is an optional pointer to receive the
        /// message number assigned to the message, if sending was successful.
        ///
        /// Returns:
        /// - k_EResultInvalidParam: invalid connection handle, or the individual message is too big.
        ///   (See k_cbMaxSteamNetworkingSocketsMessageSizeSend)
        /// - k_EResultInvalidState: connection is in an invalid state
        /// - k_EResultNoConnection: connection has ended
        /// - k_EResultIgnored: You used k_nSteamNetworkingSend_NoDelay, and the message was dropped because
        ///   we were not ready to send it.
        /// - k_EResultLimitExceeded: there was already too much data queued to be sent.
        ///   (See k_ESteamNetworkingConfig_SendBufferSize)
        EResult SendMessageToConnection(uint hConn, IntPtr pData, uint cbData, int nSendFlags, uint pOutMessageNumber);

        /// Send one or more messages without copying the message payload.
        /// This is the most efficient way to send messages. To use this
        /// function, you must first allocate a message object using
        /// ISteamNetworkingUtils::AllocateMessage.  (Do not declare one
        /// on the stack or allocate your own.)
        ///
        /// You should fill in the message payload.  You can either let
        /// it allocate the buffer for you and then fill in the payload,
        /// or if you already have a buffer allocated, you can just point
        /// m_pData at your buffer and set the callback to the appropriate function
        /// to free it.  Note that if you use your own buffer, it MUST remain valid
        /// until the callback is executed.  And also note that your callback can be
        /// invoked at ant time from any thread (perhaps even before SendMessages
        /// returns!), so it MUST be fast and threadsafe.
        ///
        /// You MUST also fill in:
        /// - m_conn - the handle of the connection to send the message to
        /// - m_nFlags - bitmask of k_nSteamNetworkingSend_xxx flags.
        ///
        /// All other fields are currently reserved and should not be modified.
        ///
        /// The library will take ownership of the message structures.  They may
        /// be modified or become invalid at any time, so you must not read them
        /// after passing them to this function.
        ///
        /// pOutMessageNumberOrResult is an optional array that will receive,
        /// for each message, the message number that was assigned to the message
        /// if sending was successful.  If sending failed, then a negative EResult
        /// value is placed into the array.  For example, the array will hold
        /// -k_EResultInvalidState if the connection was in an invalid state.
        /// See ISteamNetworkingSockets::SendMessageToConnection for possible
        /// failure codes.
        void SendMessages(int nMessages, IntPtr pMessages, uint pOutMessageNumberOrResult);

        /// Flush any messages waiting on the Nagle timer and send them
        /// at the next transmission opportunity (often that means right now).
        ///
        /// If Nagle is enabled (it's on by default) then when calling 
        /// SendMessageToConnection the message will be buffered, up to the Nagle time
        /// before being sent, to merge small messages into the same packet.
        /// (See k_ESteamNetworkingConfig_NagleTime)
        ///
        /// Returns:
        /// k_EResultInvalidParam: invalid connection handle
        /// k_EResultInvalidState: connection is in an invalid state
        /// k_EResultNoConnection: connection has ended
        /// k_EResultIgnored: We weren't (yet) connected, so this operation has no effect.
        EResult FlushMessagesOnConnection(uint hConn);

        /// Fetch the next available message(s) from the connection, if any.
        /// Returns the number of messages returned into your array, up to nMaxMessages.
        /// If the connection handle is invalid, -1 is returned.
        ///
        /// The order of the messages returned in the array is relevant.
        /// Reliable messages will be received in the order they were sent (and with the
        /// same sizes --- see SendMessageToConnection for on this subtle difference from a stream socket).
        ///
        /// Unreliable messages may be dropped, or delivered out of order with respect to
        /// each other or with respect to reliable messages.  The same unreliable message
        /// may be received multiple times.
        ///
        /// If any messages are returned, you MUST call IntPtr::Release() on each
        /// of them free up resources after you are done.  It is safe to keep the object alive for
        /// a little while (put it into some queue, etc), and you may call Release() from any thread.
        int ReceiveMessagesOnConnection(uint hConn, IntPtr ppOutMessages, int nMaxMessages);

        /// Returns basic information about the high-level state of the connection.
        bool GetConnectionInfo(uint hConn, IntPtr pInfo);

        /// Returns a small set of information about the real-time state of the connection
        /// Returns false if the connection handle is invalid, or the connection has ended.
        bool GetQuickConnectionStatus(uint hConn, IntPtr pStats);

        /// Returns detailed connection stats in text format.  Useful
        /// for dumping to a log, etc.
        ///
        /// Returns:
        /// -1 failure (bad connection handle)
        /// 0 OK, your buffer was filled in and '\0'-terminated
        /// >0 Your buffer was either nullptr, or it was too small and the text got truncated.
        ///    Try again with a buffer of at least N bytes.
        int GetDetailedConnectionStatus(uint hConn, char pszBuf, int cbBuf);

        /// Returns local IP and port that a listen socket created using CreateListenSocketIP is bound to.
        ///
        /// An IPv6 address of ::0 means "any IPv4 or IPv6"
        /// An IPv6 address of ::ffff:0000:0000 means "any IPv4"
        bool GetListenSocketAddress(uint hSocket, IntPtr address);

        /// Create a pair of connections that are talking to each other, e.g. a loopback connection.
        /// This is very useful for testing, or so that your client/server code can work the same
        /// even when you are running a local "server".
        ///
        /// The two connections will immediately be placed into the connected state, and no callbacks
        /// will be posted immediately.  After this, if you close either connection, the other connection
        /// will receive a callback, exactly as if they were communicating over the network.  You must
        /// close both sides in order to fully clean up the resources!
        ///
        /// By default, internal buffers are used, completely bypassing the network, the chopping up of
        /// messages into packets, encryption, copying the payload, etc.  This means that loopback
        /// packets, by default, will not simulate lag or loss.  Passing true for bUseNetworkLoopback will
        /// cause the socket pair to send packets through the local network loopback device (127.0.0.1)
        /// on ephemeral ports.  Fake lag and loss are supported in this case, and CPU time is expended
        /// to encrypt and decrypt.
        ///
        /// If you wish to assign a specific identity to either connection, you may pass a particular
        /// identity.  Otherwise, if you pass nullptr, the respective connection will assume a generic
        /// "localhost" identity.  If you use real network loopback, this might be translated to the
        /// actual bound loopback port.  Otherwise, the port will be zero.
        bool CreateSocketPair(uint pOutConnection1, uint pOutConnection2, bool bUseNetworkLoopback, IntPtr pIdentity1, IntPtr pIdentity2);

        /// Get the identity assigned to this interface.
        /// E.g. on Steam, this is the user's SteamID, or for the gameserver interface, the SteamID assigned
        /// to the gameserver.  Returns false and sets the result to an invalid identity if we don't know
        /// our identity yet.  (E.g. GameServer has not logged in.  On Steam, the user will know their SteamID
        /// even if they are not signed into Steam.)
        bool GetIdentity(IntPtr pIdentity);

        /// Indicate our desire to be ready participate in authenticated communications.
        /// If we are currently not ready, then steps will be taken to obtain the necessary
        /// certificates.   (This includes a certificate for us, as well as any CA certificates
        /// needed to authenticate peers.)
        ///
        /// You can call this at program init time if you know that you are going to
        /// be making authenticated connections, so that we will be ready immediately when
        /// those connections are attempted.  (Note that essentially all connections require
        /// authentication, with the exception of ordinary UDP connections with authentication
        /// disabled using k_ESteamNetworkingConfig_IP_AllowWithoutAuth.)  If you don't call
        /// this function, we will wait until a feature is utilized that that necessitates
        /// these resources.
        ///
        /// You can also call this function to force a retry, if failure has occurred.
        /// Once we make an attempt and fail, we will not automatically retry.
        /// In this respect, the behavior of the system after trying and failing is the same
        /// as before the first attempt: attempting authenticated communication or calling
        /// this function will call the system to attempt to acquire the necessary resources.
        ///
        /// You can use GetAuthenticationStatus or listen for IntPtr
        /// to monitor the status.
        ///
        /// Returns the current value that would be returned from GetAuthenticationStatus.
        ESteamNetworkingAvailability InitAuthentication();

        /// Query our readiness to participate in authenticated communications.  A
        /// IntPtr callback is posted any time this status changes,
        /// but you can use this function to query it at any time.
        ///
        /// The value of IntPtr::m_eAvail is returned.  If you only
        /// want this high level status, you can pass NULL for pDetails.  If you want further
        /// details, pass non-NULL to receive them.
        ESteamNetworkingAvailability GetAuthenticationStatus(IntPtr pDetails);

        //
        // Poll groups.  A poll group is a set of connections that can be polled efficiently.
        // (In our API, to "poll" a connection means to retrieve all pending messages.  We
        // actually don't have an API to "poll" the connection state, like BSD sockets.)
        //

        /// Create a new poll group.
        ///
        /// You should destroy the poll group when you are done using DestroyPollGroup
        uint CreatePollGroup();

        /// Destroy a poll group created with CreatePollGroup().
        ///
        /// If there are any connections in the poll group, they are removed from the group,
        /// and left in a state where they are not part of any poll group.
        /// Returns false if passed an invalid poll group handle.
        bool DestroyPollGroup(uint hPollGroup);

        /// Assign a connection to a poll group.  Note that a connection may only belong to a
        /// single poll group.  Adding a connection to a poll group implicitly removes it from
        /// any other poll group it is in.
        ///
        /// You can pass k_uint_Invalid to remove a connection from its current
        /// poll group without adding it to a new poll group.
        ///
        /// If there are received messages currently pending on the connection, an attempt
        /// is made to add them to the queue of messages for the poll group in approximately
        /// the order that would have applied if the connection was already part of the poll
        /// group at the time that the messages were received.
        ///
        /// Returns false if the connection handle is invalid, or if the poll group handle
        /// is invalid (and not k_uint_Invalid).
        bool SetConnectionPollGroup(uint hConn, uint hPollGroup);

        /// Same as ReceiveMessagesOnConnection, but will return the next messages available
        /// on any connection in the poll group.  Examine IntPtr::m_conn
        /// to know which connection.  (IntPtr::m_nConnUserData might also
        /// be useful.)
        ///
        /// Delivery order of messages among different connections will usually match the
        /// order that the last packet was received which completed the message.  But this
        /// is not a strong guarantee, especially for packets received right as a connection
        /// is being assigned to poll group.
        ///
        /// Delivery order of messages on the same connection is well defined and the
        /// same guarantees are present as mentioned in ReceiveMessagesOnConnection.
        /// (But the messages are not grouped by connection, so they will not necessarily
        /// appear consecutively in the list; they may be interleaved with messages for
        /// other connections.)
        int ReceiveMessagesOnPollGroup(uint hPollGroup, IntPtr ppOutMessages, int nMaxMessages);

        #region STEAMNETWORKINGSOCKETS_ENABLE_SDR

        //
        // Clients connecting to dedicated servers hosted in a data center,
        // using central-authority-granted tickets.
        //

        /// Call this when you receive a ticket from your backend / matchmaking system.  Puts the
        /// ticket into a persistent cache, and optionally returns the parsed ticket.
        ///
        /// See stamdatagram_ticketgen.h for more details.
        bool ReceivedRelayAuthTicket(IntPtr pvTicket, int cbTicket, SteamDatagramRelayAuthTicket pOutParsedTicket);

        /// Search cache for a ticket to talk to the server on the specified port.
        /// If found, returns the number of seconds until the ticket expires, and optionally
        /// the complete cracked ticket.  Returns 0 if we don't have a ticket.
        ///
        /// Typically this is useful just to confirm that you have a ticket, before you
        /// call ConnectToHostedDedicatedServer to connect to the server.
        int FindRelayAuthTicketForServer(IntPtr identityGameServer, int nVirtualPort, SteamDatagramRelayAuthTicket pOutParsedTicket);

        /// Client call to connect to a server hosted in a Valve data center, on the specified virtual
        /// port.  You must have placed a ticket for this server into the cache, or else this connect attempt will fail!
        ///
        /// You may wonder why tickets are stored in a cache, instead of simply being passed as an argument
        /// here.  The reason is to make reconnection to a gameserver robust, even if the client computer loses
        /// connection to Steam or the central backend, or the app is restarted or crashes, etc.
        ///
        /// If you use this, you probably want to call ISteamNetworkingUtils::InitRelayNetworkAccess()
        /// when your app initializes
        ///
        /// If you need to set any initial config options, pass them here.  See
        /// IntPtr for more about why this is preferable to
        /// setting the options "immediately" after creation.
        uint ConnectToHostedDedicatedServer(IntPtr identityTarget, int nVirtualPort, int nOptions, IntPtr pOptions);

        //
        // Servers hosted in data centers known to the Valve relay network
        //

        /// Returns the value of the SDR_LISTEN_PORT environment variable.  This
        /// is the UDP server your server will be listening on.  This will
        /// configured automatically for you in production environments.
        ///
        /// In development, you'll need to set it yourself.  See
        /// https://partner.steamgames.com/doc/api/ISteamNetworkingSockets
        /// for more information on how to configure dev environments.
        uint GetHostedDedicatedServerPort();

        /// Returns 0 if SDR_LISTEN_PORT is not set.  Otherwise, returns the data center the server
        /// is running in.  This will be k_SteamDatagramPOPID_dev in non-production environment.
        uint GetHostedDedicatedServerPOPID();

        /// Return info about the hosted server.  This contains the PoPID of the server,
        /// and opaque routing information that can be used by the relays to send traffic
        /// to your server.
        ///
        /// You will need to send this information to your backend, and put it in tickets,
        /// so that the relays will know how to forward traffic from
        /// clients to your server.  See SteamDatagramRelayAuthTicket for more info.
        ///
        /// Also, note that the routing information is contained in SteamDatagramGameCoordinatorServerLogin,
        /// so if possible, it's preferred to use GetGameCoordinatorServerLogin to send this info
        /// to your game coordinator service, and also login securely at the same time.
        ///
        /// On a successful exit, k_EResultOK is returned
        ///
        /// Unsuccessful exit:
        /// - Something other than k_EResultOK is returned.
        /// - k_EResultInvalidState: We are not configured to listen for SDR (SDR_LISTEN_SOCKET
        ///   is not set.)
        /// - k_EResultPending: we do not (yet) have the authentication information needed.
        ///   (See GetAuthenticationStatus.)  If you use environment variables to pre-fetch
        ///   the network config, this data should always be available immediately.
        /// - A non-localized diagnostic debug message will be placed in m_data that describes
        ///   the cause of the failure.
        ///
        /// NOTE: The returned blob is not encrypted.  Send it to your backend, but don't
        ///       directly share it with clients.
        EResult GetHostedDedicatedServerAddress(SteamDatagramHostedAddress pRouting);

        /// Create a listen socket on the specified port.  The physical UDP port to use
        /// will be determined by the SDR_LISTEN_PORT environment variable.  If a UDP port is not
        /// configured, this call will fail.
        ///
        /// Note that this call MUST be made through the SteamGameServerNetworkingSockets() interface
        ///
        /// If you need to set any initial config options, pass them here.  See
        /// IntPtr for more about why this is preferable to
        /// setting the options "immediately" after creation.
        uint CreateHostedDedicatedServerListenSocket(int nVirtualPort, int nOptions, IntPtr pOptions);

        /// Generate an authentication blob that can be used to securely login with
        /// your backend, using SteamDatagram_ParseHostedServerLogin.  (See
        /// steamdatagram_gamecoordinator.h)
        ///
        /// Before calling the function:
        /// - Populate the app data in pLoginInfo (m_cbAppData and m_appData).  You can leave
        ///   all other fields uninitialized.
        /// - pcbSignedBlob contains the size of the buffer at pBlob.  (It should be
        ///   at least k_cbMaxSteamDatagramGameCoordinatorServerLoginSerialized.)
        ///
        /// On a successful exit:
        /// - k_EResultOK is returned
        /// - All of the remaining fields of pLoginInfo will be filled out.
        /// - pcbSignedBlob contains the size of the serialized blob that has been
        ///   placed into pBlob.
        ///
        /// Unsuccessful exit:
        /// - Something other than k_EResultOK is returned.
        /// - k_EResultNotLoggedOn: you are not logged in (yet)
        /// - See GetHostedDedicatedServerAddress for more potential failure return values.
        /// - A non-localized diagnostic debug message will be placed in pBlob that describes
        ///   the cause of the failure.
        ///
        /// This works by signing the contents of the SteamDatagramGameCoordinatorServerLogin
        /// with the cert that is issued to this server.  In dev environments, it's OK if you do
        /// not have a cert.  (You will need to enable insecure dev login in SteamDatagram_ParseHostedServerLogin.)
        /// Otherwise, you will need a signed cert.
        ///
        /// NOTE: The routing blob returned here is not encrypted.  Send it to your backend
        ///       and don't share it directly with clients.
        EResult GetGameCoordinatorServerLogin(SteamDatagramGameCoordinatorServerLogin pLoginInfo, int pcbSignedBlob, IntPtr pBlob);


        //
        // Relayed connections using custom signaling protocol
        //
        // This is used if you have your own method of sending out-of-band
        // signaling / rendezvous messages through a mutually trusted channel.
        //

        /// Create a P2P "client" connection that does signaling over a custom
        /// rendezvous/signaling channel.
        ///
        /// pSignaling points to a new object that you create just for this connection.
        /// It must stay valid until Release() is called.  Once you pass the
        /// object to this function, it assumes ownership.  Release() will be called
        /// from within the function call if the call fails.  Furthermore, until Release()
        /// is called, you should be prepared for methods to be invoked on your
        /// object from any thread!  You need to make sure your object is threadsafe!
        /// Furthermore, you should make sure that dispatching the methods is done
        /// as quickly as possible.
        ///
        /// This function will immediately construct a connection in the "connecting"
        /// state.  Soon after (perhaps before this function returns, perhaps in another thread),
        /// the connection will begin sending signaling messages by calling
        /// ISteamNetworkingConnectionCustomSignaling::SendSignal.
        ///
        /// When the remote peer accepts the connection (See
        /// IntPtr::OnConnectRequest),
        /// it will begin sending signaling messages.  When these messages are received,
        /// you can pass them to the connection using ReceivedP2PCustomSignal.
        ///
        /// If you know the identity of the peer that you expect to be on the other end,
        /// you can pass their identity to improve debug output or just detect bugs.
        /// If you don't know their identity yet, you can pass NULL, and their
        /// identity will be established in the connection handshake.  
        ///
        /// If you use this, you probably want to call ISteamNetworkingUtils::InitRelayNetworkAccess()
        /// when your app initializes
        ///
        /// If you need to set any initial config options, pass them here.  See
        /// IntPtr for more about why this is preferable to
        /// setting the options "immediately" after creation.
        uint ConnectP2PCustomSignaling(IntPtr pSignaling, IntPtr pPeerIdentity, int nOptions, IntPtr pOptions);

        /// Called when custom signaling has received a message.  When your
        /// signaling channel receives a message, it should save off whatever
        /// routing information was in the envelope into the context object,
        /// and then pass the payload to this function.
        ///
        /// A few different things can happen next, depending on the message:
        ///
        /// - If the signal is associated with existing connection, it is dealt
        ///   with immediately.  If any replies need to be sent, they will be
        ///   dispatched using the ISteamNetworkingConnectionCustomSignaling
        ///   associated with the connection.
        /// - If the message represents a connection request (and the request
        ///   is not redundant for an existing connection), a new connection
        ///   will be created, and ReceivedConnectRequest will be called on your
        ///   context object to determine how to proceed.
        /// - Otherwise, the message is for a connection that does not
        ///   exist (anymore).  In this case, we may call SendRejectionReply
        ///   on your context object.
        ///
        /// In any case, we will not save off pContext or access it after this
        /// function returns.
        ///
        /// Returns true if the message was parsed and dispatched without anything
        /// unusual or suspicious happening.  Returns false if there was some problem
        /// with the message that prevented ordinary handling.  (Debug output will
        /// usually have more information.)
        ///
        /// If you expect to be using relayed connections, then you probably want
        /// to call ISteamNetworkingUtils::InitRelayNetworkAccess() when your app initializes
        bool ReceivedP2PCustomSignal(IntPtr pMsg, int cbMsg, IntPtr pContext);
        #endregion // #ifndef STEAMNETWORKINGSOCKETS_ENABLE_SDR

        //
        // Certificate provision by the application.  On Steam, we normally handle all this automatically
        // and you will not need to use these advanced functions.
        //

        /// Get blob that describes a certificate request.  You can send this to your game coordinator.
        /// Upon entry, pcbBlob should contain the size of the buffer.  On successful exit, it will
        /// return the number of bytes that were populated.  You can pass pBlob=NULL to query for the required
        /// size.  (256 bytes is a very conservative estimate.)
        ///
        /// Pass this blob to your game coordinator and call SteamDatagram_CreateCert.
        bool GetCertificateRequest(int pcbBlob, IntPtr pBlob, string errMsg);

        /// Set the certificate.  The certificate blob should be the output of
        /// SteamDatagram_CreateCert.
        bool SetCertificate(IntPtr pCertificate, int cbCertificate, string errMsg);

        // Invoke all callbacks queued for this interface.
        // On Steam, callbacks are dispatched via the ordinary Steamworks callbacks mechanism.
        // So if you have code that is also targeting Steam, you should call this at about the
        // same time you would call SteamAPI_RunCallbacks and SteamGameServer_RunCallbacks.
        #region STEAMNETWORKINGSOCKETS_STANDALONELIB
        void RunCallbacks(IntPtr pCallbacks);
        #endregion

        /// This callback is posted whenever a connection is created, destroyed, or changes state.
        /// The m_info field will contain a complete description of the connection at the time the
        /// change occurred and the callback was posted.  In particular, m_eState will have the
        /// new connection state.
        ///
        /// You will usually need to listen for this callback to know when:
        /// - A new connection arrives on a listen socket.
        ///   m_info.m_hListenSocket will be set, m_eOldState = k_ESteamNetworkingConnectionState_None,
        ///   and m_info.m_eState = k_ESteamNetworkingConnectionState_Connecting.
        ///   See ISteamNetworkigSockets::AcceptConnection.
        /// - A connection you initiated has been accepted by the remote host.
        ///   m_eOldState = k_ESteamNetworkingConnectionState_Connecting, and
        ///   m_info.m_eState = k_ESteamNetworkingConnectionState_Connected.
        ///   Some connections might transition to k_ESteamNetworkingConnectionState_FindingRoute first.
        /// - A connection has been actively rejected or closed by the remote host.
        ///   m_eOldState = k_ESteamNetworkingConnectionState_Connecting or k_ESteamNetworkingConnectionState_Connected,
        ///   and m_info.m_eState = k_ESteamNetworkingConnectionState_ClosedByPeer.  m_info.m_eEndReason
        ///   and m_info.m_szEndDebug will have for more details.
        ///   NOTE: upon receiving this callback, you must still destroy the connection using
        ///   ISteamNetworkingSockets::CloseConnection to free up local resources.  (The details
        ///   passed to the function are not used in this case, since the connection is already closed.)
        /// - A problem was detected with the connection, and it has been closed by the local host.
        ///   The most common failure is timeout, but other configuration or authentication failures
        ///   can cause this.  m_eOldState = k_ESteamNetworkingConnectionState_Connecting or
        ///   k_ESteamNetworkingConnectionState_Connected, and m_info.m_eState = k_ESteamNetworkingConnectionState_ProblemDetectedLocally.
        ///   m_info.m_eEndReason and m_info.m_szEndDebug will have for more details.
        ///   NOTE: upon receiving this callback, you must still destroy the connection using
        ///   ISteamNetworkingSockets::CloseConnection to free up local resources.  (The details
        ///   passed to the function are not used in this case, since the connection is already closed.)
        ///
        /// Remember that callbacks are posted to a queue, and networking connections can
        /// change at any time.  It is possible that the connection has already changed
        /// state by the time you process this callback.
        ///
        /// Also note that callbacks will be posted when connections are created and destroyed by your own API calls.

    }
    /// Different methods of describing the identity of a network host
    public enum EIntPtrType
    {
        // Dummy/empty/invalid.
        // Plese note that if we parse a string that we don't recognize
        // but that appears reasonable, we will NOT use this type.  Instead
        // we'll use k_EIntPtrType_UnknownType.
        k_EIntPtrType_Invalid = 0,

        //
        // Basic platform-specific identifiers.
        //
        k_EIntPtrType_SteamID = 16, // 64-bit CSteamID

        //
        // Special identifiers.
        //

        // Use their IP address (and port) as their "identity".
        // These types of identities are always unauthenticated.
        // They are useful for porting plain sockets code, and other
        // situations where you don't care about authentication.  In this
        // case, the local identity will be "localhost",
        // and the remote address will be their network address.
        //
        // We use the same type for either IPv4 or IPv6, and
        // the address is always store as IPv6.  We use IPv4
        // mapped addresses to handle IPv4.
        k_EIntPtrType_IPAddress = 1,

        // Generic string/binary blobs.  It's up to your app to interpret this.
        // This library can tell you if the remote host presented a certificate
        // signed by somebody you have chosen to trust, with this identity on it.
        // It's up to you to ultimately decide what this identity means.
        k_EIntPtrType_GenericString = 2,
        k_EIntPtrType_GenericBytes = 3,

        // This identity type is used when we parse a string that looks like is a
        // valid identity, just of a kind that we don't recognize.  In this case, we
        // can often still communicate with the peer!  Allowing such identities
        // for types we do not recognize useful is very useful for forward
        // compatibility.
        k_EIntPtrType_UnknownType = 4,

        // Make sure this enum is stored in an int.
        k_EIntPtrType__Force32bit = 0x7fffffff,
    };
    public struct SteamDatagramRelayAuthTicket { };
    public struct SteamDatagramHostedAddress { };
    public struct SteamDatagramGameCoordinatorServerLogin { };
    public struct SteamRelayNetworkStatus_t { };
    /// Describe the status of a particular network resource
    public enum ESteamNetworkingAvailability
    {
        // Negative values indicate a problem.
        //
        // In general, we will not automatically retry unless you take some action that
        // depends on of requests this resource, such as querying the status, attempting
        // to initiate a connection, receive a connection, etc.  If you do not take any
        // action at all, we do not automatically retry in the background.
        k_ESteamNetworkingAvailability_CannotTry = -102,        // A dependent resource is missing, so this service is unavailable.  (E.g. we cannot talk to routers because Internet is down or we don't have the network config.)
        k_ESteamNetworkingAvailability_Failed = -101,           // We have tried for enough time that we would expect to have been successful by now.  We have never been successful
        k_ESteamNetworkingAvailability_Previously = -100,       // We tried and were successful at one time, but now it looks like we have a problem

        k_ESteamNetworkingAvailability_Retrying = -10,      // We previously failed and are currently retrying

        // Not a problem, but not ready either
        k_ESteamNetworkingAvailability_NeverTried = 1,      // We don't know because we haven't ever checked/tried
        k_ESteamNetworkingAvailability_Waiting = 2,         // We're waiting on a dependent resource to be acquired.  (E.g. we cannot obtain a cert until we are logged into Steam.  We cannot measure latency to relays until we have the network config.)
        k_ESteamNetworkingAvailability_Attempting = 3,      // We're actively trying now, but are not yet successful.

        k_ESteamNetworkingAvailability_Current = 100,           // Resource is online/available


        k_ESteamNetworkingAvailability_Unknown = 0,         // Internal dummy/sentinel, or value is not applicable in this context
        k_ESteamNetworkingAvailability__Force32bit = 0x7fffffff,
    };
}