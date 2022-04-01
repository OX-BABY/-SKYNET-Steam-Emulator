﻿using System;
using System.Runtime.InteropServices;
using Steamworks;
using SKYNET.Delegate.Helper;

namespace SKYNET.Delegate
{
    [Delegate(Name = "SteamApps")]
    public class DSteamApps 
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsSubscribed(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsLowViolence(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsCybercafe(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsVACBanned(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate string GetCurrentGameLanguage(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate string GetAvailableGameLanguages(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsSubscribedApp(AppId_t appID);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsDlcInstalled(AppId_t appID);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate UInt32 GetEarliestPurchaseUnixTime(AppId_t nAppID);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsSubscribedFromFreeWeekend(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetDLCCount(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BGetDLCDataByIndex(int iDLC, IntPtr pAppID, bool pbAvailable, IntPtr pchName, int cchNameBufferSize);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void InstallDLC(AppId_t nAppID);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void UninstallDLC(AppId_t nAppID);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void RequestAppProofOfPurchaseKey(AppId_t nAppID);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool GetCurrentBetaName(IntPtr pchName, int cchNameBufferSize); // returns current beta branch name, 'public' is the default branch
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool MarkContentCorrupt(bool bMissingFilesOnly); // signal Steam that game files seems corrupt or missing
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate UInt32 GetInstalledDepots(AppId_t appID, IntPtr pvecDepots, UInt32 cMaxDepots); // return installed depots in mount order

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate UInt32 GetAppInstallDir(AppId_t appID, IntPtr pchFolder, UInt32 cchFolderBufferSize);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsAppInstalled(AppId_t appID); // returns true if that app is installed (not necessarily owned)

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr GetAppOwner(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate string GetLaunchQueryParam(string pchKey);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool GetDlcDownloadProgress(AppId_t nAppID, UInt64 punBytesDownloaded, UInt64 punBytesTotal);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetAppBuildId(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void RequestAllProofOfPurchaseKeys(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate SteamAPICall_t GetFileDetails(string pszFileName);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsSubscribedFromFamilySharing(IntPtr _);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool BIsTimedTrial(UInt32 punSecondsAllowed, UInt32 punSecondsPlayed);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetLaunchCommandLine(IntPtr pszCommandLine, int cubCommandLine);

        
    }
}