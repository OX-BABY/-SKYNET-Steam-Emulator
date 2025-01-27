﻿using System;
using SKYNET.Steamworks.Interfaces;

namespace SKYNET.Steamworks.Implementation
{
    public class SteamNetworkingMessages : ISteamInterface
    {
        public static SteamNetworkingMessages Instance;

        public SteamNetworkingMessages()
        {
            Instance = this;
            InterfaceName = "SteamNetworkingMessages";
            InterfaceVersion = "SteamNetworkingMessages002";
        }

        public int SendMessageToUser(IntPtr identityRemote, IntPtr pubData, uint cubData, int nSendFlags, int nRemoteChannel)
        {
            Write("SendMessageToUser");
            return (int)EResult.k_EResultOK;
        }

        public int ReceiveMessagesOnChannel(int nLocalChannel, IntPtr ppOutMessages, int nMaxMessages)
        {
            Write("ReceiveMessagesOnChannel");
            return 0;
        }

        public bool AcceptSessionWithUser(IntPtr identityRemote)
        {
            Write("AcceptSessionWithUser");
            return true;
        }

        public bool CloseSessionWithUser(IntPtr identityRemote)
        {
            Write("CloseSessionWithUser");
            return false;
        }

        public bool CloseChannelWithUser(IntPtr identityRemote, int nLocalChannel)
        {
            Write("CloseChannelWithUser");
            return false;
        }

        public IntPtr GetSessionConnectionInfo(IntPtr identityRemote, IntPtr pConnectionInfo, IntPtr pQuickStatus)
        {
            Write("GetSessionConnectionInfo");
            return IntPtr.Zero;
        }
    }
}