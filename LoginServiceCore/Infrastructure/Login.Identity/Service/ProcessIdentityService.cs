using Common.Application.Model;
using Common.Enums;
using Loggers.Logs;
using Loggers.Logs.Model;
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

                await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Process Identity Service" });
                await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });


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
