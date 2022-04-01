﻿using SKYNET;
using SKYNET.Steamworks;
using Steamworks;
using System;

public class SteamUGC : SteamInterface
{
    public UGCQueryHandle_t CreateQueryUserUGCRequest(IntPtr _, IntPtr unAccountID, IntPtr eListType, int eMatchingUGCType, int eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage)
    {
        Write("CreateQueryUserUGCRequest");
        return default;
    }

    public UGCQueryHandle_t CreateQueryAllUGCRequest(IntPtr _, int eQueryType, int eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage)
    {
        Write("CreateQueryAllUGCRequest");
        return default;
    }

    public UGCQueryHandle_t CreateQueryUGCDetailsRequest(IntPtr _, PublishedFileId_t pvecPublishedFileID, uint unNumPublishedFileIDs)
    {
        Write("CreateQueryUGCDetailsRequest");
        return default;
    }

    public SteamAPICall_t SendQueryUGCRequest(IntPtr _, UGCQueryHandle_t handle)
    {
        Write("SendQueryUGCRequest");
        return default;
    }

    public bool GetQueryUGCResult(IntPtr _, UGCQueryHandle_t handle, uint index, IntPtr pDetails)
    {
        Write("GetQueryUGCResult");
        return false;
    }

    public bool GetQueryUGCPreviewURL(IntPtr _, UGCQueryHandle_t handle, uint index, string pchURL, uint cchURLSize)
    {
        Write("GetQueryUGCPreviewURL");
        return false;
    }

    public bool GetQueryUGCMetadata(IntPtr _, UGCQueryHandle_t handle, uint index, string pchMetadata, uint cchMetadatasize)
    {
        Write("GetQueryUGCMetadata");
        return false;
    }

    public bool GetQueryUGCChildren(IntPtr _, UGCQueryHandle_t handle, uint index, PublishedFileId_t pvecPublishedFileID, uint cMaxEntries)
    {
        Write("GetQueryUGCChildren");
        return false;
    }

    public bool GetQueryUGCStatistic(IntPtr _, UGCQueryHandle_t handle, uint index, EItemStatistic eStatType, uint pStatValue)
    {
        Write("GetQueryUGCStatistic");
        return false;
    }

    public uint GetQueryUGCNumAdditionalPreviews(IntPtr _, UGCQueryHandle_t handle, uint index)
    {
        Write("GetQueryUGCNumAdditionalPreviews");
        return 0;
    }

    public bool GetQueryUGCAdditionalPreview(IntPtr _, UGCQueryHandle_t handle, uint index, uint previewIndex, string pchURLOrVideoID, uint cchURLSize, string pchOriginalFileName, uint cchOriginalFileNameSize, EItemPreviewType pPreviewType)
    {
        Write("GetQueryUGCAdditionalPreview");
        return false;
    }

    public uint GetQueryUGCNumKeyValueTags(IntPtr _, UGCQueryHandle_t handle, uint index)
    {
        Write("GetQueryUGCNumKeyValueTags");
        return 0;
    }

    public bool GetQueryUGCKeyValueTag(IntPtr _, UGCQueryHandle_t handle, uint index, uint keyValueTagIndex, string pchKey, uint cchKeySize, string pchValue, uint cchValueSize)
    {
        Write("GetQueryUGCKeyValueTag");
        return false;
    }


    public bool ReleaseQueryUGCRequest(IntPtr _, UGCQueryHandle_t handle)
    {
        Write("ReleaseQueryUGCRequest");
        return false;
    }

    public bool AddRequiredTag(IntPtr _, UGCQueryHandle_t handle, string pTagName)
    {
        Write("AddRequiredTag");
        return false;
    }

    public bool AddRequiredTagGroup(IntPtr _, UGCQueryHandle_t handle, IntPtr pTagGroups) // match any of the tags in this group 
    {
        Write("AddRequiredTagGroup");
        return false;
    }

    public bool AddExcludedTag(IntPtr _, UGCQueryHandle_t handle, string pTagName)
    {
        Write("AddExcludedTag");
        return false;
    }

    public bool SetReturnOnlyIDs(IntPtr _, UGCQueryHandle_t handle, bool bReturnOnlyIDs)
    {
        Write("SetReturnOnlyIDs");
        return false;
    }

    public bool SetReturnKeyValueTags(IntPtr _, UGCQueryHandle_t handle, bool bReturnKeyValueTags)
    {
        Write("SetReturnKeyValueTags");
        return false;
    }

    public bool SetReturnLongDescription(IntPtr _, UGCQueryHandle_t handle, bool bReturnLongDescription)
    {
        Write("SetReturnLongDescription");
        return false;
    }

    public bool SetReturnMetadata(IntPtr _, UGCQueryHandle_t handle, bool bReturnMetadata)
    {
        Write("SetReturnMetadata");
        return false;
    }

    public bool SetReturnChildren(IntPtr _, UGCQueryHandle_t handle, bool bReturnChildren)
    {
        Write("SetReturnChildren");
        return false;
    }

    public bool SetReturnAdditionalPreviews(IntPtr _, UGCQueryHandle_t handle, bool bReturnAdditionalPreviews)
    {
        Write("SetReturnAdditionalPreviews");
        return false;
    }

    public bool SetReturnTotalOnly(IntPtr _, UGCQueryHandle_t handle, bool bReturnTotalOnly)
    {
        Write("SetReturnTotalOnly");
        return false;
    }

    public bool SetReturnPlaytimeStats(IntPtr _, UGCQueryHandle_t handle, uint unDays)
    {
        Write("SetReturnPlaytimeStats");
        return false;
    }

    public bool SetLanguage(IntPtr _, UGCQueryHandle_t handle, string pchLanguage)
    {
        Write("SetLanguage");
        return false;
    }

    public bool SetAllowCachedResponse(IntPtr _, UGCQueryHandle_t handle, uint unMaxAgeSeconds)
    {
        Write("SetAllowCachedResponse");
        return false;
    }

    public bool SetCloudFileNameFilter(IntPtr _, UGCQueryHandle_t handle, string pMatchCloudFileName)
    {
        Write("SetCloudFileNameFilter");
        return false;
    }

    public bool SetMatchAnyTag(IntPtr _, UGCQueryHandle_t handle, bool bMatchAnyTag)
    {
        Write("SetMatchAnyTag");
        return false;
    }

    public bool SetSearchText(IntPtr _, UGCQueryHandle_t handle, string pSearchText)
    {
        Write("SetSearchText");
        return false;
    }

    public bool SetRankedByTrendDays(IntPtr _, UGCQueryHandle_t handle, uint unDays)
    {
        Write("SetRankedByTrendDays");
        return false;
    }

    public bool AddRequiredKeyValueTag(IntPtr _, UGCQueryHandle_t handle, string pKey, string pValue)
    {
        Write("AddRequiredKeyValueTag");
        return false;
    }

    public SteamAPICall_t RequestUGCDetails(IntPtr _, PublishedFileId_t nPublishedFileID, uint unMaxAgeSeconds)
    {
        Write("RequestUGCDetails");
        return default;
    }

    public SteamAPICall_t CreateItem(IntPtr _, AppId_t nConsumerAppId, EWorkshopFileType eFileType) // create new item for this app with no content attached yet 
    {
        Write("CreateItem");
        return default;
    }

    public UGCUpdateHandle_t StartItemUpdate(IntPtr _, AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID) // start an UGC item update. Set changed properties before commiting update with CommitItemUpdate(IntPtr _) 
    {
        Write("StartItemUpdate");
        return default;
    }

    public bool SetItemTitle(IntPtr _, UGCUpdateHandle_t handle, string pchTitle) // change the title of an UGC item 
    {
        Write("SetItemTitle");
        return false;
    }

    public bool SetItemDescription(IntPtr _, UGCUpdateHandle_t handle, string pchDescription) // change the description of an UGC item 
    {
        Write("SetItemDescription");
        return false;
    }

    public bool SetItemUpdateLanguage(IntPtr _, UGCUpdateHandle_t handle, string pchLanguage) // specify the language of the title or description that will be set 
    {
        Write("SetItemUpdateLanguage");
        return false;
    }

    public bool SetItemMetadata(IntPtr _, UGCUpdateHandle_t handle, string pchMetaData) // change the metadata of an UGC item (IntPtr _, max = k_cchDeveloperMetadataMax) 
    {
        Write("SetItemMetadata");
        return false;
    }

    public bool SetItemVisibility(IntPtr _, UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility) // change the visibility of an UGC item 
    {
        Write("SetItemVisibility");
        return false;
    }

    public bool SetItemTags(IntPtr _, UGCUpdateHandle_t updateHandle, IntPtr pTags) // change the tags of an UGC item 
    {
        Write("SetItemTags");
        return false;
    }

    public bool SetItemContent(IntPtr _, UGCUpdateHandle_t handle, string pszContentFolder) // update item content from this local folder 
    {
        Write("SetItemContent");
        return false;
    }

    public bool SetItemPreview(IntPtr _, UGCUpdateHandle_t handle, string pszPreviewFile) //  change preview image file for this item. pszPreviewFile points to local image file, which must be under 1MB in size 
    {
        Write("SetItemPreview");
        return false;
    }

    public bool SetAllowLegacyUpload(IntPtr _, UGCUpdateHandle_t handle, bool bAllowLegacyUpload) //  use legacy upload for a single small file. The parameter to SetItemContent(IntPtr _) should either be a directory with one file or the full path to the file.  The file must also be less than 10MB in size. 
    {
        Write("SetAllowLegacyUpload");
        return false;
    }

    public bool RemoveAllItemKeyValueTags(IntPtr _, UGCUpdateHandle_t handle) // remove all existing key-value tags (IntPtr _, you can add new ones via the AddItemKeyValueTag function) 
    {
        Write("RemoveAllItemKeyValueTags");
        return false;
    }

    public bool RemoveItemKeyValueTags(IntPtr _, UGCUpdateHandle_t handle, string pchKey) // remove any existing key-value tags with the specified key 
    {
        Write("RemoveItemKeyValueTags");
        return false;
    }

    public bool AddItemKeyValueTag(IntPtr _, UGCUpdateHandle_t handle, string pchKey, string pchValue) // add new key-value tags for the item. Note that there can be multiple values for a tag. 
    {
        Write("AddItemKeyValueTag");
        return false;
    }

    public bool AddItemPreviewFile(IntPtr _, UGCUpdateHandle_t handle, string pszPreviewFile, EItemPreviewType type) //  add preview file for this item. pszPreviewFile points to local file, which must be under 1MB in size 
    {
        Write("AddItemPreviewFile");
        return false;
    }

    public bool AddItemPreviewVideo(IntPtr _, UGCUpdateHandle_t handle, string pszVideoID) //  add preview video for this item 
    {
        Write("AddItemPreviewVideo");
        return false;
    }

    public bool UpdateItemPreviewFile(IntPtr _, UGCUpdateHandle_t handle, uint index, string pszPreviewFile) //  updates an existing preview file for this item. pszPreviewFile points to local file, which must be under 1MB in size 
    {
        Write("UpdateItemPreviewFile");
        return false;
    }

    public bool UpdateItemPreviewVideo(IntPtr _, UGCUpdateHandle_t handle, uint index, string pszVideoID) //  updates an existing preview video for this item 
    {
        Write("UpdateItemPreviewVideo");
        return false;
    }

    public bool RemoveItemPreview(IntPtr _, UGCUpdateHandle_t handle, uint index) // remove a preview by index starting at 0 (IntPtr _, previews are sorted) 
    {
        Write("RemoveItemPreview");
        return false;
    }

    public SteamAPICall_t SubmitItemUpdate(IntPtr _, UGCUpdateHandle_t handle, string pchChangeNote) // commit update process started with StartItemUpdate(IntPtr _) 
    {
        Write("SubmitItemUpdate");
        return default;
    }

    public int GetItemUpdateProgress(IntPtr _, UGCUpdateHandle_t handle, uint punBytesProcessed, uint punBytesTotal)
    {
        Write("GetItemUpdateProgress");
        return 0;
    }

    public SteamAPICall_t SetUserItemVote(IntPtr _, PublishedFileId_t nPublishedFileID, bool bVoteUp)
    {
        Write("SetUserItemVote");
        return default;
    }

    public SteamAPICall_t GetUserItemVote(IntPtr _, PublishedFileId_t nPublishedFileID)
    {
        Write("GetUserItemVote");
        return default;
    }

    public SteamAPICall_t AddItemToFavorites(IntPtr _, AppId_t nAppId, PublishedFileId_t nPublishedFileID)
    {
        Write("AddItemToFavorites");
        return default;
    }

    public SteamAPICall_t RemoveItemFromFavorites(IntPtr _, AppId_t nAppId, PublishedFileId_t nPublishedFileID)
    {
        Write("RemoveItemFromFavorites");
        return default;
    }

    public SteamAPICall_t SubscribeItem(IntPtr _, PublishedFileId_t nPublishedFileID) // subscribe to this item, will be installed ASAP 
    {
        Write("SubscribeItem");
        return default;
    }

    public SteamAPICall_t UnsubscribeItem(IntPtr _, PublishedFileId_t nPublishedFileID) // unsubscribe from this item, will be uninstalled after game quits 
    {
        Write("UnsubscribeItem");
        return default;
    }

    public uint GetNumSubscribedItems(IntPtr _) // number of subscribed items  
    {
        Write("GetNumSubscribedItems");
        return 0;
    }

    public uint GetSubscribedItems(IntPtr _, PublishedFileId_t pvecPublishedFileID, uint cMaxEntries) // all subscribed item PublishFileIDs 
    {
        Write("GetSubscribedItems");
        return 0;
    }

    public uint GetItemState(IntPtr _, PublishedFileId_t nPublishedFileID)
    {
        Write("GetItemState");
        return 0;
    }

    public bool GetItemInstallInfo(IntPtr _, PublishedFileId_t nPublishedFileID, uint punSizeOnDisk, string pchFolder, uint cchFolderSize, uint punTimeStamp)
    {
        Write("GetItemInstallInfo");
        return false;
    }

    public bool GetItemDownloadInfo(IntPtr _, PublishedFileId_t nPublishedFileID, uint punBytesDownloaded, uint punBytesTotal)
    {
        Write("GetItemDownloadInfo");
        return false;
    }

    public bool DownloadItem(IntPtr _, PublishedFileId_t nPublishedFileID, bool bHighPriority)
    {
        Write("DownloadItem");
        return false;
    }

    public bool BInitWorkshopForGameServer(IntPtr _, uint unWorkshopDepotID, string pszFolder)
    {
        Write("BInitWorkshopForGameServer");
        return false;
    }

    public void SuspendDownloads(IntPtr _, bool bSuspend)
    {
        Write("SuspendDownloads");
        //
    }

    public SteamAPICall_t StartPlaytimeTracking(IntPtr _, PublishedFileId_t pvecPublishedFileID, uint unNumPublishedFileIDs)
    {
        Write("StartPlaytimeTracking");
        return default;
    }

    public SteamAPICall_t StopPlaytimeTracking(IntPtr _, PublishedFileId_t pvecPublishedFileID, uint unNumPublishedFileIDs)
    {
        Write("StopPlaytimeTracking");
        return default;
    }

    public SteamAPICall_t StopPlaytimeTrackingForAllItems(IntPtr _)
    {
        Write("StopPlaytimeTrackingForAllItems");
        return default;
    }

    public SteamAPICall_t AddDependency(IntPtr _, PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID)
    {
        Write("AddDependency");
        return default;
    }

    public SteamAPICall_t RemoveDependency(IntPtr _, PublishedFileId_t nParentPublishedFileID, PublishedFileId_t nChildPublishedFileID)
    {
        Write("RemoveDependency");
        return default;
    }

    public SteamAPICall_t AddAppDependency(IntPtr _, PublishedFileId_t nPublishedFileID, AppId_t nAppID)
    {
        Write("AddAppDependency");
        return default;
    }

    public SteamAPICall_t RemoveAppDependency(IntPtr _, PublishedFileId_t nPublishedFileID, AppId_t nAppID)
    {
        Write("RemoveAppDependency");
        return default;
    }

    public SteamAPICall_t GetAppDependencies(IntPtr _, PublishedFileId_t nPublishedFileID)
    {
        Write("GetAppDependencies");
        return default;
    }

    public SteamAPICall_t DeleteItem(IntPtr _, PublishedFileId_t nPublishedFileID)
    {
        Write("DeleteItem");
        return default;
    }


    private void Write(string v)
    {
        Main.Write(InterfaceVersion, v);
    }
}