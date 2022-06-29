using Common.Enums;
using Loggers.Logs;
using LoginService.Application.Contracts.Identity;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using LoginService.Application.Models.Settings;
using Microsoft.Extensions.Options;
using Shared.Services.ESBURLService;
using System;
using System.Threading.Tasks;
using Utility.Extensions;
using WebApi.Services;
using WebApi.Services.Settings;

namespace Login.Identity.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWebApiRequestService _webApiRequestService;

        private readonly EsbUrlMemoryService _esbUrlMemoryService;

        private readonly ILoggerService _loggerService;

        private readonly AppSettings _appSettings;

        public AuthenticationService(IWebApiRequestService webApiRequestService, ILoggerService loggerService, IOptions<AppSettings> appSettings, EsbUrlMemoryService esbUrlMemoryService)
        {
            _webApiRequestService = webApiRequestService;
            _loggerService = loggerService;
            _esbUrlMemoryService = esbUrlMemoryService;
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

            //write some log


            var result = await _webApiRequestService.PostAsync<dynamic, FisUserValidateRequest>(request);
            if (!result?.Data)
            {
                //write some log
            }
            else if (result?.Data && result?.StatusCode == 200)
            {
                //write log
            }
            else
            {
                //write log

            }

            throw new NotImplementedException();
        }

        public Task RestrictUserAccessAsync()
        {
            throw new NotImplementedException();
        }
    }
}
