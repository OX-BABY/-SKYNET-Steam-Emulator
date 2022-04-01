﻿using SKYNET;
using SKYNET.Delegate.Helper;
using System;
using System.Runtime.InteropServices;

namespace SKYNET.Types
{
}

[StructLayout(LayoutKind.Sequential)]
public struct CSteamApiContext
{
    public IntPtr m_pSteamClient;              //ISteamClient* 
    public IntPtr m_pSteamUser;                //ISteamUser* 
    public IntPtr m_pSteamFriends;             //ISteamFriends* 
    public IntPtr m_pSteamUtils;               //ISteamUtils* 
    public IntPtr m_pSteamMatchmaking;         //ISteamMatchmaking* 
    public IntPtr m_pSteamGameSearch;          //ISteamGameSearch* 
    public IntPtr m_pSteamUserStats;           //ISteamUserStats* 
    public IntPtr m_pSteamApps;                //ISteamApps* 
    public IntPtr m_pSteamMatchmakingServers;  //ISteamMatchmakingServers* 
    public IntPtr m_pSteamNetworking;          //ISteamNetworking* 
    public IntPtr m_pSteamRemoteStorage;       //ISteamRemoteStorage* 
    public IntPtr m_pSteamScreenshots;         //ISteamScreenshots* 
    public IntPtr m_pSteamHTTP;                //ISteamHTTP* 
    public IntPtr m_pSteamController;          //ISteamController* 
    public IntPtr m_pSteamUGC;                 //ISteamUGC* 
    public IntPtr m_pSteamAppList;             //ISteamAppList* 
    public IntPtr m_pSteamMusic;               //ISteamMusic* 
    public IntPtr m_pSteamMusicRemote;         //ISteamMusicRemote* 
    public IntPtr m_pSteamHTMLSurface;         //ISteamHTMLSurface* 
    public IntPtr m_pSteamInventory;           //ISteamInventory* 
    public IntPtr m_pSteamVideo;               //ISteamVideo* 
    public IntPtr m_pSteamTV;                  //ISteamTV* 
    public IntPtr m_pSteamParentalSettings;    //ISteamParentalSettings* 
    public IntPtr m_pSteamInput;               //ISteamInput* 

    public IntPtr SteamClient() => m_pSteamClient;
    public IntPtr SteamUser() => m_pSteamUser;
    public IntPtr SteamFriends() => m_pSteamFriends;
    public IntPtr SteamUtils() => m_pSteamUtils;
    public IntPtr SteamMatchmaking() => m_pSteamMatchmaking;
    public IntPtr SteamGameSearch() => m_pSteamGameSearch;
    public IntPtr SteamUserStats() => m_pSteamUserStats;
    public IntPtr SteamApps() => m_pSteamApps;
    public IntPtr SteamMatchmakingServers() => m_pSteamMatchmakingServers;
    public IntPtr SteamNetworking() => m_pSteamNetworking;
    public IntPtr SteamRemoteStorage() => m_pSteamRemoteStorage;
    public IntPtr SteamScreenshots() => m_pSteamScreenshots;
    public IntPtr SteamHTTP() => m_pSteamHTTP;
    public IntPtr SteamController() => m_pSteamController;
    public IntPtr SteamUGC() => m_pSteamUGC;
    public IntPtr SteamAppList() => m_pSteamAppList;
    public IntPtr SteamMusic() => m_pSteamMusic;
    public IntPtr SteamMusicRemote() => m_pSteamMusicRemote;
    public IntPtr SteamHTMLSurface() => m_pSteamHTMLSurface;
    public IntPtr SteamInventory() => m_pSteamInventory;
    public IntPtr SteamVideo() => m_pSteamVideo;
    public IntPtr SteamTV() => m_pSteamTV;
    public IntPtr SteamParentalSettings() => m_pSteamParentalSettings;
    public IntPtr SteamInput() => m_pSteamInput;

    public void Clear()
    {
        SteamEmulator.Write($"Cleaning CSteamApiContext");

        m_pSteamClient = IntPtr.Zero;
        m_pSteamUser = IntPtr.Zero;
        m_pSteamFriends = IntPtr.Zero;
        m_pSteamUtils = IntPtr.Zero;
        m_pSteamMatchmaking = IntPtr.Zero;
        m_pSteamUserStats = IntPtr.Zero;
        m_pSteamApps = IntPtr.Zero;
        m_pSteamMatchmakingServers = IntPtr.Zero;
        m_pSteamNetworking = IntPtr.Zero;
        m_pSteamRemoteStorage = IntPtr.Zero;
        m_pSteamScreenshots = IntPtr.Zero;
        m_pSteamHTTP = IntPtr.Zero;
        m_pSteamController = IntPtr.Zero;
        m_pSteamUGC = IntPtr.Zero;
        m_pSteamAppList = IntPtr.Zero;
        m_pSteamMusic = IntPtr.Zero;
        m_pSteamMusicRemote = IntPtr.Zero;
        m_pSteamHTMLSurface = IntPtr.Zero;
        m_pSteamInventory = IntPtr.Zero;
        m_pSteamVideo = IntPtr.Zero;

        SteamEmulator.Write($"CSteamApiContext cleaned");
    }

    public bool Init()
    {

        SteamEmulator.Write($"CSteamApiContext Initializing");

        m_pSteamClient = SteamEmulator.SteamClient.MemoryAddress;
        if (m_pSteamClient == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamUser = SteamEmulator.SteamUser.MemoryAddress;
        if (m_pSteamUser == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamFriends = SteamEmulator.SteamFriends.MemoryAddress;
        if (m_pSteamFriends == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamUtils = SteamEmulator.SteamUtils.MemoryAddress;
        if (m_pSteamUtils == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamMatchmaking = SteamEmulator.SteamMatchmaking.MemoryAddress;
        if (m_pSteamMatchmaking == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamMatchmakingServers = SteamEmulator.SteamMatchMakingServers.MemoryAddress;
        if (m_pSteamMatchmakingServers == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamUserStats = SteamEmulator.SteamUserStats.MemoryAddress;
        if (m_pSteamUserStats == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamApps = SteamEmulator.SteamApps.MemoryAddress;
        if (m_pSteamApps == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamNetworking = SteamEmulator.SteamNetworking.MemoryAddress;
        if (m_pSteamNetworking == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamRemoteStorage = SteamEmulator.SteamMusicRemote.MemoryAddress;
        if (m_pSteamRemoteStorage == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamScreenshots = SteamEmulator.SteamScreenshots.MemoryAddress;
        if (m_pSteamScreenshots == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamHTTP = SteamEmulator.SteamHTTP.MemoryAddress;
        if (m_pSteamHTTP == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamController = SteamEmulator.SteamController.MemoryAddress;
        if (m_pSteamController == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamUGC = SteamEmulator.SteamUGC.MemoryAddress;
        if (m_pSteamUGC == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamAppList = SteamEmulator.SteamAppList.MemoryAddress;
        if (m_pSteamAppList == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamMusic = SteamEmulator.SteamMusic.MemoryAddress;
        if (m_pSteamMusic == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamMusicRemote = SteamEmulator.SteamMusicRemote.MemoryAddress;
        if (m_pSteamMusicRemote == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamHTMLSurface = SteamEmulator.SteamHTMLSurface.MemoryAddress;
        if (m_pSteamHTMLSurface == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamInventory = SteamEmulator.SteamInventory.MemoryAddress;
        if (m_pSteamInventory == IntPtr.Zero)
        {
            return false;
        }

        m_pSteamVideo = SteamEmulator.SteamVideo.MemoryAddress;
        if (m_pSteamVideo == IntPtr.Zero)
        {
            return false;
        }

        return true;
    }
}

[Delegate(Name = "CSteamApiContext")]
public class DCSteamApiContext
{
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void Clear();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate bool Init();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamClient();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamUser();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamFriends();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamUtils();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamMatchmaking();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamGameSearch();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamUserStats();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamApps();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamMatchmakingServers();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamNetworking();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamRemoteStorage();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamScreenshots();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamHTTP();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamController();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamUGC();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamAppList();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamMusic();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamMusicRemote();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamHTMLSurface();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamInventory();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamVideo();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamTV();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamParentalSettings();

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr SteamInput();
}
