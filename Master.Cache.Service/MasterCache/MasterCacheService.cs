using Common.Application.Model;
using Common.Application.Model.Settings;
using Common.Enums;
using HotRod.Cache;
using HotRod.Cache.Connector;
using Master.Cache.Service.MasterCache.Model;
using Master.Cache.Service.MasterCache.Repositories;
using Microsoft.Extensions.Options;

using Shared.Services.MasterMessage;
using System;
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
            var data = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();
            string cacheKey = Convert.ToString(data.CacheKey);
            string ipAddress = Convert.ToString(data.Ip_Address);
            string keyCategory = data.Keycategory;
            string sql = string.Empty;
            bool isResult = false;

            var versionData = await _masterCacheRepositories.GetMasterVersionAsync(keyCategory);

            foreach (var vData in versionData)
            {
                sql = $"{sql}{vData.SqlQuery};";

                string versionLocalData = JsonExtensions.ToJsonSerialize(await _masterCacheRepositories.ExecuteQueryAsync(vData.SqlQuery));
                var resultLocalData = await _cacheConnector.GetCache(vData.MstTableName, true);
                var auditId = 0;
                if (resultLocalData is not null)
                {
                    auditId = await _cacheConnector.RemoveCacheAuditAsync(new CacheAuditTrail { CacheKey = vData.MstTableName, IpAddress = ipAddress });
                }
                await _cacheConnector.PutCacheAuditWithOutVersion(vData.MstTableName, versionLocalData, auditId, ipAddress);
                isResult = true;
                //line 726

            }


            throw new System.NotImplementedException();
        }

        public Task<OutResponse> ResetMasterCacheByCatgoryWithOutIncVersionAsync(CacheRequest cacheRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<OutResponse> ResetMasterCacheByCatgoryForMobileAsync(CacheRequest cacheRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<OutResponse> ResetMasterCacheByCategoryForMobileWithOutIncVersionAsync(CacheRequest cacheRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<OutResponse> ResetMasterCache(CacheRequest cacheRequest)
        {
            throw new System.NotImplementedException();
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
                        cacheResponse.MastersVersion = await GetMasterVersionAsync();
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

        internal async Task<string> GetMasterVersionAsync()
        {
            string version = string.Empty;

            var data = await _masterCacheRepositories.GetMasterVersionAsync();

            foreach (var value in data)
            {
                var versionId = await _cacheConnector.GetCache(value.CacheName, true);
                version = $"{version}{value.CacheName}#{versionId}~";
            }

            version = version.Remove(version.Length - 1);

            if (version is not null)
            {
                await _cacheConnector.RemoveAsync("MastersVersion");
                await _cacheConnector.PutCacheAsync("MastersVersion", version);
            }

            return version;
        }

        #endregion

    }
}
