﻿using Core.Interface;
using SKYNET.Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Delegate
{
    [Delegate(Name = "SteamScreenshots")]
    public class ISteamScreenshots 
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint WriteScreenshot(IntPtr pubRGB, uint cubRGB, int nWidth, int nHeight);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint AddScreenshotToLibrary(char pchFilename, char pchThumbnailFilename, int nWidth, int nHeight);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void TriggerScreenshot(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void HookScreenshots(bool bHook);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool SetLocation(uint hScreenshot, char pchLocation);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool TagUser(uint hScreenshot, IntPtr steamID);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool TagPublishedFile(uint hScreenshot, uint unPublishedFileID);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool IsScreenshotsHooked(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint AddVRScreenshotToLibrary(EVRScreenshotType eType, char pchFilename, char pchVRFilename);

    }
}
