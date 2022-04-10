﻿using SKYNET;
using SKYNET.Helpers;
using System;
using System.Runtime.InteropServices;

namespace SKYNET.Steamworks.Implementation
{
    [StructLayout(LayoutKind.Sequential)]
    public class SteamVideo : ISteamInterface
    {
        public void GetVideoURL(IntPtr unVideoAppID)
        {
            Write($"GetVideoURL");
        }

        public bool IsBroadcasting(int pnNumViewers)
        {
            Write($"IsBroadcasting");
            return false;
        }

        public void GetOPFSettings(IntPtr unVideoAppID)
        {
            Write($"GetOPFSettings");
        }

        public bool GetOPFStringForApp(IntPtr unVideoAppID, string pchBuffer, uint pnBufferSize)
        {
            Write($"GetOPFStringForApp");
            return false;
        }

        public IntPtr MemoryAddress { get; set; }
        public string InterfaceVersion { get; set; }

        public SteamVideo()
        {
            InterfaceVersion = "SteamVideo";
        }

        private void Write(string v)
        {
            SteamEmulator.Write(InterfaceVersion, v);
        }
    }
}
