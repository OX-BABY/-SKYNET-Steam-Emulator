﻿using SKYNET;
using SKYNET.Steamworks;
using System;

public class SteamRemotePlay : SteamInterface
{
    public uint GetSessionCount(IntPtr _)
    {
        Write("GetSessionCount");
        return 0;
    }

    public uint GetSessionID(int iSessionIndex)
    {
        Write("GetSessionID");
        return default;
    }

    public IntPtr GetSessionSteamID(uint unSessionID)
    {
        Write("GetSessionSteamID");
        return default;
    }

    public string GetSessionClientName(uint unSessionID)
    {
        Write("GetSessionClientName");
        return default;
    }

    public ESteamDeviceFormFactor GetSessionClientFormFactor(uint unSessionID)
    {
        Write("GetSessionClientFormFactor");
        return default;
    }

    public bool BGetSessionClientResolution(uint unSessionID, int pnResolutionX, int pnResolutionY)
    {
        Write("BGetSessionClientResolution");
        return default;
    }

    public bool BSendRemotePlayTogetherInvite(IntPtr steamIDFriend)
    {
        Write("BSendRemotePlayTogetherInvite");
        return default;
    }


    private void Write(string v)
    {
        Main.Write(InterfaceVersion, v);
    }
}