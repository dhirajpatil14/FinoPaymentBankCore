using Common.Application.Interface;
using Common.Application.Model;
using Common.Enums;
using HotRod.Cache.Connector;
using Master.Cache.Service.MasterCache.DTo;
using Master.Cache.Service.MasterCache.Model;
using Master.Cache.Service.MasterCache.Repositories;
using Master.Cache.Service.MasterCache.Settings;
using Microsoft.Extensions.Options;
using Shared.Services.MasterMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Extensions;
namespace Master.Cache.Service.MasterCache
{
    public class MasterCacheService : IMasterCacheService
    {
        private readonly ICacheConnector _cacheConnector;
        private readonly IMasterCacheRepositories _masterCacheRepositories;
        private readonly IEkycAuaService _ekycAuaService;
        private readonly MasterMessageService _masterMessageService;
        private readonly AppSettings _appSettings;


        /// <summary>
        /// This constructor is depandancy injection to inject imidiate object 
        /// </summary>
        /// <param name="cacheConnector">Cache Service Connector</param>
        /// <param name="appSettings">Application Settings</param>
        /// <param name="masterCacheRepositories">Master Cache Repositories</param>
        /// <param name="ekycAuaService">Ekyc Service</param>
        /// <param name="masterMessageService">Master Message Servie</param>
        /// <param name="hotRodCache">Server side HotRod Cache</param>
        /// <param name="masterCacheDictionary">Master Cache Dictionary</param>
        public MasterCacheService(ICacheConnector cacheConnector, IOptions<AppSettings> appSettings, IMasterCacheRepositories masterCacheRepositories, IEkycAuaService ekycAuaService, MasterMessageService masterMessageService)
        {
            _cacheConnector = cacheConnector;
            _masterMessageService = masterMessageService;
            _ekycAuaService = ekycAuaService;
            _masterCacheRepositories = masterCacheRepositories;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Master Cache Response by key Name for DIVIDED category
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetMasterCacheCategoryAsync(CacheRequest cacheRequest)
        {
            return await GetMasterCacheCommanCategoryAsync(cacheRequest.RequestData, cacheRequest.RequestId, MasterCahcheEnums.MASTERCACHECATEGORY);
        }
        /// <summary>
        /// Master Cache Response by key Name for DIVIDED category for mobile
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetMasterCacheCategoryMobileAsync(CacheRequest cacheRequest)
        {
            return await GetMasterCacheCommanCategoryAsync(cacheRequest.RequestData, cacheRequest.RequestId, MasterCahcheEnums.MASTERCACHEMOBILECATEGORY);
        }
        /// <summary>
        /// Master Cache Response by key Name
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetMasterCacheAsync(CacheRequest cacheRequest)
        {
            return await GetMasterCacheCommanCategoryAsync(cacheRequest.RequestData, cacheRequest.RequestId, MasterCahcheEnums.MASTERCACHE);
        }
        /// <summary>
        /// Master Cache Response by key Name
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetMasterCacheZipAsync(CacheRequest cacheRequest)
        {
            return await GetMasterCacheCommanCategoryAsync(cacheRequest.RequestData, cacheRequest.RequestId, MasterCahcheEnums.MASTERCACHEZIP);
        }
        /// <summary>
        /// Master Cache Response by key Name divided by category
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> ResetMasterCacheByCategoryAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MastersVersion", false, false, false, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> ResetMasterCacheByCatgoryWithOutIncVersionAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MastersVersion", false, false, false, true);
        }
        /// <summary>
        /// Master Cache Response by key Name divided by category for mobile
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> ResetMasterCacheByCatgoryForMobileAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MastersVersion", true, false, true, true, true);
        }
        /// <summary>
        /// Master Cache Response by key Name divided by category for mobile without increment version
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> ResetMasterCacheByCategoryForMobileWithOutIncVersionAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MastersVersion", true, false, false, true, true);
        }
        /// <summary>
        /// Reset Master Data
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> ResetMasterCacheAsync(CacheRequest cacheRequest)
        {
            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MobileMastersVersion", true, true, true, true, true);
        }
        /// <summary>
        /// Reset Master Data without increment version
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> ResetMasterCacheWithOutVersionAsync(CacheRequest cacheRequest)
        {

            return await ResetMasterCacheCommanByCategoryAsync(cacheRequest, "MobileMastersVersion", true, true, false, true, true);
        }
        /// <summary>
        /// Get version from DataBase 
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetVersionForMastersAsync(CacheRequest cacheRequest)
        {

            var masterStatus = await _masterCacheRepositories.GetMasterVersionAsync(new MasterStatus { Status = true });
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
        /// <summary>
        /// update Individual Master Cache Response by request key Name with All Master
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> ResetIndividualMasterCacheAsync(CacheRequest cacheRequest)
        {
            return await ResetIndividualMasterCacheComman(cacheRequest, true, true);
        }
        /// <summary>
        /// update Individual Master Cache Response by request key Name with All Master without increment version
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> ResetIndividualMasterCacheWithOutIncrementVersionAsync(CacheRequest cacheRequest)
        {
            return await ResetIndividualMasterCacheComman(cacheRequest, false, true);
        }
        /// <summary>
        /// Product Profile controls
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetProfileFeatureControlsAsync(CacheRequest cacheRequest)
        {
            var data = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();

            bool isValid = (data.Ekyc is "" && data.ProductType is "") || (data.ProductType is not "");

            var productFeatureDetailsData = await _cacheConnector.GetCache($"MobileTabCntrl" + data.ProductType is not "" ? data.ProductType : string.Empty, true);
            var productFeatureDetails = productFeatureDetailsData.ToJsonDeSerialize<dynamic>();

            productFeatureDetails = productFeatureDetails is null && isValid ? await ProfileControlsDataAsync(data.ProductType, data.ChannelID, data.ekyc) : null;
            _ = productFeatureDetails is null && isValid && await _cacheConnector.PutCacheMasterAsync($"MobileTabCntrl" + data.ProductType is not "" ? data.ProductType : string.Empty, productFeatureDetails.ToJsonSerialize());


            var alertMessage = productFeatureDetails is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.TabControlsReturnSuccessFul.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.TabControlsReturnFailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = productFeatureDetails is not null ? productFeatureDetails.ToJsonSerialize() : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = productFeatureDetails is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };
            return outRespnse;
        }
        /// <summary>
        /// Product Profile controls 
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetProfileFeatureControlsAppChannelAsync(CacheRequest cacheRequest)
        {
            var data = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();
            bool isValid = (data.Ekyc is "" && data.ProductType is "") || (data.ProductType is not "");
            var productFeatureDetailsData = await _cacheConnector.GetCache($"MobileTabCntrl" + data.ProductType is not "" ? data.ProductType + data.AppChannelID : data.AppChannelID, true);
            var productFeatureDetails = productFeatureDetailsData.ToJsonDeSerialize<dynamic>();
            productFeatureDetails = productFeatureDetails is null && isValid ? await ProfileControlsDataAsync(data.ProductType, data.ChannelID, data.ekyc, Convert.ToString(data.AppChannelID)) : null;
            _ = productFeatureDetails is null && isValid && await _cacheConnector.PutCacheMasterAsync($"MobileTabCntrl" + data.ProductType is not "" ? data.ProductType + data.AppChannelID : data.AppChannelID, productFeatureDetails.ToJsonSerialize());

            var alertMessage = productFeatureDetails is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.TabControlsReturnSuccessFul.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.TabControlsReturnFailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = productFeatureDetails is not null ? productFeatureDetails.ToJsonSerialize() : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = productFeatureDetails is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };

            return outRespnse;
        }
        /// <summary>
        /// Sequence with producttype, channelid, ekyc/Normal ekyc
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetSequencesAsync(CacheRequest cacheRequest)
        {
            return await GetSequenceAsync(cacheRequest);
        }
        /// <summary>
        /// Sequence with producttype, channelid, ekyc/Normal ekyc
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetSequencesAppChannelAsync(CacheRequest cacheRequest)
        {
            return await GetSequenceAsync(cacheRequest, true);
        }
        /// <summary>
        /// public key from db
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetPublicKeyAsync(CacheRequest cacheRequest)
        {
            var masterAuaData = await _ekycAuaService.GetMasterAuaAsync(new MasterAua { Status = true, Id = 11 });

            var alertMessage = masterAuaData is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.PublicKeySendSuccess.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.PublicKeySendFailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = masterAuaData is not null ? masterAuaData.ToJsonSerialize() : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = masterAuaData is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };
            return outRespnse;
        }
        /// <summary>
        /// MenuList by Channel
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetMenuByChannelAsync(CacheRequest cacheRequest)
        {
            var menuRequestData = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();
            var menuCacheData = await _cacheConnector.GetCache($"ProfileTypeDataMenu{menuRequestData.UserTypeID}{menuRequestData.ChannelID}", true);
            IEnumerable<RoleMenu> roleMenus = null;
            if (menuCacheData is null)
            {
                roleMenus = await _masterCacheRepositories.GetRoleBasedMenuAsync(menuRequestData.UserTypeID, menuRequestData.ChannelID);
                await _cacheConnector.PutCacheMasterAsync($"ProfileTypeDataMenu{menuRequestData.UserTypeID}{menuRequestData.ChannelID}", roleMenus.ToJsonSerialize());
            }
            roleMenus = roleMenus is null ? menuCacheData.ToJsonDeSerialize<IEnumerable<RoleMenu>>() : roleMenus;
            roleMenus = menuRequestData.FormID is not null ? roleMenus.Where(xx => xx.FormId == Convert.ToInt32(menuRequestData.FormID)) : roleMenus;

            var alertMessage = roleMenus is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MenuListByChannelSentSuccess.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.MenuListByChannelFailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = roleMenus is not null ? roleMenus.ToJsonSerialize() : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = roleMenus is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };
            return outRespnse;
        }
        /// <summary>
        /// profile Type TransactionAuth and Product mapping by Channel ID
        /// </summary>
        /// <param name="cacheRequest"></param>
        /// <returns></returns>
        public async Task<OutResponse> GetProfileTypeTransByChannelAsync(CacheRequest cacheRequest)
        {
            var masterRequestData = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();
            var masterCacheData = await _cacheConnector.GetCache($"ProfileTypeMasterData{masterRequestData.UserTypeID}{masterRequestData.ChannelID}", true);
            var profileType = masterCacheData is not null ? masterCacheData.ToJsonDeSerialize<ProfileType>() : null;

            var profileUpdatedTypes = profileType is null ? await _masterCacheRepositories.ProfileTypeDictionaryAsync(masterRequestData?.UserTypeID, masterRequestData?.ChannelID) : null;

            _ = profileUpdatedTypes is not null && await _cacheConnector.PutCacheMasterAsync($"ProfileTypeMasterData{masterRequestData.UserTypeID}{masterRequestData.ChannelID}", profileUpdatedTypes.ToJsonSerialize());

            profileType = profileUpdatedTypes is not null ? profileUpdatedTypes : profileType;

            var responseData = profileType is not null && masterRequestData.productTypeID is null or "" ? profileType.ToJsonSerialize() : masterRequestData.TransactionTypeID is not null or "" ? (profileType.ProfileTransaction.Where(xx => xx.ProductTypeID == masterRequestData.productTypeID && xx.TransactionTypeID == masterRequestData.TransactionTypeID)).ToJsonSerialize() : (profileType.ProfileTransaction.Where(xx => xx.ProductTypeID == masterRequestData.productTypeID)).ToJsonSerialize();


            var alertMessage = profileType is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.ProfileTypeTransByChannelSuccess.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.ProfileTypeTransByChannelFailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = responseData is not null or "" ? responseData : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = profileType is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };
            return outRespnse;
        }

        #region Internal Method
        internal async Task<OutResponse> GetMasterCacheCommanCategoryAsync(string requestData, string requestId, MasterCahcheEnums masterCahcheEnums)
        {

            string keyCategory = string.Empty;

            var cacheResponse = new CacheResponse
            {
                CacheMaster = await _cacheConnector.GetCache(requestData, true)
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
            var versionData = await _masterCacheRepositories.GetMasterVersionAsync(new MasterStatus { KeyCategory = data.Keycategory });

            int auditId = 0;



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

                if (resultCacheData is not null)
                {
                    auditId = resultCacheData is not null ? await _cacheConnector.RemoveCacheAuditAsync(new CacheAuditTrail { CacheKey = data.CacheKey, IpAddress = data.Ip_Address }) : 0;
                }

                isResult = await _cacheConnector.PutCacheAuditWithOutVersion(data.CacheKey, isUpdateValue ? versionValue : resultCacheData, auditId, data.Ip_Address, istwoincrementCache);

                int.TryParse(await _cacheConnector.GetCacheVersion(data.CacheKey), out Version);

                await _masterCacheRepositories.UpdateMasterStatusAsync(new DTo.MasterStatus { Version = Version, MstTableName = isResetMbkMobile ? "MastersCacheData" : data.CacheKey });
            }

            _ = isResult && isMobile && !isResetMbkMobile ? await GetMasterVersionAsync(key, isMobile) : string.Empty;

            _ = isResult && isMobile && isResetMbkMobile ? await GetMasterVersionMbKeyCategoryAsync(key, isMobile) : string.Empty;

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

            var data = await _masterCacheRepositories.GetMasterVersionAsync(new MasterStatus { KeyCategory = keyCategory, MbKeyCategory = mBKeyCategory });

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
            var versionData = (await _masterCacheRepositories.GetMasterVersionAsync(new MasterStatus { MstTableName = cacheKey })).FirstOrDefault();
            return versionData?.MbKeyCategory is not 0 ? await GetMasterVersionAsync($"MobileMastersVersion{versionData?.MbKeyCategory}", true, null, versionData?.MbKeyCategory) : string.Empty;
        }

        internal async Task<OutResponse> ResetIndividualMasterCacheComman(CacheRequest cacheRequest, bool isoneincrementCache = false, bool istwoincrementCache = false)
        {
            var data = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();
            string sql = string.Empty;
            bool isResult = false;
            var versionValue = string.Empty;
            var Version = 0;
            var versionData = (await _masterCacheRepositories.GetMasterVersionAsync(new MasterStatus { MstTableName = data.CacheKey })).FirstOrDefault();

            var versionAllData = (bool)versionData?.Status ? await _masterCacheRepositories.GetMasterVersionAsync(new MasterStatus { }) : null;
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
            if (!(bool)versionData?.Status && (data.CacheKey && cacheRequest.RequestData is not "MastersCacheData"))
            {
                string versionLocalData = JsonExtensions.ToJsonSerialize(await _masterCacheRepositories.ExecuteQueryAsync(versionData.SqlQuery));

                var resultCacheData = await _cacheConnector.GetCache("MastersCacheData", true);

                auditId = resultCacheData is not null ? await _cacheConnector.RemoveCacheAuditAsync(new CacheAuditTrail { CacheKey = versionData.MstTableName, IpAddress = data.Ip_Address }) : 0;
                isResult = await _cacheConnector.PutCacheAuditWithOutVersion(versionData.MstTableName, versionLocalData, auditId, data.Ip_Address, istwoincrementCache);
                int.TryParse(await _cacheConnector.GetCacheVersion(versionData.MstTableName), out Version);
                await _masterCacheRepositories.UpdateMasterStatusAsync(new DTo.MasterStatus { Version = Version, MstTableName = versionData.MstTableName });
            }
            if (isUpdate || (!(bool)versionData?.Status && (data.CacheKey && cacheRequest.RequestData is not "MastersCacheData")))
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

        internal async Task<IEnumerable<MasterProductFeature>> ProfileControlsDataAsync(string productId, string channelId, bool? eKyc, string appChannelId = null)
        {
            var masterProfiles = await _masterCacheRepositories.GetMasterProfileFeatureDetailsAsync(new MasterProductFeature { ProductCode = productId is "" ? null : Convert.ToInt32(productId), ChannelID = channelId, Ekyc = eKyc, AppChannelid = appChannelId is not null ? Convert.ToInt32(appChannelId) : null });
            masterProfiles?.ToList().ForEach(async xx => xx.ProfileControlDetails = string.Join("|", (await _masterCacheRepositories.GetMasterProfileControlAsync(new MasterProfileControl { ProductCode = productId is null ? xx.ProductCode : Convert.ToInt32(productId), Ekyc = xx.Ekyc, ChannelID = channelId, AppChannelid = appChannelId is not null ? Convert.ToInt32(appChannelId) : null })).Select(yy => $"{yy.TabControlID}~{yy.ControlID}~{yy.ControlDesc}~{yy.Displayable}~{yy.Editable}~{yy.Mandatory}~{yy.KYCMandatory}~{yy.FieldType}~{yy.DataType}~{yy.FieldLength}~{yy.FieldMinLength}~{yy.FieldMaxLength}~{yy.FieldMinValue}~{yy.FieldMaxValue}~{yy.RequiredMaster}~{yy.RFU1}~{yy.RFU2}~{yy.KYCFlag}~{yy.EditableAddOn}~{yy.DisplayableADDOn}")));
            return masterProfiles;
        }

        internal async Task<OutResponse> GetSequenceAsync(CacheRequest cacheRequest, bool isAppChannel = false)
        {
            var data = cacheRequest.RequestData.ToJsonDeSerialize<dynamic>();
            var sequencesCache = await _cacheConnector.GetCache(isAppChannel ? $"MobSequenceMasterList" + data.AppChannelID : $"MobSequenceMasterList", true);
            IEnumerable<SequenceMapping> sequencesData = null;

            sequencesData = sequencesCache is null ? await _masterCacheRepositories.GetSequencesAsync() : sequencesCache.ToJsonDeSerialize<IEnumerable<SequenceMapping>>();

            var dataSequence = sequencesData.ToJsonSerialize();
            await _cacheConnector.PutCacheMasterAsync(isAppChannel ? $"MobSequenceMasterList" + data.AppChannelID : $"MobSequenceMasterList", dataSequence);
            if (data.ProductType is not "")
            {
                sequencesData = sequencesData.Where(xx =>
                {
                    dynamic dynamic = xx.NewProductType == Convert.ToInt32(data.productType);
                    return dynamic;
                });

            }
            var sequenceVersion = await _cacheConnector.GetCacheVersion(isAppChannel ? $"MobSequenceMasterList" + data.AppChannelID : $"MobSequenceMasterList");
            var sequenceMobile = new SequencesMobile
            {
                Version = Convert.ToInt32(sequenceVersion),
                SequenceMappings = sequencesData
            };

            var profileControl = sequenceMobile.ToJsonSerialize();

            if (sequencesCache is null)
            {
                var masterStatus = await _masterCacheRepositories.GetMasterVersionAsync(new MasterStatus { CacheName = isAppChannel ? $"MobSequenceMasterList" + data.AppChannelID : $"MobSequenceMasterList" });
                _ = masterStatus.Any() ? await _masterCacheRepositories.UpdateMasterStatusAsync(new MasterStatus { Version = Convert.ToInt32(sequenceVersion), CacheName = isAppChannel ? $"MobSequenceMasterList" + data.AppChannelID : $"MobSequenceMasterList" }) : await _masterCacheRepositories.InsertMasterStatusAsync(new MasterStatus { MstTableId = 42, CacheName = isAppChannel ? $"MobSequenceMasterList" + data.AppChannelID : $"MobSequenceMasterList", Version = Convert.ToInt32(sequenceVersion), MstUpdateFlag = 0, CreatedDate = DateTime.Now, CreatedBy = 0 });
            }

            var alertMessage = profileControl is not null ? await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.SequenceListReturnSuccessful.GetIntValue()) : await _masterMessageService.GetMasterMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.SequenceListReturnfailed.GetIntValue());

            var outRespnse = new OutResponse
            {
                ResponseData = profileControl is not null ? profileControl : null,
                RequestId = cacheRequest.RequestId,
                ResponseCode = profileControl is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = alertMessage.Message,
                MessageType = alertMessage.MessageType
            };
            return outRespnse;
        }

        #endregion

    }
}
