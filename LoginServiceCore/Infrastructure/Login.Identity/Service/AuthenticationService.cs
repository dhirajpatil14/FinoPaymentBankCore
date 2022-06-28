using Common.Enums;
using LoginService.Application.Contracts.Identity;
using LoginService.Application.Models;
using Shared.Services.ESBURLService;
using System;
using System.Threading.Tasks;
using WebApi.Services;
using WebApi.Services.Settings;

namespace Login.Identity.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWebApiRequestService _webApiRequestService;

        private readonly EsbUrlMemoryService _esbUrlMemoryService;

        public AuthenticationService(IWebApiRequestService webApiRequestService, EsbUrlMemoryService esbUrlMemoryService)
        {
            _esbUrlMemoryService = esbUrlMemoryService;
            _webApiRequestService = webApiRequestService;
        }

        public async Task AuthenticateAsync(AuthenticationRequest authenticationRequest)
        {
            var urlData = await _esbUrlMemoryService.GetEsbUrlByIdAsync(EsbUrls.EsbCheckAuthenticationUrl, ServiceName.LOGINSERVICE);

            var request = new WebApiRequestSettings<AuthenticationRequest>
            {
                URL = urlData?.ESBUrl,
                PostParameter = authenticationRequest,
                //Timeout = _appSettings.Timeout,
            };

            //write some log


            var result = await _webApiRequestService.PostAsync<dynamic, AuthenticationRequest>(request);
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
