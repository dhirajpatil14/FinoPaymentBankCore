using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Loggers.Logs;
using LoginService.Application.Contracts.Identity;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using LoginService.Application.Models.Settings;
using Microsoft.Extensions.Options;
using Shared.Services.ESBCBSMessageService;
using Shared.Services.ESBMessageService;
using Shared.Services.ESBURLService;
using SQL.Helper;
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

        private readonly ILoggerService _loggerService;

        private readonly IDataDbConfigurationService _dataDbConfigurationService;

        private readonly EsbUrlMemoryService _esbUrlMemoryService;

        private readonly EsbMessageService _esbMessageService;

        private readonly EsbCbsMessageService _esbCbsMessageService;

        private readonly SqlConnectionStrings _sqlConnectionStrings;


        private readonly AppSettings _appSettings;



        public AuthenticationService(IWebApiRequestService webApiRequestService, ILoggerService loggerService, IDataDbConfigurationService dataDbConfigurationService, IOptions<AppSettings> appSettings, IOptions<SqlConnectionStrings> sqlConnectionStrings, EsbUrlMemoryService esbUrlMemoryService, EsbMessageService esbMessageService, EsbCbsMessageService esbCbsMessageService)
        {
            _webApiRequestService = webApiRequestService;
            _loggerService = loggerService;
            _dataDbConfigurationService = dataDbConfigurationService;
            _esbUrlMemoryService = esbUrlMemoryService;
            _esbMessageService = esbMessageService;
            _esbCbsMessageService = esbCbsMessageService;
            _appSettings = appSettings.Value;
            _sqlConnectionStrings = sqlConnectionStrings.Value;
        }

        public async Task<OutResponse> AuthenticateAsync(AuthenticationRequest authenticationRequest)
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

            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            var esbMessagesdata = new EsbMessages();
            if (result.StatusCode is 503)
                esbMessagesdata = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.ServerUnavailable);
            else if (result.StatusCode is not 200 && result.StatusCode is not 503)
                esbMessagesdata = await _esbMessageService.GetEsbMessage(string.Empty, ResponseCode.RemoteServerError.GetStringValue(), result.ErrorMessage);

            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = isNotValid ? esbMessagesdata.CorrectedMessage : string.Empty,
                MessageType = isNotValid ? MessageType.Exclam.GetStringValue() : string.Empty,
                ResponseData = isNotValid ? esbMessagesdata.CorrectedMessage : result.Data.ToJsonSerialize()
            };
            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);


            var messageType = result.Data.EncryptionKey is not null && checkValidReturnCode ? MessageTypeId.AuthenticateSuccess.GetIntValue() : MessageTypeId.AuthenticateUnSuccess.GetIntValue();
            outRespnse.SessionExpiryTime = result.Data.EncryptionKey is not null ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : "0";
            outRespnse.AuthmanFlag = result.Data.EncryptionKey is not null;
            outRespnse.ResponseCode = result.Data.EncryptionKey is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue();

            var esbcbsMessage = await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, messageType, result.Data.ReturnCode);
            outRespnse.ResponseMessage = esbcbsMessage.StandardMessageDesc;
            outRespnse.MessageType = esbcbsMessage.MessageType;



            var updatedMessage = !checkValidReturnCode && result?.Data?.ReturnCode == 300 &&
                                  result?.Data?.BlockReasonCode is "11" &&
                                 result?.Data?.ClientId is not "FINOMER" ? await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.BlockUser) : null;

            if (updatedMessage is not null)
            {
                outRespnse.ResponseMessage = updatedMessage.CorrectedMessage;
                outRespnse.ResponseMessage_Hindi = updatedMessage.HindiMessage;
            }
            else
            {
                var config = new DataDbConfigSettings<Reasons>
                {
                    TableEnums = PBMaster.ReasonMaster,
                    Request = new Reasons { RevokeReason = result?.Data?.BlockReasonCode },
                    DbConnection = _sqlConnectionStrings.PBMasterConnection
                };

                var checkUserStatus = !checkValidReturnCode &&
                                        result?.Data?.ReturnCode is 300 && result?.Data?.BlockReasonCode is not "11" && result?.Data?.ClientId is not "FINOTLR" ?
                                        await _dataDbConfigurationService.GetDataAsync<Reasons, Reasons>(config) : null;

                if (checkUserStatus is not null)
                    outRespnse.ResponseMessage = checkUserStatus?.ResponseMessage;
            }
            if (result?.Data?.BlockReasonCode is not null)
            {
                var blockUserMessage = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.BlockUserPassword);
                outRespnse.ResponseMessage = blockUserMessage.CorrectedMessage;
                outRespnse.ResponseMessage_Hindi = blockUserMessage.HindiMessage;
            }
            if (result?.Data is null && !checkValidReturnCode)
            {
                outRespnse.ResponseMessage = $"Unable to parse Authman response.";
                outRespnse.MessageType = MessageType.Exclam.GetStringValue();
            }

            return outRespnse;
        }

        public Task RestrictUserAccessAsync()
        {
            throw new NotImplementedException();
        }
    }
}
