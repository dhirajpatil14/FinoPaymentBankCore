using Common.Application.Interface;
using Common.Application.Model;
using Common.Enums;
using Loggers.Logs;
using Loggers.Logs.Model;
using LoginService.Application.Contracts.Identity;
using LoginService.Application.Models;
using PBSecurity;
using System.Threading.Tasks;
using Utility.Common;
using Utility.Extensions;

namespace Login.Identity.Service
{
    public class ProcessIdentityService : IProcessIdentityService
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly ILoggerService _loggerService;
        private readonly CommonEncryption _commonEncryption;

        public ProcessIdentityService(IAuthenticationService authenticationService, ILoggerService loggerService, CommonEncryption commonEncryption)
        {
            _authenticationService = authenticationService;
            _loggerService = loggerService;
            _commonEncryption = commonEncryption;
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
                    #region Method 1. Validate User Authentication 
                    case 1:
                        outResponse = await _authenticationService?.ValidateUserAuthenticationAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 2. Validate User    
                    case 2:
                        outResponse = await _authenticationService?.ValidateUserAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 3.  Logout User    
                    case 3:
                        outResponse = await _authenticationService?.LogOutUserAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 4. Check Auth Context Details
                    case 4:
                        outResponse = await _authenticationService?.GetAuthContextAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 5. Fetch Finger Print Service 
                    case 5:
                        outResponse = await _authenticationService.GetEsbFpAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 6. Validate Token
                    case 6:
                        outResponse = await _authenticationService.ValidateTokenAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 7. User Unlock 
                    case 7:
                        outResponse = await _authenticationService.UserUnlockAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 8. Get Secret Question
                    case 8:
                        outResponse = await _authenticationService.GetSecretQuestionAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 9. Update Secret Question
                    case 9:

                        break;
                    #endregion

                    #region Method 10. User FP Authentication
                    case 10:
                        outResponse = await _authenticationService.UserFpAuthenticationAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 11. Validate User Secret Question
                    case 11:
                        outResponse = await _authenticationService.ValidateSecretQuestionAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 12. This Is Used to get enryption key
                    case 12:
                        outResponse = await _authenticationService.GetEncryptionKeyAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 13. This Is Used to reset password and validate secret question
                    case 13:
                        break;
                    #endregion

                    #region Method 14. This Is Used to change password
                    case 14:
                        break;
                    #endregion

                    #region Method 15. This Is Used to fetch all secret questions
                    case 15:
                        break;
                    #endregion

                    #region Method 16. This Is Used to Get User Details
                    case 16:
                        break;
                    #endregion

                    #region Method 17. This Is Used to fetch Management Health
                    case 17:
                        break;
                    #endregion

                    #region Method 18. This Is Used to update Merchant Details
                    case 18:
                        break;
                    #endregion

                    #region Method 19. Get User Survey
                    case 19:
                        break;
                    #endregion

                    #region Method 20 This Is Used to Check Authman Policy Check
                    case 20:
                        outResponse = await _authenticationService.VerifyUserIdAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 21. This Is Used to Get Authman Policy with OTP
                    case 21:
                        break;
                    #endregion

                    #region Method 22. This Is Used to Get Aadhar details data
                    case 22:
                        break;
                    #endregion

                    #region Method 23. This Is Used to Submit Aadhar details data
                    case 23:
                        break;
                    #endregion

                    #region Method 24. This Is Used to get blocked User Details-Teller/Branch
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

        public async Task<OutResponse> IdentityPayloadAsync(AuthenticationEnRequest enRequest)
        {

            var outResponse = new OutResponse();
            var authenticationRequest = new AuthenticationRequest();
            if (authenticationRequest is null)
            {
                outResponse.ResponseMessage = "";

                return outResponse;
            }
            else
            {
                if (!authenticationRequest.IsEncrypt)
                {
                    //var decriptData = authenticationRequest?.RequestData?.ToDecryptOpenSSL(authenticationRequest.SessionId);
                    var decriptData = _commonEncryption.LoginRequest(enRequest, "LOGIN");
                    //authenticationRequest = decriptData;
                }

                await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Process Identity Service" });
                await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

                switch (authenticationRequest.MethodId)
                {
                    #region Method 1. Validate User Authentication 
                    case 1:
                        outResponse = await _authenticationService?.ValidateUserAuthenticationAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 2. Validate User    
                    case 2:
                        outResponse = await _authenticationService?.ValidateUserAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 3.  Logout User    
                    case 3:
                        outResponse = await _authenticationService?.LogOutUserAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 4. Check Auth Context Details
                    case 4:
                        outResponse = await _authenticationService?.GetAuthContextAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 5. Fetch Finger Print Service 
                    case 5:
                        outResponse = await _authenticationService.GetEsbFpAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 6. Validate Token
                    case 6:
                        outResponse = await _authenticationService.ValidateTokenAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 7. User Unlock 
                    case 7:
                        outResponse = await _authenticationService.UserUnlockAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 8. Get Secret Question
                    case 8:
                        outResponse = await _authenticationService.GetSecretQuestionAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 9. Update Secret Question
                    case 9:

                        break;
                    #endregion

                    #region Method 10. User FP Authentication
                    case 10:
                        outResponse = await _authenticationService.UserFpAuthenticationAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 11. Validate User Secret Question
                    case 11:
                        outResponse = await _authenticationService.ValidateSecretQuestionAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 12. This Is Used to get enryption key
                    case 12:
                        outResponse = await _authenticationService.GetEncryptionKeyAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 13. This Is Used to reset password and validate secret question
                    case 13:
                        break;
                    #endregion

                    #region Method 14. This Is Used to change password
                    case 14:
                        break;
                    #endregion

                    #region Method 15. This Is Used to fetch all secret questions
                    case 15:
                        break;
                    #endregion

                    #region Method 16. This Is Used to Get User Details
                    case 16:
                        break;
                    #endregion

                    #region Method 17. This Is Used to fetch Management Health
                    case 17:
                        break;
                    #endregion

                    #region Method 18. This Is Used to update Merchant Details
                    case 18:
                        break;
                    #endregion

                    #region Method 19. Get User Survey
                    case 19:
                        break;
                    #endregion

                    #region Method 20 This Is Used to Check Authman Policy Check
                    case 20:
                        outResponse = await _authenticationService.VerifyUserIdAsync(authenticationRequest);
                        break;
                    #endregion

                    #region Method 21. This Is Used to Get Authman Policy with OTP
                    case 21:
                        break;
                    #endregion

                    #region Method 22. This Is Used to Get Aadhar details data
                    case 22:
                        break;
                    #endregion

                    #region Method 23. This Is Used to Submit Aadhar details data
                    case 23:
                        break;
                    #endregion

                    #region Method 24. This Is Used to get blocked User Details-Teller/Branch
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
