﻿using Common.Application.Model;
using Common.Enums;
using HotRod.Cache;
using HotRod.Cache.Connector;
using Master.Cache.Service.MasterCache.Model;
using Master.Cache.Service.MasterCache.Repositories;
using Master.Cache.Service.MasterCache.Settings;
using Microsoft.Extensions.Options;
using Shared.Services.MasterMessage;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Master.Cache.Service.MasterCache
{
    public class MasterCacheService : IMasterCacheService
    {
        private readonly ICacheConnector _cacheConnector;
        private readonly IMasterCacheRepositories _masterCacheRepositories;
        private readonly MasterMessageService _masterMessageService;
        private readonly AppSettings _appSettings;
        private readonly MasterCacheDictionary _masterCacheDictionary;

        public MasterCacheService(ICacheConnector cacheConnector, IOptions<AppSettings> appSettings, IMasterCacheRepositories masterCacheRepositories, MasterMessageService masterMessageService, HotRodCache hotRodCache, MasterCacheDictionary masterCacheDictionary)
        {
            _cacheConnector = cacheConnector;
            _masterMessageService = masterMessageService;
            _masterCacheDictionary = masterCacheDictionary;
            _masterCacheRepositories = masterCacheRepositories;
            _appSettings = appSettings.Value;
        }

        public async Task<OutResponse> GetMasterCacheCategoryAsync(CacheRequest cacheRequest)
        {
            return await GetMasterCacheCommanCategoryAsync(cacheRequest.RequestData, cacheRequest.RequestId, MasterCahcheEnums.MASTERCACHECATEGORY);
        }

        public async Task<OutResponse> GetMasterCacheCategoryMobileAsync(CacheRequest cacheRequest)
        {
            return await GetMasterCacheCommanCategoryAsync(cacheRequest.RequestData, cacheRequest.RequestId, MasterCahcheEnums.MASTERCACHEMOBILECATEGORY);
        }

        public async Task<OutResponse> GetMasterCacheAsync(CacheRequest cacheRequest)
        {
            return await GetMasterCacheCommanCategoryAsync(cacheRequest.RequestData, cacheRequest.RequestId, MasterCahcheEnums.MASTERCACHE);
        }

        public async Task<OutResponse> GetMasterCacheZipAsync(CacheRequest cacheRequest)
        {
            return await GetMasterCacheCommanCategoryAsync(cacheRequest.RequestData, cacheRequest.RequestId, MasterCahcheEnums.MASTERCACHEZIP);
        }

        public async Task<OutResponse> ResetMasterCacheByCategoryAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MastersVersion", false, false, false, true);
        }

        public async Task<OutResponse> ResetMasterCacheByCatgoryWithOutIncVersionAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MastersVersion", false, false, false, true);
        }

        public async Task<OutResponse> ResetMasterCacheByCatgoryForMobileAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MastersVersion", true, false, true, true, true);
        }

        public async Task<OutResponse> ResetMasterCacheByCategoryForMobileWithOutIncVersionAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MastersVersion", true, false, false, true, true);
        }

        public async Task<OutResponse> ResetMasterCacheAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MobileMastersVersion", true, true, true, true, true);
        }

        public async Task<OutResponse> ResetMasterCacheWithOutVersionAsync(CacheRequest cacheRequest)
        {

            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MobileMastersVersion", true, true, false, true, true);
        }

        public async Task<OutResponse> GetVersionForMastersAsync(CacheRequest cacheRequest)
        {
            var masterStatus = await _masterCacheRepositories.GetMasterVersionAsync();
            var masterData = masterStatus.ToJsonSerialize();
            var alertMessage = masterData is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterVersionReturnSuccessFul.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterVersionReturnFailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = masterData is not null ? masterData : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = masterData is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };
            return outRespnse;
        }

        public async Task<OutResponse> ResetIndividualMasterCacheAsync(CacheRequest cacheRequest)
        {
            return await ResetIndividualMasterCacheComman(cacheRequest, true, true);
        }
        public async Task<OutResponse> ResetIndividualMasterCacheWithOutIncrementVersionAsync(CacheRequest cacheRequest)
        {
            return await ResetIndividualMasterCacheComman(cacheRequest, false, true);
        }



        #region Internal Method
        internal async Task<OutResponse> GetMasterCacheCommanCategoryAsync(string requestData, string requestId, MasterCahcheEnums masterCahcheEnums)
        {
            var data = await _masterCacheDictionary.GetMasterCacheAsync(masterCahcheEnums.GetStringValue());

            string keyCategory = string.Empty;

            var cacheResponse = new CacheResponse
            {
                CacheMaster = data is null ? await _cacheConnector.GetCache(requestData, true) : data
            };

            switch (masterCahcheEnums)
            {
                case MasterCahcheEnums.MASTERCACHEMOBILECATEGORY:
                    keyCategory = requestData.Substring(requestData.Length - 1, 1);
                    break;
                default:
                    break;
            }

            if (cacheResponse.CacheMaster is null)
            {
                switch (masterCahcheEnums)
                {
                    case MasterCahcheEnums.MASTERCACHECATEGORY:
                        //below commented funcation required impliment
                        //ResetMasterCacheByCategoryDataNullForMobileWithOutIncVer(objRequest);
                        break;
                    case MasterCahcheEnums.MASTERCACHEMOBILECATEGORY:
                        //below commented funcation required impliment
                        //ResetMasterCacheByCategoryDataNullWithOutIncVer()
                        break;
                    case MasterCahcheEnums.MASTERCACHE or MasterCahcheEnums.MASTERCACHEZIP:
                        //below commented funcation required impliment
                        //ResetIndividualMasterCacheWithOutIncVer(objRequest);
                        break;
                    default:
                        break;
                }
            }

            cacheResponse.CacheMaster = await _cacheConnector.GetCache(requestData, true);

            int.TryParse(await _cacheConnector.GetCacheVersion(requestData), out int version);

            var isMasterCacheData = requestData is "MastersCacheData" or "MastersCacheData1" or "MastersCacheData2" or "MastersCacheData3" or "MastersCacheData4" or "MastersCacheMobileData1" or "MastersCacheMobileData2" or "MastersCacheMobileData3" or "MastersCacheMobileData4" or "MastersCacheMobileData5";

            cacheResponse.VersionId = version;

            cacheResponse.MastersVersion = isMasterCacheData ? await _cacheConnector.GetCache($"MastersVersion{keyCategory}", true) : $"{requestData}#{cacheResponse.VersionId}";

            if (isMasterCacheData && string.IsNullOrEmpty(cacheResponse.MastersVersion))
            {
                switch (masterCahcheEnums)
                {
                    case MasterCahcheEnums.MASTERCACHE:
                        cacheResponse.MastersVersion = await GetMasterVersionAsync("MastersVersion");
                        break;
                    default:
                        break;
                }
            }

            _ = data is null && cacheResponse.CacheMaster is not null ? await _masterCacheDictionary.SetMasterCacheAsync(masterCahcheEnums.GetStringValue(), cacheResponse.CacheMaster) : 0;

            var alertMessage = cacheResponse.CacheMaster is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterDataFound.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterDataCouldNotFound.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = cacheResponse.CacheMaster is not null ? BitConverter.ToString(cacheResponse.ToJsonSerialize()?.Zip()).Replace("-", string.Empty) : null,
                RequestId = requestId,
                ResponseCode = cacheResponse.CacheMaster is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };

            return outRespnse;
        }

        internal async Task<OutResponse> ResetMasterCacheCommanByCategoryAsync(CacheRequest cacheRequest, string key, bool isMobile = false, bool isResetMbkMobile = false, bool isoneincrementCache = false, bool istwoincrementCache = false, bool isUpdateValue = false)
        {
            var data = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();

            string sql = string.Empty;
            bool isResult = false;
            var versionValue = string.Empty;
            var Version = 0;
            var versionData = await _masterCacheRepositories.GetMasterVersionAsync(data.Keycategory);
            int auditId;
            foreach (var vData in versionData)
            {
                sql = $"{sql}{vData.SqlQuery};";

                string versionLocalData = JsonExtensions.ToJsonSerialize(await _masterCacheRepositories.ExecuteQueryAsync(vData.SqlQuery));
                var resultLocalData = await _cacheConnector.GetCache(vData.MstTableName, true);

                auditId = resultLocalData is not null ? await _cacheConnector.RemoveCacheAuditAsync(new CacheAuditTrail { CacheKey = vData.MstTableName, IpAddress = data.Ip_Address }) : 0;
                await _cacheConnector.PutCacheAuditWithOutVersion(vData.MstTableName, versionLocalData, auditId, data.Ip_Address, isoneincrementCache);
                int.TryParse(await _cacheConnector.GetCacheVersion(vData.MstTableName), out Version);
                versionValue = $"{versionValue}{vData.MstTableName}#{Version}~";
                await _masterCacheRepositories.UpdateMasterStatusAsync(new DTo.MasterStatus { Version = Version, MstTableName = vData.MstTableName });
            }
            if (versionData is not null)
            {
                _ = await _masterCacheRepositories.ExecuteQueryAsync(sql.Remove(sql.Length - 1));
                var resultCacheData = JsonExtensions.ToJsonSerialize(await _cacheConnector.GetCache(data.CacheKey, true));
                auditId = resultCacheData is not null ? await _cacheConnector.RemoveCacheAuditAsync(new CacheAuditTrail { CacheKey = data.CacheKey, IpAddress = data.Ip_Address }) : 0;

                isResult = await _cacheConnector.PutCacheAuditWithOutVersion(data.CacheKey, isUpdateValue ? versionValue : resultCacheData, auditId, data.Ip_Address, istwoincrementCache);

                int.TryParse(await _cacheConnector.GetCacheVersion(data.CacheKey), out Version);
                await _masterCacheRepositories.UpdateMasterStatusAsync(new DTo.MasterStatus { Version = Version, MstTableName = isResetMbkMobile ? "MastersCacheData" : data.CacheKey });
            }

            var isUpdate = isResult && isMobile && !isResetMbkMobile ? await GetMasterVersionAsync(key, isMobile) : string.Empty;
            isUpdate = isResult && isMobile && isResetMbkMobile ? await GetMasterVersionMbKeyCategoryAsync(key, isMobile) : string.Empty;

            var alertMessage = isResult ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterCacheResetSuccessful.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterCacheResetfailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = isResult ? $"Master Cahce VersionId {Version}" : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = isResult ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };
            return outRespnse;
        }

        internal async Task<string> GetMasterVersionAsync(string key, bool isMobile = false, string keyCategory = null, int? mBKeyCategory = null)
        {
            string version = string.Empty;

            var data = await _masterCacheRepositories.GetMasterVersionAsync(keyCategory, mBKeyCategory);

            foreach (var cacheName in data.Select(xx => xx.CacheName))
            {

                var versionId = isMobile ? await _cacheConnector.GetCacheVersion(cacheName) : await _cacheConnector.GetCache(cacheName, true);
                version = $"{version}{cacheName}#{versionId}~";
            }

            version = version.Remove(version.Length - 1);

            if (version is not null)
            {
                //MastersVersion
                await _cacheConnector.RemoveAsync(key);
                await _cacheConnector.PutCacheAsync(key, version);
            }

            return version;
        }

        internal async Task<string> GetMasterVersionMbKeyCategoryAsync(string key, bool ismobile = false)
        {
            string version = string.Empty;
            if (_appSettings?.MobileKeyCategoryCount > 0)
            {
                for (var i = 1; i <= _appSettings?.MobileKeyCategoryCount; i++)
                {
                    version = $"{version}{await GetMasterVersionAsync($"{key}{i}", ismobile, null, i)}";
                }
            }

            return version;
        }

        internal async Task<string> UpdateMasterVersionGroupKeyCategoryAsync(CacheRequest cacheRequest)
        {
            var data = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();
            string cacheKey = data is not null ? data.CacheKey : cacheRequest.RequestData;
            var versionData = (await _masterCacheRepositories.GetMasterVersionAsync(null, null, cacheKey)).FirstOrDefault();
            return versionData?.MbKeyCategory is not 0 ? await GetMasterVersionAsync($"MobileMastersVersion{versionData?.MbKeyCategory}", true, null, versionData?.MbKeyCategory) : string.Empty;
        }

        internal async Task<OutResponse> ResetIndividualMasterCacheComman(CacheRequest cacheRequest, bool isoneincrementCache = false, bool istwoincrementCache = false)
        {
            var data = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();
            string sql = string.Empty;
            bool isResult = false;
            var versionValue = string.Empty;
            var Version = 0;
            var versionData = await _masterCacheRepositories.GetMasterVersionAsync(null, null, data.CacheKey);
            var versionAllData = versionData?.Status ? await _masterCacheRepositories.GetMasterVersionAsync() : null;
            int auditId;
            bool isUpdate = false;
            foreach (var vData in versionAllData)
            {
                sql = $"{sql}{vData.SqlQuery};";

                Version = Convert.ToInt32(await _cacheConnector.GetCacheVersion(vData.MstTableName));

                if (Version != 0 || (data.CacheKey && cacheRequest.RequestData is not "MastersCacheData"))
                {
                    isUpdate = data.CacheKey && cacheRequest.RequestData is not "MastersCacheData" ?? true;
                    string versionLocalData = JsonExtensions.ToJsonSerialize(await _masterCacheRepositories.ExecuteQueryAsync(vData.SqlQuery));
                    var resultLocalData = await _cacheConnector.GetCache(vData.MstTableName, true);
                    auditId = resultLocalData is not null ? await _cacheConnector.RemoveCacheAuditAsync(new CacheAuditTrail { CacheKey = vData.MstTableName, IpAddress = data.Ip_Address }) : 0;
                    await _cacheConnector.PutCacheAuditWithOutVersion(vData.MstTableName, versionLocalData, auditId, data.Ip_Address, isoneincrementCache);

                    await GetMasterVersionAsync("MastersVersion", true);
                    await UpdateMasterVersionGroupKeyCategoryAsync(cacheRequest);
                }
            }
            if (isUpdate)
            {
                _ = await _masterCacheRepositories.ExecuteQueryAsync(sql.Remove(sql.Length - 1));
                var resultCacheData = JsonExtensions.ToJsonSerialize(await _cacheConnector.GetCache("MastersCacheData", true));
                auditId = resultCacheData is not null ? await _cacheConnector.RemoveCacheAuditAsync(new CacheAuditTrail { CacheKey = data.CacheKey, IpAddress = data.Ip_Address }) : 0;
                isResult = await _cacheConnector.PutCacheAuditWithOutVersion("MastersCacheData", resultCacheData, auditId, data.Ip_Address, istwoincrementCache);
                int.TryParse(await _cacheConnector.GetCacheVersion("MastersCacheData"), out Version);
                await _masterCacheRepositories.UpdateMasterStatusAsync(new DTo.MasterStatus { Version = Version, MstTableName = "MastersCacheData" });

            }
            if (!versionData?.Status && (data.CacheKey && cacheRequest.RequestData is not "MastersCacheData"))
            {
                string versionLocalData = JsonExtensions.ToJsonSerialize(await _masterCacheRepositories.ExecuteQueryAsync(versionData.SqlQuery));
                var resultCacheData = await _cacheConnector.GetCache("MastersCacheData", true);
                auditId = resultCacheData is not null ? await _cacheConnector.RemoveCacheAuditAsync(new CacheAuditTrail { CacheKey = versionData.MstTableName, IpAddress = data.Ip_Address }) : 0;
                isResult = await _cacheConnector.PutCacheAuditWithOutVersion(versionData.MstTableName, versionLocalData, auditId, data.Ip_Address, istwoincrementCache);
                int.TryParse(await _cacheConnector.GetCacheVersion(versionData.MstTableName), out Version);
                await _masterCacheRepositories.UpdateMasterStatusAsync(new DTo.MasterStatus { Version = Version, MstTableName = versionData.MstTableName });
            }
            if (isUpdate || (!versionData?.Status && (data.CacheKey && cacheRequest.RequestData is not "MastersCacheData")))
            {
                await GetMasterVersionAsync("MastersVersion", true);
                await UpdateMasterVersionGroupKeyCategoryAsync(cacheRequest);
            }

            var alertMessage = isResult ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterCacheResetSuccessful.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterCacheResetfailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = isResult ? $"{cacheRequest.RequestData} Cache updated " : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = isResult ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };
            return outRespnse;
        }

        #endregion

    }
}
