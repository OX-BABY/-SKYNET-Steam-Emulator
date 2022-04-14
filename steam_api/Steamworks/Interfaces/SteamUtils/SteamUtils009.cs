using SKYNET.Steamworks;
using Steamworks;
using System;

namespace SKYNET.Interface
{
    [Interface("SteamUtils009")]
    public class SteamUtils009 : ISteamInterface
    {
        public uint GetSecondsSinceAppActive(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetSecondsSinceAppActive();
        }

        public uint GetSecondsSinceComputerActive(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetSecondsSinceComputerActive();
        }

        public EUniverse GetConnectedUniverse(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetConnectedUniverse();
        }

        public uint GetServerRealTime(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetServerRealTime();
        }

        public string GetIPCountry(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetIPCountry();
        }

        public bool GetImageSize(IntPtr _, int iImage, uint pnWidth, uint pnHeight)
        {
            return SteamEmulator.SteamUtils.GetImageSize(iImage, pnWidth, pnHeight);
        }

        public bool GetImageRGBA(IntPtr _, int iImage, int pubDest, int nDestBufferSize)
        {
            return SteamEmulator.SteamUtils.GetImageRGBA(iImage, pubDest, nDestBufferSize);
        }

        public bool GetCSERIPPort(IntPtr _, uint unIP, uint usPort)
        {
            return SteamEmulator.SteamUtils.GetCSERIPPort(unIP, usPort);
        }

        public int GetCurrentBatteryPower(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetCurrentBatteryPower();
        }

        public uint GetAppID(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetAppID();
        }

        public void SetOverlayNotificationPosition(IntPtr _, int eNotificationPosition)
        {
            SteamEmulator.SteamUtils.SetOverlayNotificationPosition(eNotificationPosition);
        }

        public bool IsAPICallCompleted(IntPtr _, ulong hSteamAPICall, bool pbFailed)
        {
            return SteamEmulator.SteamUtils.IsAPICallCompleted(hSteamAPICall, pbFailed);
        }

        public ESteamAPICallFailure GetAPICallFailureReason(IntPtr _, ulong hSteamAPICall)
        {
            return SteamEmulator.SteamUtils.GetAPICallFailureReason(hSteamAPICall);
        }

        public bool GetAPICallResult(IntPtr _, ulong hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, bool pbFailed)
        {
            return SteamEmulator.SteamUtils.GetAPICallResult(hSteamAPICall, pCallback, cubCallback, iCallbackExpected, pbFailed);
        }

        // 	STEAM_PRIVATE_API( virtual void RunFrame() = 0; )

        public uint GetIPCCallCount(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetIPCCallCount();
        }

        public void SetWarningMessageHook(IntPtr _, IntPtr pFunction)
        {
            SteamEmulator.SteamUtils.SetWarningMessageHook(pFunction);
        }

        public bool IsOverlayEnabled(IntPtr _)
        {
            return SteamEmulator.SteamUtils.IsOverlayEnabled();
        }

        public bool BOverlayNeedsPresent(IntPtr _)
        {
            return SteamEmulator.SteamUtils.BOverlayNeedsPresent();
        }

        public ulong CheckFileSignature(IntPtr _, string szFileName)
        {
            return SteamEmulator.SteamUtils.CheckFileSignature(szFileName);
        }

        public bool ShowGamepadTextInput(IntPtr _, int eInputMode, int eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText)
        {
            return SteamEmulator.SteamUtils.ShowGamepadTextInput(eInputMode, eLineInputMode, pchDescription, unCharMax, pchExistingText);
        }

        public uint GetEnteredGamepadTextLength(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetEnteredGamepadTextLength();
        }

        public bool GetEnteredGamepadTextInput(IntPtr _, string pchText, uint cchText)
        {
            return SteamEmulator.SteamUtils.GetEnteredGamepadTextInput(pchText, cchText);
        }

        public string GetSteamUILanguage(IntPtr _)
        {
            return SteamEmulator.SteamUtils.GetSteamUILanguage();
        }

        public bool IsSteamRunningInVR(IntPtr _)
        {
            return SteamEmulator.SteamUtils.IsSteamRunningInVR();
        }

        public void SetOverlayNotificationInset(IntPtr _, int nHorizontalInset, int nVerticalInset)
        {
            SteamEmulator.SteamUtils.SetOverlayNotificationInset(nHorizontalInset, nVerticalInset);
        }

        public bool IsSteamInBigPictureMode(IntPtr _)
        {
            return SteamEmulator.SteamUtils.IsSteamInBigPictureMode();
        }

        public void StartVRDashboard(IntPtr _)
        {
            SteamEmulator.SteamUtils.StartVRDashboard();
        }

        public bool IsVRHeadsetStreamingEnabled(IntPtr _)
        {
            return SteamEmulator.SteamUtils.IsVRHeadsetStreamingEnabled();
        }

        public void SetVRHeadsetStreamingEnabled(IntPtr _, bool bEnabled)
        {
            SteamEmulator.SteamUtils.SetVRHeadsetStreamingEnabled(bEnabled);
        }

        public bool IsSteamChinaLauncher(IntPtr _)
        {
            return SteamEmulator.SteamUtils.IsSteamChinaLauncher();
        }

        public bool InitFilterText(IntPtr _)
        {
            return SteamEmulator.SteamUtils.InitFilterText();
        }

        public int FilterText(IntPtr _, string pchOutFilteredText, uint nByteSizeOutFilteredText, string pchInputMessage, bool bLegalOnly)
        {
            return SteamEmulator.SteamUtils.FilterText(pchOutFilteredText, nByteSizeOutFilteredText, pchInputMessage, bLegalOnly);
        }

        public ESteamIPv6ConnectivityState GetIPv6ConnectivityState(IntPtr _, int eProtocol)
        {
            return SteamEmulator.SteamUtils.GetIPv6ConnectivityState(eProtocol);
        }


    }
}