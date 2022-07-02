using Common.Application.Model;
using Loggers.Logs;
using LoginService.Application.Contracts.Identity;
using LoginService.Application.Models;
using System.Threading.Tasks;
using Utility.Common;
using Utility.Extensions;

namespace Login.Identity.Service
{
    public class ProcessIdentityService : IProcessIdentityService
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly ILoggerService _loggerService;
        public ProcessIdentityService(IAuthenticationService authenticationService, ILoggerService loggerService)
        {
            _authenticationService = authenticationService;
            _loggerService = loggerService;
        }

        public async Task<OutResponse> IdentityAsync(AuthenticationRequest authenticationRequest)
        {
            var outResponse = new OutResponse();

            if (authenticationRequest is null)
            {
                outResponse.ResponseMessage = "";

                return outResponse;
            }
            else
            {
                if (authenticationRequest.IsEncrypt)
                {
                    var decriptData = authenticationRequest?.RequestData?.ToDecryptOpenSSL(authenticationRequest.SessionId);
                    authenticationRequest.RequestData = decriptData;
                }

                //write log 

                switch (authenticationRequest.MethodId)
                {

                    case 1:
                        outResponse = await _authenticationService?.AuthenticateAsync(authenticationRequest);
                        break;
                    default:
                        break;
                }

                outResponse.RouteID = $"{CommonValues.ESBRESPONSE} { new TraceCalling().ToRoute() }";

                if (authenticationRequest.IsEncrypt)
                    outResponse.ResponseData = outResponse.ResponseData.ToEncriptOpenSSL(authenticationRequest.SessionId);
            }
            return outResponse;
        }
    }
}
