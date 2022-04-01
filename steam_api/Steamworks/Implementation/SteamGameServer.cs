﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SKYNET;
using SKYNET.Helper;
using Steamworks;

public class SteamGameServer : SteamInterface
{
    public int GetHSteamUser(IntPtr _)
    {
        Write($"GetHSteamUser");
        return 1;
    }

    public int GetHSteamPipe(IntPtr _)
    {
        Write($"GetHSteamPipe");
        return 1;
    }

    public void RunCallbacks(IntPtr _)
    {
        Write($"RunCallbacks");
    }

    private void Write(string v)
    {
        Main.Write(InterfaceVersion, v);
    }
}