﻿using System;
using System.Runtime.InteropServices;

namespace SKYNET.Steamworks.Exported
{
    public class SteamAPI_ISteamNetworkingSockets
    {
        static SteamAPI_ISteamNetworkingSockets()
        {
            if (!SteamEmulator.Initialized && !SteamEmulator.Initializing)
            {
                SteamEmulator.Initialize();
            }
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP(IntPtr _, IntPtr localAddress, int nOptions, IntPtr pOptions)
        {
            Write("SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP");
            return SteamEmulator.SteamNetworkingSockets.CreateListenSocketIP(localAddress, nOptions, pOptions);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress(IntPtr _, IntPtr address, int nOptions, IntPtr pOptions)
        {
            Write("SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress");
            return SteamEmulator.SteamNetworkingSockets.ConnectByIPAddress(address, nOptions, pOptions);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P(IntPtr _, int nVirtualPort, int nOptions, IntPtr pOptions)
        {
            Write("SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P");
            return SteamEmulator.SteamNetworkingSockets.CreateListenSocketP2P(nVirtualPort, nOptions, pOptions);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_ConnectP2P(IntPtr _, IntPtr identityRemote, int nVirtualPort, int nOptions, IntPtr pOptions)
        {
            Write("SteamAPI_ISteamNetworkingSockets_ConnectP2P");
            return SteamEmulator.SteamNetworkingSockets.ConnectP2P(identityRemote, nVirtualPort, nOptions, pOptions);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_AcceptConnection(IntPtr _, uint hConn)
        {
            Write("SteamAPI_ISteamNetworkingSockets_AcceptConnection");
            return SteamEmulator.SteamNetworkingSockets.AcceptConnection(hConn);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_CloseConnection(IntPtr _, uint hPeer, int nReason, char pszDebug, bool bEnableLinger)
        {
            Write("SteamAPI_ISteamNetworkingSockets_CloseConnection");
            return SteamEmulator.SteamNetworkingSockets.CloseConnection(hPeer, nReason, pszDebug, bEnableLinger);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_CloseListenSocket(IntPtr _, uint hSocket)
        {
            Write("SteamAPI_ISteamNetworkingSockets_CloseListenSocket");
            return SteamEmulator.SteamNetworkingSockets.CloseListenSocket(hSocket);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_SetConnectionUserData(IntPtr _, uint hPeer, uint nUserData)
        {
            Write("SteamAPI_ISteamNetworkingSockets_SetConnectionUserData");
            return SteamEmulator.SteamNetworkingSockets.SetConnectionUserData(hPeer, nUserData);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_GetConnectionUserData(IntPtr _, uint hPeer)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetConnectionUserData");
            return SteamEmulator.SteamNetworkingSockets.GetConnectionUserData(hPeer);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static void SteamAPI_ISteamNetworkingSockets_SetConnectionName(IntPtr _, uint hPeer, char pszName)
        {
            Write("SteamAPI_ISteamNetworkingSockets_SetConnectionName");
            //
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_GetConnectionName(IntPtr _, uint hPeer, char pszName, int nMaxLen)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetConnectionName");
            return SteamEmulator.SteamNetworkingSockets.GetConnectionName(hPeer, pszName, nMaxLen);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_SendMessageToConnection(IntPtr _, uint hConn, IntPtr pData, uint cbData, int nSendFlags, uint pOutMessageNumber)
        {
            Write("SteamAPI_ISteamNetworkingSockets_SendMessageToConnection");
            return SteamEmulator.SteamNetworkingSockets.SendMessageToConnection(hConn, pData, cbData, nSendFlags, pOutMessageNumber);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static void SteamAPI_ISteamNetworkingSockets_SendMessages(IntPtr _, int nMessages, IntPtr pMessages, uint pOutMessageNumberOrResult)
        {
            Write("SteamAPI_ISteamNetworkingSockets_SendMessages");
            //
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection(IntPtr _, uint hConn)
        {
            Write("SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection");
            return SteamEmulator.SteamNetworkingSockets.FlushMessagesOnConnection(hConn);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection(IntPtr _, uint hConn, IntPtr ppOutMessages, int nMaxMessages)
        {
            Write("SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection");
            return SteamEmulator.SteamNetworkingSockets.ReceiveMessagesOnConnection(hConn, ppOutMessages, nMaxMessages);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_GetConnectionInfo(IntPtr _, uint hConn, IntPtr pInfo)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetConnectionInfo");
            return SteamEmulator.SteamNetworkingSockets.GetConnectionInfo(hConn, pInfo);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_GetQuickConnectionStatus(IntPtr _, uint hConn, IntPtr pStats)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetQuickConnectionStatus");
            return SteamEmulator.SteamNetworkingSockets.GetQuickConnectionStatus(hConn, pStats);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus(IntPtr _, uint hConn, char pszBuf, int cbBuf)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus");
            return SteamEmulator.SteamNetworkingSockets.GetDetailedConnectionStatus(hConn, pszBuf, cbBuf);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress(IntPtr _, uint hSocket, IntPtr address)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress");
            return SteamEmulator.SteamNetworkingSockets.GetListenSocketAddress(hSocket, address);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_CreateSocketPair(IntPtr _, uint pOutConnection1, uint pOutConnection2, bool bUseNetworkLoopback, IntPtr pIdentity1, IntPtr pIdentity2)
        {
            Write("SteamAPI_ISteamNetworkingSockets_CreateSocketPair");
            return SteamEmulator.SteamNetworkingSockets.CreateSocketPair(pOutConnection1, pOutConnection2, bUseNetworkLoopback, pIdentity1, pIdentity2);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_GetIdentity(IntPtr _, IntPtr pIdentity)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetIdentity");
            return SteamEmulator.SteamNetworkingSockets.GetIdentity(pIdentity);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_InitAuthentication(IntPtr _)
        {
            Write("SteamAPI_ISteamNetworkingSockets_InitAuthentication");
            return SteamEmulator.SteamNetworkingSockets.InitAuthentication();
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus(IntPtr _, IntPtr pDetails)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus");
            return SteamEmulator.SteamNetworkingSockets.GetAuthenticationStatus(pDetails);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_CreatePollGroup(IntPtr _)
        {
            Write("SteamAPI_ISteamNetworkingSockets_CreatePollGroup");
            return SteamEmulator.SteamNetworkingSockets.CreatePollGroup();
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_DestroyPollGroup(IntPtr _, uint hPollGroup)
        {
            Write("SteamAPI_ISteamNetworkingSockets_DestroyPollGroup");
            return SteamEmulator.SteamNetworkingSockets.DestroyPollGroup(hPollGroup);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup(IntPtr _, uint hConn, uint hPollGroup)
        {
            Write("SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup");
            return SteamEmulator.SteamNetworkingSockets.SetConnectionPollGroup(hConn, hPollGroup);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup(IntPtr _, uint hPollGroup, IntPtr ppOutMessages, int nMaxMessages)
        {
            Write("SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup");
            return SteamEmulator.SteamNetworkingSockets.ReceiveMessagesOnPollGroup(hPollGroup, ppOutMessages, nMaxMessages);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket(IntPtr _, IntPtr pvTicket, int cbTicket, IntPtr pOutParsedTicket)
        {
            Write("SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket");
            return SteamEmulator.SteamNetworkingSockets.ReceivedRelayAuthTicket(pvTicket, cbTicket, pOutParsedTicket);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer(IntPtr _, IntPtr identityGameServer, int nVirtualPort, IntPtr pOutParsedTicket)
        {
            Write("SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer");
            return SteamEmulator.SteamNetworkingSockets.FindRelayAuthTicketForServer(identityGameServer, nVirtualPort, pOutParsedTicket);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer(IntPtr _, IntPtr identityTarget, int nVirtualPort, int nOptions, IntPtr pOptions)
        {
            Write("SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer");
            return SteamEmulator.SteamNetworkingSockets.ConnectToHostedDedicatedServer(identityTarget, nVirtualPort, nOptions, pOptions);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort(IntPtr _)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort");
            return SteamEmulator.SteamNetworkingSockets.GetHostedDedicatedServerPort();
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID(IntPtr _)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID");
            return SteamEmulator.SteamNetworkingSockets.GetHostedDedicatedServerPOPID();
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress(IntPtr _, IntPtr pRouting)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress");
            return SteamEmulator.SteamNetworkingSockets.GetHostedDedicatedServerAddress(pRouting);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket(IntPtr _, int nVirtualPort, int nOptions, IntPtr pOptions)
        {
            Write("SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket");
            return SteamEmulator.SteamNetworkingSockets.CreateHostedDedicatedServerListenSocket(nVirtualPort, nOptions, pOptions);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static int SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin(IntPtr _, IntPtr pLoginInfo, int pcbSignedBlob, IntPtr pBlob)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin");
            return SteamEmulator.SteamNetworkingSockets.GetGameCoordinatorServerLogin(pLoginInfo, pcbSignedBlob, pBlob);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static uint SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling(IntPtr _, IntPtr pSignaling, IntPtr pPeerIdentity, int nOptions, IntPtr pOptions)
        {
            Write("SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling");
            return SteamEmulator.SteamNetworkingSockets.ConnectP2PCustomSignaling(pSignaling, pPeerIdentity, nOptions, pOptions);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal(IntPtr _, IntPtr pMsg, int cbMsg, IntPtr pContext)
        {
            Write("SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal");
            return SteamEmulator.SteamNetworkingSockets.ReceivedP2PCustomSignal(pMsg, cbMsg, pContext);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_GetCertificateRequest(IntPtr _, int pcbBlob, IntPtr pBlob, string errMsg)
        {
            Write("SteamAPI_ISteamNetworkingSockets_GetCertificateRequest");
            return SteamEmulator.SteamNetworkingSockets.GetCertificateRequest(pcbBlob, pBlob, errMsg);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static bool SteamAPI_ISteamNetworkingSockets_SetCertificate(IntPtr _, IntPtr pCertificate, int cbCertificate, string errMsg)
        {
            Write("SteamAPI_ISteamNetworkingSockets_SetCertificate");
            return SteamEmulator.SteamNetworkingSockets.SetCertificate(pCertificate, cbCertificate, errMsg);
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl)]
        public static void SteamAPI_ISteamNetworkingSockets_RunCallbacks(IntPtr _, IntPtr pCallbacks)
        {
            Write("SteamAPI_ISteamNetworkingSockets_RunCallbacks");
        }

        private static void Write(string msg)
        {
            SteamEmulator.Write("", msg);
        }
    }
}

