﻿using System;
using SKYNET.Steamworks.Interfaces;

namespace SKYNET.Steamworks.Implementation
{
    public class SteamScreenshots : ISteamInterface
    {
        public static SteamScreenshots Instance;

        public SteamScreenshots()
        {
            Instance = this;
            InterfaceName = "SteamScreenshots";
            InterfaceVersion = "STEAMSCREENSHOTS_INTERFACE_VERSION003";
        }

        public uint WriteScreenshot(IntPtr pubRGB, uint cubRGB, int nWidth, int nHeight)
        {
            Write("WriteScreenshot");
            return 0;
        }

        public uint AddScreenshotToLibrary(string pchFilename, string pchThumbnailFilename, int nWidth, int nHeight)
        {
            Write("AddScreenshotToLibrary");
            return 0;
        }

        public void TriggerScreenshot()
        {
            Write("TriggerScreenshot");
        }

        public void HookScreenshots(bool bHook)
        {
            Write("HookScreenshots");
        }

        public bool SetLocation(uint hScreenshot, string pchLocation)
        {
            Write("SetLocation");
            return false;
        }

        public bool TagUser(uint hScreenshot, ulong steamID)
        {
            Write("TagUser");
            return false;
        }

        public bool TagPublishedFile(uint hScreenshot, ulong unPublishedFileID)
        {
            Write("TagPublishedFile");
            return false;
        }

        public bool IsScreenshotsHooked()
        {
            Write("IsScreenshotsHooked");
            return false;
        }

        public uint AddVRScreenshotToLibrary(int eType, string pchFilename, string pchVRFilename)
        {
            Write("AddVRScreenshotToLibrary");
            return 0;
        }
    }
}