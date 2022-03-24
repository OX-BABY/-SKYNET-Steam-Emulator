﻿using Core.Interface;
using SKYNET;

using SKYNET.Steamworks;
using System;

//[Map("STEAMREMOTEPLAY_INTERFACE_VERSION")]
//[Map("SteamRemotePlay")]
public class SteamRemotePlay : IBaseInterface
{
    public uint GetSessionCount(IntPtr _)
    {
        return 0;
    }

    public uint GetSessionID(int iSessionIndex)
    {
        return default;
    }

    public IntPtr GetSessionSteamID(uint unSessionID)
    {
        return default;
    }

    public string GetSessionClientName(uint unSessionID)
    {
        return default;
    }

    public ESteamDeviceFormFactor GetSessionClientFormFactor(uint unSessionID)
    {
        return default;
    }

    public bool BGetSessionClientResolution(uint unSessionID, int pnResolutionX, int pnResolutionY)
    {
        return default;
    }

    public bool BSendRemotePlayTogetherInvite(IntPtr steamIDFriend)
    {
        return default;
    }

    private void Write(string v)
    {
        Main.Write(InterfaceVersion, v);
    }
}