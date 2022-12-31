using Common.Application.Model;
using Common.Application.Model.Settings;
using Common.Enums;
using Loggers.Logs;
using Loggers.Logs.Model;
using ServiceRequest.Application.Contracts.Identity;
using ServiceRequest.Application.Models;
using Shared.Services.ESBCBSMessageService;
using Shared.Services.ESBMessageService;
using Shared.Services.ESBURLService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility.Common;
using Utility.Extensions;
using WebApi.Services;
using WebApi.Services.Settings;

namespace ServiceRequest.Identity.Service
{
    class SaveServiceRequestService : ISaveServiceRequestService
    {
        private readonly IWebApiRequestService _webApiRequestService;

        private readonly EsbUrlMemoryService _esbUrlMemoryService;

        private readonly AppSettings _appSettings;
        
        private readonly ILoggerService _loggerService;
        
        private readonly EsbCbsMessageService _esbCbsMessageService;
        
        private readonly EsbMessageService _esbMessageService;
        public SaveServiceRequestService(
            IWebApiRequestService webApiRequestService, 
            EsbUrlMemoryService esbUrlMemoryService,
            AppSettings appSettings,
            ILoggerService loggerService,
            EsbCbsMessageService esbCbsMessageService,
            EsbMessageService esbMessageService)
        {
            _webApiRequestService = webApiRequestService;
            _esbUrlMemoryService = esbUrlMemoryService;
            _appSettings = appSettings;
            _loggerService = loggerService;
            _esbCbsMessageService = esbCbsMessageService;
            _esbMessageService = esbMessageService;
        }

        public async Task<OutResponse> PanValidation(SaveServiceRequest saveServiceRequest)
        {
            var panReply = saveServiceRequest.RequestData.ToJsonDeSerialize<dynamic>();

            var urlData = await GetEsbUrlAsync(EsbUrls.ESBPanValidationUrl);

            var request = GetWebRequestSettings(urlData, panReply, saveServiceRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = saveServiceRequest.ServiceID, MethodId = saveServiceRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = saveServiceRequest.RequestId, CorelationSession = saveServiceRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Save Service Request Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = saveServiceRequest.RequestId, TokenID = saveServiceRequest.TokenId, TellerID = saveServiceRequest.TellerId, UserID = saveServiceRequest.ReturnId(), SessionID = saveServiceRequest.SessionId, MethodId = saveServiceRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {saveServiceRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);

            var isInvalid = result.StatusCode is not (int)HttpStatusCode.OK;

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            var esbMessageAlert = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.PanUpdateInCBsSuccess.GetIntValue(), result?.Data?.ReturnCode) : null;

            var esbMessageFailed = !checkValidReturnCode ? await _esbMessageService.GetEsbMessageByIdAsync(MessageTypeId.PanUpdateInCBSFailed.GetIntValue()) : null;

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = saveServiceRequest.RequestId, TokenID = saveServiceRequest.TokenId, TellerID = saveServiceRequest.TellerId, UserID = saveServiceRequest.ReturnId(), SessionID = saveServiceRequest.SessionId, MethodId = saveServiceRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result?.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = saveServiceRequest.ServiceID, MethodId = saveServiceRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = saveServiceRequest.RequestId, CorelationSession = saveServiceRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result?.Data?.ToJsonSerialize() });

            var response = new OutResponse()
            {
                RequestId = saveServiceRequest.RequestId,
                SessionExpiryTime = checkValidReturnCode ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : string.Empty,
                ResponseCode = isInvalid ? ResponseCode.RemoteServerError.GetIntValue() : (!checkValidReturnCode) ? ResponseCode.Failure.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.CorrectedMessage : (esbMessageFailed is not null && !checkValidReturnCode) ? esbMessageFailed.CorrectedMessage : string.Empty,
                ResponseMessage_Hindi = !checkValidReturnCode ? esbMessageFailed.HindiMessage : string.Empty,
                MessageType = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.MessageType : !checkValidReturnCode ?? MessageType.Exclam.GetStringValue(),
                ResponseData = result?.Data.ToJsonSerilize(),
            };

            return response;
        }

        #region Internal Method 
        internal async Task<string> GetEsbUrlAsync(EsbUrls esbUrl)
        {
            return (await _esbUrlMemoryService.GetEsbUrlByIdAsync(esbUrl, ServiceName.SERVICEREQUEST)).ESBUrl;
        }

        internal WebApiRequestSettings<T1> GetWebRequestSettings<T1>(string esbUrl, T1 data, SaveServiceRequest request) where T1: new()
        {
            return new WebApiRequestSettings<T1> 
            {
                URL = esbUrl,
                PostParameter = data,
                Timeout = _appSettings.Timeout,
                XAuthToken = request.XAuthToken,
                RequesterId = request.ReturnId(),
                RequestId = request.RequestId,
                TokenId = request.TokenId
            };
        }
        #endregion
    }
}
