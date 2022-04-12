﻿using System;
using System.Runtime.InteropServices;
using SKYNET;
using SKYNET.Helpers;
using SKYNET.Steamworks;
using SKYNET.Steamworks.Types;
using SKYNET.Types;
using Steamworks;

namespace SKYNET.Steamworks.Implementation
{
    public class SteamUser : ISteamInterface
    {
        public SteamUser()
        {
            InterfaceVersion = "SteamUser";
        }

        public int GetHSteamUser(IntPtr _)
        {
            Write("GetHSteamUser");
            return (int)SteamEmulator.HSteamUser;
        }

        public bool BLoggedOn()
        {
            Write("BLoggedOn");
            return true;
        }

        public ulong GetSteamID(IntPtr _)
        {
            var SId = SteamEmulator.SteamId;
            Write($"GetSteamID {(ulong)SId}");
            return SId;
        }

        public int InitiateGameConnection(IntPtr _, IntPtr pAuthBlob, int cbMaxAuthBlob, ulong steamIDGameServer, uint unIPServer, uint usPortServer, bool bSecure)
        {
            Write("InitiateGameConnection");
            return 0;
        }

        public void TerminateGameConnection(IntPtr _, uint unIPServer, uint usPortServer)
        {
            Write("TerminateGameConnection");
        }

        public void TrackAppUsageEvent(IntPtr _, IntPtr gameID, int eAppUsageEvent, string pchExtraInfo = "")
        {
            Write("TrackAppUsageEvent");
        }

        public bool GetUserDataFolder(IntPtr _, string pchBuffer, int cubBuffer)
        {
            Write("GetUserDataFolder");
            return false;
        }

        public void StartVoiceRecording(IntPtr _)
        {
            Write("StartVoiceRecording");
        }

        public void StopVoiceRecording(IntPtr _)
        {
            Write("StopVoiceRecording");
        }

        public int GetAvailableVoice(IntPtr _, uint pcbCompressed, uint pcbUncompressed_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated)
        {
            Write("GetAvailableVoice");
            return (int)EVoiceResult.k_EVoiceResultNoData;
        }

        public int GetVoice(IntPtr _, bool bWantCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, uint nBytesWritten, bool bWantUncompressed_Deprecated, IntPtr pUncompressedDestBuffer_Deprecated, uint cbUncompressedDestBufferSize_Deprecated, uint nUncompressBytesWritten_Deprecated, uint nUncompressedVoiceDesiredSampleRate_Deprecated)
        {
            Write("GetVoice");
            return (int)EVoiceResult.k_EVoiceResultNoData;
        }

        public int DecompressVoice(IntPtr _, IntPtr pCompressed, uint cbCompressed, IntPtr pDestBuffer, uint cbDestBufferSize, uint nBytesWritten, uint nDesiredSampleRate)
        {
            Write("DecompressVoice");
            return (int)EVoiceResult.k_EVoiceResultNoData;
        }

        public uint GetVoiceOptimalSampleRate(IntPtr _)
        {
            Write("GetVoiceOptimalSampleRate");
            return 0;
        }

        public uint GetAuthSessionTicket(IntPtr _, IntPtr pTicket, int cbMaxTicket, uint pcbTicket)
        {
            Write("GetAuthSessionTicket");
            return 0;
        }

        public int BeginAuthSession(IntPtr _, IntPtr pAuthTicket, int cbAuthTicket, ulong steamID)
        {
            Write("BeginAuthSession");
            return (int)EBeginAuthSessionResult.k_EBeginAuthSessionResultOK;
        }

        public void EndAuthSession(IntPtr _, ulong steamID)
        {
            Write("EndAuthSession");
        }

        public void CancelAuthTicket(IntPtr _, uint hAuthTicket)
        {
            Write("CancelAuthTicket");
        }

        public int UserHasLicenseForApp(IntPtr _, ulong steamID, uint appID)
        {
            Write("EUserHasLicenseForAppResult");
            return (int)EUserHasLicenseForAppResult.k_EUserHasLicenseResultHasLicense;
        }

        public bool BIsBehindNAT(IntPtr _)
        {
            Write("BIsBehindNAT");
            return false;
        }

        public void AdvertiseGame(IntPtr _, ulong steamIDGameServer, uint unIPServer, uint usPortServer)
        {
            Write("AdvertiseGame");
        }

        public ulong RequestEncryptedAppTicket(IntPtr _, IntPtr pDataToInclude, int cbDataToInclude)
        {
            Write("RequestEncryptedAppTicket");
            return 0;
        }

        public bool GetEncryptedAppTicket(IntPtr _, IntPtr pTicket, int cbMaxTicket, uint pcbTicket)
        {
            Write("GetEncryptedAppTicket");
            return false;
        }

        public int GetGameBadgeLevel(IntPtr _, int nSeries, bool bFoil)
        {
            Write("GetGameBadgeLevel");
            return 0;
        }

        public int GetPlayerSteamLevel(IntPtr _)
        {
            Write("GetPlayerSteamLevel");
            return 0;
        }

        public ulong RequestStoreAuthURL(IntPtr _, string pchRedirectURL)
        {
            Write("RequestStoreAuthURL");
            return 0;
        }

        public bool BIsPhoneVerified(IntPtr _)
        {
            Write("BIsPhoneVerified");
            return true;
        }

        public bool BIsTwoFactorEnabled(IntPtr _)
        {
            Write("BIsTwoFactorEnabled");
            return false;
        }

        public bool BIsPhoneIdentifying(IntPtr _)
        {
            Write("BIsPhoneIdentifying");
            return false;
        }

        public bool BIsPhoneRequiringVerification(IntPtr _)
        {
            Write("BIsPhoneRequiringVerification");
            return false;
        }

        public ulong GetMarketEligibility(IntPtr _)
        {
            Write("GetMarketEligibility");
            return default;
        }

        public ulong GetDurationControl(IntPtr _)
        {
            Write("GetDurationControl");
            return default;
        }

        public bool BSetDurationControlOnlineState(IntPtr _, int eNewState)
        {
            Write("BSetDurationControlOnlineState");
            return false;
        }
    }
}