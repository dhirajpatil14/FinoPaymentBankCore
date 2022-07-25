using Common.Application.Model;
using Common.Application.Model.Settings;
using Common.Enums;
using Data.Db.Service.Interface;
using HotRod.Cache;
using HotRod.Cache.Connector;
using Master.Cache.Service.MasterCache.Model;
using Microsoft.Extensions.Options;
using Shared.Services.ESBMessageService;

using Shared.Services.MasterMessage;
using SQL.Helper;
using System;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Master.Cache.Service.MasterCache
{
    public class MasterCacheService : IMasterCacheService
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly SqlConnectionStrings _sqlConnectionStrings;
        private readonly HotRodCache _hotRodCache;
        private readonly ICacheConnector _cacheConnector;
        private readonly EsbMessageService _esbMessageService;
        private readonly MasterMessageService _masterMessageService;
        private readonly AppSettings _appSettings;

        public MasterCacheService(IDataDbConfigurationService dataDbConfigurationService, ICacheConnector cacheConnector, IOptions<SqlConnectionStrings> sqlConnection, IOptions<AppSettings> appSettings, EsbMessageService esbMessageService, MasterMessageService masterMessageService, HotRodCache hotRodCache)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnection.Value;
            _hotRodCache = hotRodCache;
            _cacheConnector = cacheConnector;
            _esbMessageService = esbMessageService;
            _masterMessageService = masterMessageService;
            _appSettings = appSettings.Value;
        }

        public async Task<OutResponse> GetMasterCacheCategoryAsync(CacheRequest cacheRequest)
        {
            var cacheResponse = new CacheResponse();
            var cacheData = await _cacheConnector.GetCache(cacheRequest.RequestData, true);
            cacheResponse.CacheMaster = cacheData.ToJsonDeSerialize<dynamic>();

            if (cacheResponse.CacheMaster is null)
            {
                //below commented funcation required impliment
                //ResetMasterCacheByCategoryDataNullWithOutIncVer()
            }

            cacheResponse.CacheMaster = await _cacheConnector.GetCache(cacheRequest.RequestData, true);

            int.TryParse(await _cacheConnector.GetCacheVersion(cacheRequest.RequestData), out int version);
            cacheResponse.VersionId = version;
            cacheResponse.MastersVersion = cacheRequest.RequestData is "MastersCacheData1" or "MastersCacheData2" or "MastersCacheData3" or "MastersCacheData4" ? await _cacheConnector.GetCache("MastersVersion", true) : $"{cacheRequest.RequestData}#{cacheResponse.VersionId}";

            var alertMessage = cacheResponse.CacheMaster is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterDataFound.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MasterDataCouldNotFound.GetIntValue());


            var outRespnse = new OutResponse
            {
                ResponseData = cacheResponse.CacheMaster is not null ? BitConverter.ToString(cacheResponse.ToJsonSerialize()?.Zip()).Replace("-", string.Empty) : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = cacheResponse.CacheMaster is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };

            return outRespnse;

        }

        public Task<OutResponse> GetMasterCacheCategoryMobileAsync(CacheRequest cacheRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<OutResponse> GetMasterCacheAsync(CacheRequest cacheRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<OutResponse> GetMasterCacheZipAsync(CacheRequest cacheRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<OutResponse> ResetMasterCacheByCategoryAsync(CacheRequest cacheRequest)
        {
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

    }
}
