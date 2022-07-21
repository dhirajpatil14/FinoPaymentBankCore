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
                    #region Validate User Authentication 
                    case 1:
                        outResponse = await _authenticationService?.ValidateUserAuthenticationAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Validate User    
                    case 2:
                        outResponse = await _authenticationService?.ValidateUserAsync(authenticationRequest);
                        break;
                    #endregion

                    #region  Logout User    
                    case 3:
                        outResponse = await _authenticationService?.LogOutUserAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Check Auth Context Details
                    case 4:
                        outResponse = await _authenticationService?.GetAuthContextAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Fetch Finger Print Service 
                    case 5:
                        outResponse = await _authenticationService.GetEsbFpAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Validate Token
                    case 6:
                        outResponse = await _authenticationService.ValidateTokenAsync(authenticationRequest);
                        break;
                    #endregion

                    #region User Unlock 
                    case 7:
                        outResponse = await _authenticationService.UserUnlockAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Get Secret Question
                    case 8:
                        outResponse = await _authenticationService.GetSecretQuestionAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Update Secret Question
                    case 9:

                        break;
                    #endregion

                    #region User FP Authentication
                    case 10:
                        outResponse = await _authenticationService.UserFpAuthenticationAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Validate User Secret Question
                    case 11:
                        outResponse = await _authenticationService.ValidateSecretQuestionAsync(authenticationRequest);
                        break;
                    #endregion

                    #region This Is Used to get enryption key
                    case 12:
                        outResponse = await _authenticationService.GetEncryptionKeyAsync(authenticationRequest);
                        break;
                    #endregion

                    #region This Is Used to reset password and validate secret question
                    case 13:
                        break;
                    #endregion

                    #region This Is Used to change password
                    case 14:
                        break;
                    #endregion

                    #region This Is Used to fetch all secret questions
                    case 15:
                        break;
                    #endregion

                    #region This Is Used to Get User Details
                    case 16:
                        break;
                    #endregion

                    #region This Is Used to fetch Management Health
                    case 17:
                        break;
                    #endregion

                    #region This Is Used to update Merchant Details
                    case 18:
                        break;
                    #endregion

                    #region Get User Survey
                    case 19:
                        break;
                    #endregion

                    #region Method 20 This Is Used to Check Authman Policy Check
                    case 20:
                        outResponse = await _authenticationService.VerifyUserIdAsync(authenticationRequest);
                        break;
                    #endregion

                    #region This Is Used to Get Authman Policy with OTP
                    case 21:
                        break;
                    #endregion

                    #region This Is Used to Get Aadhar details data
                    case 22:
                        break;
                    #endregion

                    #region This Is Used to Submit Aadhar details data
                    case 23:
                        break;
                    #endregion

                    #region This Is Used to get blocked User Details-Teller/Branch
                    case 24:
                        break;
                    #endregion

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
