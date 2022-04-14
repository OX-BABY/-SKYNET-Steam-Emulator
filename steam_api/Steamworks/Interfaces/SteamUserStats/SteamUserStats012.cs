using System;

namespace SKYNET.Interface
{
    [Interface("STEAMUSERSTATS_INTERFACE_VERSION012")]
    public class SteamUserStats012 : ISteamInterface
    {
        public bool RequestCurrentStats(IntPtr _)
        {
            return SteamEmulator.SteamUserStats.RequestCurrentStats();
        }

        public bool GetStat(IntPtr _, string pchName, int pData)
        {
            return SteamEmulator.SteamUserStats.GetStat(pchName, (uint)pData);
        }

        public bool GetStat(IntPtr _, string pchName, float pData)
        {
            return SteamEmulator.SteamUserStats.GetStat(pchName, (uint)pData);
        }

        public bool SetStat(IntPtr _, string pchName, int nData)
        {
            return SteamEmulator.SteamUserStats.SetStat(pchName, (uint)nData);
        }

        public bool SetStat(IntPtr _, string pchName, float fData)
        {
            return SteamEmulator.SteamUserStats.SetStat(pchName, (uint)fData);
        }

        public bool UpdateAvgRateStat(IntPtr _, string pchName, float flCountThisSession, double dSessionLength)
        {
            return SteamEmulator.SteamUserStats.UpdateAvgRateStat(pchName, flCountThisSession, dSessionLength);
        }

        public bool GetAchievement(IntPtr _, string pchName, bool pbAchieved)
        {
            return SteamEmulator.SteamUserStats.GetAchievement(pchName, pbAchieved);
        }

        public bool SetAchievement(IntPtr _, string pchName)
        {
            return SteamEmulator.SteamUserStats.SetAchievement(pchName);
        }

        public bool ClearAchievement(IntPtr _, string pchName)
        {
            return SteamEmulator.SteamUserStats.ClearAchievement(pchName);
        }

        public bool GetAchievementAndUnlockTime(IntPtr _, string pchName, bool pbAchieved, uint punUnlockTime)
        {
            return SteamEmulator.SteamUserStats.GetAchievementAndUnlockTime(pchName, pbAchieved, punUnlockTime);
        }

        public bool StoreStats(IntPtr _)
        {
            return SteamEmulator.SteamUserStats.StoreStats();
        }

        public int GetAchievementIcon(IntPtr _, string pchName)
        {
            return SteamEmulator.SteamUserStats.GetAchievementIcon(pchName);
        }

        public string GetAchievementDisplayAttribute(IntPtr _, string pchName, string pchKey)
        {
            return SteamEmulator.SteamUserStats.GetAchievementDisplayAttribute(pchName, pchKey);
        }

        public bool IndicateAchievementProgress(IntPtr _, string pchName, uint nCurProgress, uint nMaxProgress)
        {
            return SteamEmulator.SteamUserStats.IndicateAchievementProgress(pchName, nCurProgress, nMaxProgress);
        }

        public uint GetNumAchievements(IntPtr _)
        {
            return SteamEmulator.SteamUserStats.GetNumAchievements();
        }

        public string GetAchievementName(IntPtr _, uint iAchievement)
        {
            return SteamEmulator.SteamUserStats.GetAchievementName(iAchievement);
        }

        public ulong RequestUserStats(IntPtr _, ulong steamIDUser)
        {
            return SteamEmulator.SteamUserStats.RequestUserStats(steamIDUser);
        }

        public bool GetUserStat(IntPtr _, ulong steamIDUser, string pchName, int pData)
        {
            return SteamEmulator.SteamUserStats.GetUserStat(steamIDUser, pchName, (uint)pData);
        }

        public bool GetUserStat(IntPtr _, ulong steamIDUser, string pchName, float pData)
        {
            return SteamEmulator.SteamUserStats.GetUserStat(steamIDUser, pchName, (uint)pData);
        }

        public bool GetUserAchievement(IntPtr _, ulong steamIDUser, string pchName, bool pbAchieved)
        {
            return SteamEmulator.SteamUserStats.GetUserAchievement(steamIDUser, pchName, pbAchieved);
        }

        public bool GetUserAchievementAndUnlockTime(IntPtr _, ulong steamIDUser, string pchName, bool pbAchieved, uint punUnlockTime)
        {
            return SteamEmulator.SteamUserStats.GetUserAchievementAndUnlockTime(steamIDUser, pchName, pbAchieved, punUnlockTime);
        }

        public bool ResetAllStats(IntPtr _, bool bAchievementsToo)
        {
            return SteamEmulator.SteamUserStats.ResetAllStats(bAchievementsToo);
        }

        public ulong FindOrCreateLeaderboard(IntPtr _, string pchLeaderboardName, int eLeaderboardSortMethod, int eLeaderboardDisplayType)
        {
            return SteamEmulator.SteamUserStats.FindOrCreateLeaderboard(pchLeaderboardName, eLeaderboardSortMethod, eLeaderboardDisplayType);
        }

        public ulong FindLeaderboard(IntPtr _, string pchLeaderboardName)
        {
            return SteamEmulator.SteamUserStats.FindLeaderboard(pchLeaderboardName);
        }

        public string GetLeaderboardName(IntPtr _, ulong hSteamLeaderboard)
        {
            return SteamEmulator.SteamUserStats.GetLeaderboardName(hSteamLeaderboard);
        }

        public int GetLeaderboardEntryCount(IntPtr _, ulong hSteamLeaderboard)
        {
            return SteamEmulator.SteamUserStats.GetLeaderboardEntryCount(hSteamLeaderboard);
        }

        public int GetLeaderboardSortMethod(IntPtr _, ulong hSteamLeaderboard)
        {
            return SteamEmulator.SteamUserStats.GetLeaderboardSortMethod(hSteamLeaderboard);
        }

        public int GetLeaderboardDisplayType(IntPtr _, ulong hSteamLeaderboard)
        {
            return SteamEmulator.SteamUserStats.GetLeaderboardDisplayType(hSteamLeaderboard);
        }

        public ulong DownloadLeaderboardEntries(IntPtr _, ulong hSteamLeaderboard, IntPtr eLeaderboardDataRequest, int nRangeStart, int nRangeEnd)
        {
            return SteamEmulator.SteamUserStats.DownloadLeaderboardEntries(hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd);
        }

        public ulong DownloadLeaderboardEntriesForUsers(IntPtr _, ulong hSteamLeaderboard, ulong prgUsers, int cUsers )
    {
            return SteamEmulator.SteamUserStats.DownloadLeaderboardEntriesForUsers(hSteamLeaderboard, prgUsers, cUsers);
        }

        public bool GetDownloadedLeaderboardEntry(IntPtr _, ulong hSteamLeaderboardEntries, int index, IntPtr pLeaderboardEntry, int pDetails, int cDetailsMax)
        {
            return SteamEmulator.SteamUserStats.GetDownloadedLeaderboardEntry(hSteamLeaderboardEntries, index, pLeaderboardEntry, (uint)pDetails, cDetailsMax);
        }

        public ulong UploadLeaderboardScore(IntPtr _, ulong hSteamLeaderboard, int eLeaderboardUploadScoreMethod, int nScore, int pScoreDetails, int cScoreDetailsCount ) 
{
    return  SteamEmulator.SteamUserStats.UploadLeaderboardScore(hSteamLeaderboard, eLeaderboardUploadScoreMethod, (uint)nScore, (uint)pScoreDetails, cScoreDetailsCount);
}

    public ulong AttachLeaderboardUGC(IntPtr _, ulong hSteamLeaderboard, ulong hUGC)
    {
        return SteamEmulator.SteamUserStats.AttachLeaderboardUGC(hSteamLeaderboard, hUGC);
    }

    public ulong GetNumberOfCurrentPlayers(IntPtr _)
    {
        return SteamEmulator.SteamUserStats.GetNumberOfCurrentPlayers();
    }

    public ulong RequestGlobalAchievementPercentages(IntPtr _)
    {
        return SteamEmulator.SteamUserStats.RequestGlobalAchievementPercentages();
    }

    public int GetMostAchievedAchievementInfo(IntPtr _, string pchName, uint unNameBufLen, float pflPercent, bool pbAchieved)
    {
        return SteamEmulator.SteamUserStats.GetMostAchievedAchievementInfo(pchName, unNameBufLen, pflPercent, pbAchieved);
    }

    public int GetNextMostAchievedAchievementInfo(IntPtr _, int iIteratorPrevious, string pchName, uint unNameBufLen, float pflPercent, bool pbAchieved)
    {
        return SteamEmulator.SteamUserStats.GetNextMostAchievedAchievementInfo(iIteratorPrevious, pchName, unNameBufLen, pflPercent, pbAchieved);
    }

    public bool GetAchievementAchievedPercent(IntPtr _, string pchName, float pflPercent)
    {
        return SteamEmulator.SteamUserStats.GetAchievementAchievedPercent(pchName, pflPercent);
    }

    public ulong RequestGlobalStats(IntPtr _, int nHistoryDays)
    {
        return SteamEmulator.SteamUserStats.RequestGlobalStats(nHistoryDays);
    }

    public bool GetGlobalStat(IntPtr _, string pchStatName, long pData)
    {
        return SteamEmulator.SteamUserStats.GetGlobalStat(pchStatName, (uint)pData);
    }

    public bool GetGlobalStat(IntPtr _, string pchStatName, double pData)
    {
        return SteamEmulator.SteamUserStats.GetGlobalStat(pchStatName, (uint)pData);
    }

    public int GetGlobalStatHistory(IntPtr _, string pchStatName, long pData, uint cubData)
    {
        return (int)SteamEmulator.SteamUserStats.GetGlobalStatHistory(pchStatName, (uint)pData, cubData);
    }

    public int GetGlobalStatHistory(IntPtr _, string pchStatName, double pData, uint cubData)
    {
        return (int)SteamEmulator.SteamUserStats.GetGlobalStatHistory(pchStatName, (uint)pData, cubData);
    }

    public bool GetAchievementProgressLimits(IntPtr _, string pchName, int pnMinProgress, int pnMaxProgress)
    {
        return SteamEmulator.SteamUserStats.GetAchievementProgressLimits(pchName, (uint)pnMinProgress, (uint)pnMaxProgress);
    }

    public bool GetAchievementProgressLimits(IntPtr _, string pchName, float pfMinProgress, float pfMaxProgress)
    {
        return SteamEmulator.SteamUserStats.GetAchievementProgressLimits(pchName, (uint)pfMinProgress, (uint)pfMaxProgress);
    }


}
}