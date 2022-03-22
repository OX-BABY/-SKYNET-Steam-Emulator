using System;
using System.Runtime.InteropServices;

// Autogenerated @ 21/08/18
namespace InterfaceUser
{
    /// <summary>
    /// Exports the delegates for all interfaces that implement SteamUser019
    /// </summary>
    [Core.Interface.Delegate(Name = "SteamUser019")]
    class SteamUser019_Delegates
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetHSteamUser(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool LoggedOn(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate ulong GetSteamID(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int InitiateGameConnection(IntPtr _, IntPtr blob, uint blob_count, ulong gameserver_id, uint server_ip, short server_port, bool secure);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void TerminateGameConnection(IntPtr _, uint server_ip, short server_port);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void TrackAppUsageEvent(IntPtr _, ulong game_id, int usage_event, string extra_info);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool GetUserDataFolder(IntPtr _, string buffer, int count);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void StartVoiceRecording(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void StopVoiceRecording(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint GetAvailableVoice(IntPtr _, System.UInt32[] compressed_data, System.UInt32[] uncompressed, uint desired_sample_rate);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetVoice(IntPtr _, bool want_compressed, IntPtr dest_buffer, uint dest_buffer_size, ref uint compressed_bytes_written, bool wants_uncompressed, IntPtr uncompressed_dest, uint uncompressed_buffer_size, ref uint bytes_written, uint uncompressed_desired_samplerate);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int DecompressVoice(IntPtr _, IntPtr compressed, uint compressed_size, IntPtr dest_buffer, uint dest_size, ref uint bytes_written, uint sample_rate);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint GetOptimalSampleRate(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetAuthSessionTicket(IntPtr _, IntPtr ticket, uint ticket_size, ref int ticket_written);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint BeginAuthSession(IntPtr _, IntPtr ticket, uint ticket_size, ulong steamid);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void EndAuthSession(IntPtr _, ulong steam_id);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CancelAuthTicket(IntPtr _, int ticket_handle);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint UserHasLicenseForApp(IntPtr _, ulong steamID, uint appID);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void AdvertiseGame(IntPtr _, ulong game_server_id, uint server_ip, short server_port);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint RequestEncryptedAppTicket(IntPtr _, IntPtr data_to_include, uint data_size);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetGameBadgeLevel(IntPtr _, int seris, bool foil);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetSteamLevel(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate uint RequestStoreAuthURL(IntPtr _, string redirect_url);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool IsPhoneVerified(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool IsTwoFactorEnabled(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool IsPhoneIdentifying(IntPtr _);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate bool IsPhoneRequiringVerification();
    }
}
