using Common.Application.Model;
using Common.Enums;
using Loggers.Logs;
using LoginService.Application.Contracts.Identity;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using LoginService.Application.Models.Settings;
using Microsoft.Extensions.Options;
using Shared.Services.ESBCBSMessageService;
using Shared.Services.ESBMessageService;
using Shared.Services.ESBURLService;
using System;
using System.Net;
using System.Threading.Tasks;
using Utility.Common;
using Utility.Extensions;
using WebApi.Services;
using WebApi.Services.Settings;

namespace Login.Identity.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWebApiRequestService _webApiRequestService;

        private readonly EsbUrlMemoryService _esbUrlMemoryService;

        private readonly EsbMessageService _esbMessageService;

        private readonly EsbCbsMessageService _esbCbsMessageService;

        private readonly ILoggerService _loggerService;

        private readonly AppSettings _appSettings;



        public AuthenticationService(IWebApiRequestService webApiRequestService, ILoggerService loggerService, IOptions<AppSettings> appSettings, EsbUrlMemoryService esbUrlMemoryService, EsbMessageService esbMessageService, EsbCbsMessageService esbCbsMessageService)
        {
            _webApiRequestService = webApiRequestService;
            _loggerService = loggerService;
            _esbUrlMemoryService = esbUrlMemoryService;
            _esbMessageService = esbMessageService;
            _esbCbsMessageService = esbCbsMessageService;
            _appSettings = appSettings.Value;
        }

        public async Task AuthenticateAsync(AuthenticationRequest authenticationRequest)
        {
            var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<FisUserValidateRequest>();

            replyData.UserId = replyData.EcbBlockEncryption ? replyData.UserId.ToDecryptEcbBlock(_appSettings.DecryptKey)
                : replyData.UserId.ToDecryptStringAES(_appSettings.DecryptKey, _appSettings.DecryptKeygen);

            var urlData = await _esbUrlMemoryService.GetEsbUrlByIdAsync(EsbUrls.EsbCheckAuthenticationUrl, ServiceName.LOGINSERVICE);

            var request = new WebApiRequestSettings<FisUserValidateRequest>
            {
                URL = urlData?.ESBUrl,
                PostParameter = replyData,
                Timeout = _appSettings.Timeout,
                XAuthToken = authenticationRequest.XAuthToken,
                RequesterId = authenticationRequest.ReturnId(),
                RequestId = authenticationRequest.RequestId
            };

            var result = await _webApiRequestService.PostAsync<FisUserValidateResponse, FisUserValidateRequest>(request);

            var isNotValid = (!(result.StatusCode is (int)HttpStatusCode.OK));

            var esbMessagesdata = new EsbMessages();

            if (result.StatusCode is 503)
                esbMessagesdata = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.ServerUnavailable);
            else if (result.StatusCode != 200 && result.StatusCode != 503)
                esbMessagesdata = await _esbMessageService.GetEsbMessage(string.Empty, ResponseCode.RemoteServerError.GetStringValue(), result.ErrorMessage);

            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = isNotValid ? esbMessagesdata.CorrectedMessage : string.Empty,
                MessageType = isNotValid ? MessageType.Exclam.GetStringValue() : string.Empty,
                ResponseData = isNotValid ? esbMessagesdata.CorrectedMessage : result.Data.ToJsonSerialize()
            };

            if (ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode))
            {
                var messageType = result.Data.EncryptionKey != null ? MessageTypeId.AuthenticateSuccess.GetIntValue() : MessageTypeId.AuthenticateUnSuccess.GetIntValue();
                var esbcbsMessage = await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, messageType, result.Data.ReturnCode);
                outRespnse.ResponseMessage = esbcbsMessage.StandardMessageDescription;
                outRespnse.MessageType = esbcbsMessage.MessageType;
                outRespnse.AuthmanFlag = result.Data.EncryptionKey != null;
                outRespnse.ResponseCode = result.Data.EncryptionKey != null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue();
                outRespnse.SessionExpiryTime = result.Data.EncryptionKey ?? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired);
            }
            throw new NotImplementedException();
        }

        public Task RestrictUserAccessAsync()
        {
            throw new NotImplementedException();
        }
    }
}
