using Common.Application.Model;
using Common.Enums;
using Loggers.Logs;
using Loggers.Logs.Model;
using Master.Cache.Service.MasterCache;
using Master.Cache.Service.MasterCache.Model;
using MasterCacheService.Application.Contracts.ServiceContarct;
using System.Threading.Tasks;
using Utility.Common;
using Utility.Extensions;

namespace MasterCache.Service.Service
{
    public class MasterCacheApplicationService : IMasterCacheApplicationService
    {
        private readonly IMasterCacheService _masterCacheService;
        private readonly ILoggerService _loggerService;

        public MasterCacheApplicationService(IMasterCacheService masterCacheService, ILoggerService loggerService)
        {
            _masterCacheService = masterCacheService;
            _loggerService = loggerService;
        }


        public async Task<OutResponse> MasterServiceCacheAsync(CacheRequest cacheRequest)
        {
            var outResponse = new OutResponse();
            if (cacheRequest is null)
            {
                outResponse.ResponseMessage = "";

                return outResponse;
            }
            else
            {
                if (cacheRequest.IsEncrypt)
                {
                    var decriptData = cacheRequest?.RequestData?.ToDecryptOpenSSL(cacheRequest.SessionId);
                    cacheRequest.RequestData = decriptData;
                }

                await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = cacheRequest.ServiceID, MethodId = cacheRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = cacheRequest.RequestId, CorelationSession = cacheRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Process Identity Service" });
                await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = cacheRequest.RequestId, TokenID = cacheRequest.TokenId, TellerID = cacheRequest.TellerId, UserID = cacheRequest.ReturnId(), SessionID = cacheRequest.SessionId, MethodId = cacheRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {cacheRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

                switch (cacheRequest.MethodId)
                {
                    case 1111:
                        outResponse = await _masterCacheService.GetMasterCacheCategoryAsync(cacheRequest);
                        break;
                    case 6611:
                        outResponse = await _masterCacheService.GetMasterCacheCategoryMobileAsync(cacheRequest);
                        break;
                    case 1:
                        outResponse = await _masterCacheService.GetMasterCacheAsync(cacheRequest);
                        break;
                    case 111:
                        outResponse = await _masterCacheService.GetMasterCacheZipAsync(cacheRequest);
                        break;
                    case 222:
                        outResponse = await _masterCacheService.ResetMasterCacheByCategoryAsync(cacheRequest);
                        break;
                    case 22211:
                        outResponse = await _masterCacheService.ResetMasterCacheByCatgoryWithOutIncVersionAsync(cacheRequest);
                        break;
                    case 5511:
                        outResponse = await _masterCacheService.ResetMasterCacheByCatgoryForMobileAsync(cacheRequest);
                        break;
                    case 7711:
                        outResponse = await _masterCacheService.ResetMasterCacheByCategoryForMobileWithOutIncVersionAsync(cacheRequest);
                        break;
                    case 2:
                        outResponse = await _masterCacheService.ResetMasterCacheAsync(cacheRequest);
                        break;
                    case 2211:
                        outResponse = await _masterCacheService.ResetMasterCacheWithOutVersionAsync(cacheRequest);
                        break;
                    case 3:
                        outResponse = await _masterCacheService.GetVersionForMastersAsync(cacheRequest);
                        break;
                    case 4:
                        outResponse = await _masterCacheService.ResetIndividualMasterCacheAsync(cacheRequest);
                        break;
                    case 4411:
                        outResponse = await _masterCacheService.ResetIndividualMasterCacheWithOutIncrementVersionAsync(cacheRequest);
                        break;
                    case 5:
                        outResponse = await _masterCacheService.GetProfileFeatureControlsAsync(cacheRequest);
                        break;
                    case 55:
                        outResponse = await _masterCacheService.GetProfileFeatureControlsAppChannelAsync(cacheRequest);
                        break;
                    case 6:
                        outResponse = await _masterCacheService.GetSequencesAsync(cacheRequest);
                        break;
                    case 66:
                        outResponse = await _masterCacheService.GetSequencesAppChannelAsync(cacheRequest);
                        break;
                    case 7:
                        outResponse = await _masterCacheService.GetPublicKeyAsync(cacheRequest);
                        break;
                    case 8:
                        outResponse = await _masterCacheService.GetMenuByChannelAsync(cacheRequest);
                        break;
                    default:
                        break;
                }


                outResponse.RouteID = $"{CommonValues.ESBRESPONSE} { new TraceCalling().ToRoute() }";

                if (cacheRequest.IsEncrypt)
                    outResponse.ResponseData = outResponse.ResponseData.ToEncriptOpenSSL(cacheRequest.SessionId);


            }
            throw new System.NotImplementedException();
        }
    }
}
