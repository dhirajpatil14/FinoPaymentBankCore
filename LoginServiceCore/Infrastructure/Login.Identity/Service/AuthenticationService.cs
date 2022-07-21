using Common.Application.Dto;
using Common.Application.Interface;
using Common.Application.Model;
using Common.Application.Model.Settings;
using Common.Enums;
using Data.Db.Service.Interface;
using Loggers.Logs;
using Loggers.Logs.Model;
using LoginService.Application.Contracts.Identity;
using LoginService.Application.Contracts.Repositories;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using Microsoft.Extensions.Options;
using Shared.Services.ESBCBSMessageService;
using Shared.Services.ESBMessageService;
using Shared.Services.ESBURLService;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Utility.Common;
using Utility.Extensions;
using Utility.Extensions.Aadhar;
using WebApi.Services;
using WebApi.Services.Settings;

namespace Login.Identity.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWebApiRequestService _webApiRequestService;

        private readonly ILoggerService _loggerService;

        private readonly IUserRepositories _userRepositories;

        private readonly IEkycAuaService _ekycAuaService;

        private readonly EsbUrlMemoryService _esbUrlMemoryService;

        private readonly EsbMessageService _esbMessageService;

        private readonly EsbCbsMessageService _esbCbsMessageService;

        private readonly AppSettings _appSettings;

        public AuthenticationService(IWebApiRequestService webApiRequestService, IUserRepositories userRepositories, IEkycAuaService ekycAuaService, ILoggerService loggerService, IDataDbConfigurationService dataDbConfigurationService, IOptions<AppSettings> appSettings, EsbUrlMemoryService esbUrlMemoryService, EsbMessageService esbMessageService, EsbCbsMessageService esbCbsMessageService)
        {
            _webApiRequestService = webApiRequestService;
            _userRepositories = userRepositories;
            _loggerService = loggerService;
            _esbUrlMemoryService = esbUrlMemoryService;
            _esbMessageService = esbMessageService;
            _esbCbsMessageService = esbCbsMessageService;
            _ekycAuaService = ekycAuaService;
            _appSettings = appSettings.Value;
        }

        public async Task<OutResponse> ValidateUserAuthenticationAsync(AuthenticationRequest authenticationRequest)
        {
            var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<FisUserValidateRequest>();

            replyData.UserId = replyData.EcbBlockEncryption ? replyData.UserId.ToDecryptEcbBlock(_appSettings.DecryptKey)
                : replyData.UserId.ToDecryptStringAES(_appSettings.DecryptKey, _appSettings.DecryptKeygen);


            var urlData = await GetEsbUrlAsync(EsbUrls.EsbCheckAuthenticationUrl);

            var request = GetWebRequestSettings<FisUserValidateRequest>(urlData, replyData, authenticationRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL2.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<FisUserValidateResponse, FisUserValidateRequest>(request);

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            var esbMessagesdata = new EsbMessages();
            if (result.StatusCode is 503)
                esbMessagesdata = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.ServerUnavailable.GetIntValue());
            else if (result.StatusCode is not 200 && result.StatusCode is not 503)
                esbMessagesdata = await _esbMessageService.GetEsbMessage(string.Empty, ResponseCode.RemoteServerError.GetStringValue(), result.ErrorMessage);


            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            var islogService = isNotValid ? await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = EsbsMessages.ServerUnavailable.GetIntValue(), ResponseMessage = "ESB Server UnAvailable" }) : 0;

            islogService = !isNotValid ? await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() }) : 0;

            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = isNotValid ? esbMessagesdata.CorrectedMessage : string.Empty,
                MessageType = isNotValid ? MessageType.Exclam.GetStringValue() : string.Empty,
                ResponseData = result.Data.ToJsonSerialize()
            };

            var messageType = result.Data.EncryptionKey is not null && checkValidReturnCode ? MessageTypeId.AuthenticateSuccess.GetIntValue() : MessageTypeId.AuthenticateUnSuccess.GetIntValue();
            outRespnse.SessionExpiryTime = result.Data.EncryptionKey is not null ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : "0";
            outRespnse.AuthmanFlag = result.Data.EncryptionKey is not null;
            outRespnse.ResponseCode = result.Data.EncryptionKey is not null ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue();

            var esbcbsMessage = await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, messageType, result.Data.ReturnCode);
            outRespnse.ResponseMessage = esbcbsMessage.StandardMessageDesc;
            outRespnse.MessageType = esbcbsMessage.MessageType;


            outRespnse = await CommanBlockUserAsync(result?.Data, outRespnse, checkValidReturnCode);

            if (result?.Data is null && !checkValidReturnCode)
            {
                outRespnse.ResponseMessage = $"Unable to parse Authman response.";
                outRespnse.MessageType = MessageType.Exclam.GetStringValue();
            }

            return outRespnse;
        }

        public async Task<OutResponse> ValidateUserAsync(AuthenticationRequest authenticationRequest)
        {
            var loginData = authenticationRequest.RequestData.ToJsonDeSerialize<FisUserPasswordValidateRequest>();
            var isUserRestricted = await RestrictUserAccess(loginData);

            var outRespnse = new OutResponse
            {
                ResponseMessage = isUserRestricted ? "User not authorized to proceed !" : string.Empty,
                ResponseData = isUserRestricted ? new LoginDataResponse().ToJsonSerialize() : string.Empty
            };
            outRespnse.ResponseCode = ResponseCode.Failure.GetIntValue();
            outRespnse.MessageType = MessageType.Exclam.GetStringValue();
            outRespnse.SessionId = authenticationRequest.SessionId;
            outRespnse.SessionExpiryTime = authenticationRequest.SessionExpiryTime;


            if (isUserRestricted)
                await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.Exception.GetIntValue() });
            return outRespnse;

            outRespnse.RequestId = authenticationRequest.RequestId;

            if (loginData?.Aadhaar?.RequestData is not null)
                loginData.Aadhaar.RequestData = await AadharExtension.GetAadharXmlAsync(loginData.Aadhaar, _ekycAuaService);



            var responseMessage = loginData?.EncType is not null and not "NEW" ? await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.UnableToProcessRequest.GetIntValue()) : null;
            outRespnse.ResponseMessage = responseMessage?.CorrectedMessage ?? string.Empty;
            if (responseMessage is not null)
                return outRespnse;

            loginData.UserId = loginData.EcbBlockEncryption ? loginData?.UserId.ToDecryptEcbBlock(_appSettings.DecryptKey) : loginData.UserId;
            loginData.UserId = !loginData.EcbBlockEncryption ? loginData.UserId.ToDecryptStringAES(_appSettings.DecryptKey, _appSettings.DecryptKeygen) : loginData?.UserId;

            var urlData = await GetEsbUrlAsync(EsbUrls.EsbNewTokenUrl);

            var request = GetWebRequestSettings<FisUserPasswordValidateRequest>(urlData, loginData, authenticationRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<FisUserPasswordValidateResponse, FisUserPasswordValidateRequest>(request);

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            if (result.StatusCode is 503)
                responseMessage = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.ServerUnavailable.GetIntValue());
            else if (result.StatusCode is not 200 && result.StatusCode is not 503)
                responseMessage = await _esbMessageService.GetEsbMessage(string.Empty, ResponseCode.RemoteServerError.GetStringValue(), result.ErrorMessage);

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            var islogService = isNotValid ? await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = EsbsMessages.ServerUnavailable.GetIntValue(), ResponseMessage = "ESB Server UnAvailable" }) : 0;
            islogService = !isNotValid ? await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() }) : 0;

            outRespnse.ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : ResponseCode.Success.GetIntValue();
            outRespnse.ResponseMessage = isNotValid ? responseMessage.CorrectedMessage : string.Empty;
            outRespnse.MessageType = !isNotValid ? string.Empty : outRespnse.MessageType;
            outRespnse.ResponseData = isNotValid ? responseMessage?.CorrectedMessage : result?.Data?.ToJsonSerialize();

            var messageType = checkValidReturnCode ? MessageTypeId.LoginSuccess.GetIntValue() : MessageTypeId.LoginUnSuccess.GetIntValue();

            var isAccessToken = result?.Data?.AccessToken is not null;

            #region IF Return Code  Zero or Not
            var esbMessageResponse = result?.Data is not null && !checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, messageType, result.Data.ReturnCode) : await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, messageType, result.Data.ReturnCode);
            outRespnse.ResponseMessage = esbMessageResponse is not null ? esbMessageResponse.StandardMessageDesc : outRespnse.ResponseMessage;
            outRespnse.MessageType = esbMessageResponse is not null ? esbMessageResponse.MessageType : outRespnse.MessageType;
            var esbMessageMaster = result?.Data is null || !checkValidReturnCode ? await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.UnableToParseLogin.GetIntValue()) : null;
            outRespnse.ResponseMessage = esbMessageMaster is not null ? esbMessageMaster.CorrectedMessage : outRespnse.ResponseMessage;
            outRespnse.MessageType = esbMessageMaster is not null ? MessageType.Exclam.GetStringValue() : outRespnse.MessageType;
            outRespnse.ResponseCode = esbMessageMaster is not null ? ResponseCode.Failure.GetIntValue() : outRespnse.ResponseCode;

            if (result?.Data is not null && !checkValidReturnCode && (esbMessageResponse is not null || esbMessageMaster is not null))
                return outRespnse;

            #endregion

            #region IF Access Token Is Null
            esbMessageMaster = !isAccessToken ? await _esbMessageService.GetEsbMessageByIdAsync(MessageTypeId.ServerError.GetIntValue()) : null;
            outRespnse.ResponseMessage = esbMessageMaster is not null ? esbMessageMaster.CorrectedMessage : outRespnse.ResponseMessage;
            outRespnse.MessageType = esbMessageMaster is not null ? MessageType.Exclam.GetStringValue() : outRespnse.MessageType;

            if (esbMessageMaster is not null)
                return outRespnse;

            #endregion

            #region IF Access Token Is Not NULL And Save GeoUser Data
            var isSave = await SaveUserGeoInfoAsync(loginData, authenticationRequest.RequestId, result?.Data?.UserDetails?.UserClass?.Code, result?.Data?.BalancesList?.Length > 0 ? result?.Data?.BalancesList[0].AccountNo : string.Empty);
            #endregion

            #region IF User Details Not Found
            var branchCodeNotExist = result?.Data?.UserDetails?.UserClass?.Code is null ? await _esbMessageService.GetEsbMessageByIdAsync(ResponseCode.UserDetailsNotFound.GetIntValue()) : null;
            outRespnse.ResponseCode = branchCodeNotExist is not null ? ResponseCode.Failure.GetIntValue() : outRespnse.ResponseCode;
            outRespnse.ResponseMessage = branchCodeNotExist is not null ? branchCodeNotExist.CorrectedMessage : outRespnse.ResponseMessage;
            outRespnse.MessageType = branchCodeNotExist is not null ? MessageType.Exclam.GetStringValue() : outRespnse.MessageType;
            //outRespnse.ResponseData = "{\"Login_Data\":" + outRespnse.ResponseData + "}";
            outRespnse.ResponseData = new LoginDataResponse { LoginData = outRespnse.ResponseData }.ToJsonSerialize();

            if (branchCodeNotExist is not null)
                return outRespnse;
            #endregion

            #region Get User Type
            var userType = await _userRepositories.GetUserTypeAsync(result?.Data?.UserDetails?.UserClass?.Code);
            #endregion

            //Start-RN2041 casa addendum addition
            #region Check EAgreement & Check CASAaddendum
            var checkEAgreement = userType is not null && userType?.UserRole > 0 && userType?.EAgreement == 1 ? await _userRepositories.CheckEagreementAsync(result?.Data?.UserDetails?.Name, result?.Data?.UserDetails?.Identifier?.ToString(), _appSettings.AgreementExpiryday) : 0;
            var checkcasAaddendum = userType is not null && userType?.UserRole > 0 && userType?.EAgreement == 1 ? await _userRepositories.CheckCASAaddendumAsync(result?.Data?.UserDetails?.Identifier?.ToString()) : 0;
            #endregion

            #region Check FilebaseCasa
            var checkFilebaseCasa = await _userRepositories.CheckFilebaseCasaAsync(result?.Data?.UserDetails?.Identifier?.ToString());
            #endregion

            #region Check Survey
            var checkSurvey = userType?.Survey is 1 ? await _userRepositories.CheckSurveyAsync(loginData?.SystemInfo?.Channel, result?.Data?.UserDetails?.UserClass?.Code, loginData?.ClientId, authenticationRequest?.TellerId) : 0;
            #endregion

            #region Check Category Code
            var checkCategoryCode = await _userRepositories.CheckCategoryCodeAsync(result?.Data?.UserDetails?.Identifier?.ToString());
            #endregion

            #region Check Offer Consent
            var checkOfferConsent = await _userRepositories.CheckOfferConsentAsync(result?.Data?.UserDetails?.Identifier?.ToString());
            #endregion

            #region Check Rewrd Points
            var checkRewrdPoints = await _userRepositories.CheckLoyaltyRewardsAsync(result?.Data?.UserDetails?.Identifier?.ToString());
            #endregion

            #region Get Last Download date

            var lstDownload = await _userRepositories.GetLastDownloadAsync();
            var checkZeroeDate = await _userRepositories.GetGLZeroizeDateTimeAsync(loginData.UserId);
            var dataVersion = string.Empty;
            switch (loginData.SystemInfo.Channel)
            {
                case "2":

                    var LoginResponseData = new CommonChannelIdTwo
                    {
                        LoginData = outRespnse.ResponseData,
                        SessionId = authenticationRequest.SessionId,
                        NoOfFinger = _appSettings.NoOfFinger.ToString(),
                        Threshold = _appSettings.Threshold.ToString(),
                        UserTypeId = userType.UserTypeId.ToString(),
                        UserRole = userType.UserRole.ToString(),
                        EAgreement = userType.EAgreement.ToString(),
                        CASAeAgreement = userType.CASAEagreement.ToString(),
                        RewardPoints = checkRewrdPoints.ToString(),
                        EAgreementChanged = checkEAgreement,
                        CASAaddendum = checkcasAaddendum,
                        FilebaseCasa = checkFilebaseCasa,
                        ESurvey = checkSurvey,
                        ChannelID = loginData.SystemInfo.Channel.ToString(),
                        ZeroizationDateTime = checkZeroeDate.ToString(),
                        StrConsent = checkOfferConsent.ConsentYN,
                        StrOffer = checkOfferConsent.OfferYN,
                        LastDownloadDate = lstDownload.ToString(),
                        CategoryCode = checkCategoryCode.ToString()
                    };

                    outRespnse.ResponseData = LoginResponseData.ToJsonSerialize();

                    //line 1096
                    break;
                case "1":
                    //required base logic impliment inside GetDBVersion
                    var dbVersion = _appSettings.IsCacheFromDB is 1 ? await _userRepositories.GetDbVersionAsync(new DbVersion { MasterVersion = "MastersVersion" }) : null;
                    dataVersion = $"{dataVersion}{dbVersion}";
                    dataVersion = dataVersion.Remove(dbVersion.Length - 1);


                    //Get Master Version
                    dataVersion = _appSettings.IsCacheFromDB is not 1 ? await _userRepositories.GetVersionFromCacheAsync("MastersVersion", true) : dataVersion;
                    dataVersion = $"{dataVersion} |";


                    //Get Mobile Version

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionCommanAsync($"ProfileTypeDataMenu{userType.UserTypeId}{loginData.SystemInfo.Channel}")}";

                    //Get Profile Type

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionCommanAsync($"ProfileTypeMasterData{userType.UserTypeId}{loginData.SystemInfo.Channel}")}";

                    //1207
                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionCommanAsync($"ProductTransMap{userType.UserTypeId}{loginData.SystemInfo.Channel}")}";


                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionCommanAsync($"MobSequenceMasterList")}";

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionCommanAsync($"MobileTabCntrl")}";

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionCommanAsync($"IINMasterMob")}";


                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionCommanAsync($"MstPrintFormat1")}";

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionCommanAsync($"mstCrossSelling{userType.UserTypeId}{loginData.SystemInfo.Channel}")}";


                    dataVersion = $"{dataVersion}{await _userRepositories.GetProductTypesAsync("MobileTabCntrl")}";

                    dataVersion = dataVersion.Remove(dataVersion.Length - 1);

                    #region FOS DATA
                    var fosData = new FosAppVersion();

                    var authenticaterType = loginData?.ClientId.ToString() == AuthenticatorType.FINOTLR.GetStringValue() || loginData?.ClientId.ToString() == AuthenticatorType.FINOMB.GetStringValue() ? AuthenticatorType.FINOTLR : loginData?.ClientId.ToString() == AuthenticatorType.FINOMER.GetStringValue() || loginData?.ClientId.ToString() == AuthenticatorType.FINOMERNP.GetStringValue() ? AuthenticatorType.FINOMER : AuthenticatorType.FINOMER;

                    if (loginData?.ClientId.ToString() == AuthenticatorType.FINOTLR.GetStringValue() || loginData?.ClientId.ToString() == AuthenticatorType.FINOMB.GetStringValue())
                    {
                        loginData.ClientId = AuthenticatorType.FINOTLR.GetStringValue();
                        fosData = await _userRepositories.GetFosVersionAsync(AuthenticatorType.FINOTLR.GetStringValue(), $"FOSAppVersionNew{AuthenticatorType.FINOTLR.GetStringValue()}{loginData.SystemInfo.Channel}");
                    }
                    else if (loginData?.ClientId.ToString() == AuthenticatorType.FINOMER.GetStringValue() || loginData?.ClientId.ToString() == AuthenticatorType.FINOMERNP.GetStringValue())
                    {
                        loginData.ClientId = AuthenticatorType.FINOMER.GetStringValue();
                        fosData = await _userRepositories.GetFosVersionAsync(AuthenticatorType.FINOMER.GetStringValue(), $"MERAppVersionNew{AuthenticatorType.FINOMER.GetStringValue()}{loginData.SystemInfo.Channel}");
                    }
                    else
                    {
                        loginData.ClientId = AuthenticatorType.FINOIPS.GetStringValue();
                        fosData = await _userRepositories.GetFosVersionAsync(AuthenticatorType.FINOIPS.GetStringValue(), $"MERAppVersionNew{AuthenticatorType.FINOIPS.GetStringValue()}{loginData.SystemInfo.Channel}");
                    }
                    #endregion

                    #region Get Certificate Expiry Date
                    var expiryDate = await _userRepositories.GetAuaExpiryDataAsync(1, 11);
                    #endregion

                    #region Get FOS MOBILE VERSION
                    var fosMobileVersion = await _userRepositories.GetMobileVersionDataAsync("mstMobileVersion");

                    #endregion

                    var LoginResponseOne = new CommonChannelIdOne
                    {
                        LoginData = outRespnse.ResponseData,
                        UserId = loginData?.UserId,
                        UserTypeId = userType.UserTypeId.ToString(),
                        UserRole = userType.UserRole.ToString(),
                        EAgreement = userType.EAgreement.ToString(),
                        CASAeAgreement = userType.CASAEagreement.ToString(),
                        RewardPoints = checkRewrdPoints.ToString(),
                        EAgreementChanged = checkEAgreement,
                        CASAaddendum = checkcasAaddendum,
                        FilebaseCasa = checkFilebaseCasa,
                        ESurvey = checkSurvey,
                        CertificateExpiryDate = expiryDate,
                        MandatoryVersion = fosData.MandatoryVersion,
                        CurrentVersion = fosData.CurrentVersion,
                        EvMandat = fosMobileVersion.EvMandat,
                        EvCurrent = fosMobileVersion.EvCurrent,
                        MorpMandat = fosMobileVersion.MorpMandat,
                        MorpCurrent = fosMobileVersion.MorpCurrent,
                        ZeroizationDateTime = checkZeroeDate,
                        ChannelID = loginData.SystemInfo.Channel,
                        MastersVersion = dataVersion,
                        StrConsent = checkOfferConsent.ConsentYN,
                        StrOffer = checkOfferConsent.OfferYN,
                        LastDownloadDate = lstDownload.ToString(),
                        CategoryCode = checkCategoryCode.ToString()
                    };

                    outRespnse.ResponseData = LoginResponseOne.ToJsonSerialize();
                    break;

                case "3":
                    if (loginData?.ClientId.ToString() == AuthenticatorType.FINOPDS.GetStringValue())
                    {

                        fosData = await _userRepositories.GetFosVersionAsync(AuthenticatorType.FINOPDS.GetStringValue(), $"PDSAppVersion{AuthenticatorType.FINOPDS.GetStringValue()}{loginData.SystemInfo.Channel}");

                        var LoginResponseThree = new CommonChannelIdThree
                        {
                            LoginData = outRespnse.ResponseData,
                            UserId = loginData?.UserId,
                            UserTypeId = userType.UserTypeId.ToString(),
                            UserRole = userType.UserRole.ToString(),
                            EAgreement = userType.EAgreement.ToString(),
                            CASAeAgreement = userType.CASAEagreement.ToString(),
                            RewardPoints = checkRewrdPoints.ToString(),
                            EAgreementChanged = checkEAgreement,
                            CASAaddendum = checkcasAaddendum,
                            FilebaseCasa = checkFilebaseCasa,
                            ESurvey = checkSurvey,
                            CertificateExpiryDate = string.Empty,
                            MandatoryVersion = fosData.MandatoryVersion,
                            CurrentVersion = fosData.CurrentVersion,
                            ZeroizationDateTime = checkZeroeDate,
                            ChannelID = loginData.SystemInfo.Channel,
                            MastersVersion = dataVersion,
                            StrConsent = checkOfferConsent.ConsentYN,
                            StrOffer = checkOfferConsent.OfferYN,
                            LastDownloadDate = lstDownload.ToString(),
                            CategoryCode = checkCategoryCode.ToString()
                        };
                        outRespnse.ResponseData = LoginResponseThree.ToJsonSerialize();
                    }
                    break;
                case "6":
                    if (loginData?.ClientId.ToString() == AuthenticatorType.FINOINGE.GetStringValue())
                    {
                        fosData = await _userRepositories.GetFosVersionAsync(AuthenticatorType.FINOINGE.GetStringValue(), $"INGEAppVersion{AuthenticatorType.FINOINGE.GetStringValue()}{loginData.SystemInfo.Channel}");
                        var LoginResponseSix = new CommonChannelIdThree
                        {
                            LoginData = outRespnse.ResponseData,
                            UserId = loginData?.UserId,
                            UserTypeId = userType.UserTypeId.ToString(),
                            UserRole = userType.UserRole.ToString(),
                            EAgreement = userType.EAgreement.ToString(),
                            CASAeAgreement = userType.CASAEagreement.ToString(),
                            RewardPoints = checkRewrdPoints.ToString(),
                            EAgreementChanged = checkEAgreement,
                            CASAaddendum = checkcasAaddendum,
                            FilebaseCasa = checkFilebaseCasa,
                            ESurvey = checkSurvey,
                            CertificateExpiryDate = string.Empty,
                            MandatoryVersion = fosData.MandatoryVersion,
                            CurrentVersion = fosData.CurrentVersion,
                            ZeroizationDateTime = checkZeroeDate,
                            ChannelID = loginData.SystemInfo.Channel,
                            MastersVersion = dataVersion,
                            StrConsent = checkOfferConsent.ConsentYN,
                            StrOffer = checkOfferConsent.OfferYN,
                            LastDownloadDate = lstDownload.ToString(),
                            CategoryCode = checkCategoryCode.ToString()
                        };
                        outRespnse.ResponseData = LoginResponseSix.ToJsonSerialize();
                    }
                    break;

                default:
                    fosData = await _userRepositories.GetFosVersionAsync(AuthenticatorType.FINOMER.GetStringValue(), $"FINOMERAppVersion{AuthenticatorType.FINOMER.GetStringValue()}{loginData.SystemInfo.Channel}");
                    var LoginResponseDefault = new CommonChannelIdThree
                    {
                        LoginData = outRespnse.ResponseData,
                        UserId = loginData?.UserId,
                        UserTypeId = userType.UserTypeId.ToString(),
                        UserRole = userType.UserRole.ToString(),
                        EAgreement = userType.EAgreement.ToString(),
                        CASAeAgreement = userType.CASAEagreement.ToString(),
                        RewardPoints = checkRewrdPoints.ToString(),
                        EAgreementChanged = checkEAgreement,
                        CASAaddendum = checkcasAaddendum,
                        FilebaseCasa = checkFilebaseCasa,
                        ESurvey = checkSurvey,
                        CertificateExpiryDate = string.Empty,
                        MandatoryVersion = fosData.MandatoryVersion,
                        CurrentVersion = fosData.CurrentVersion,
                        ZeroizationDateTime = checkZeroeDate,
                        ChannelID = loginData.SystemInfo.Channel,
                        MastersVersion = dataVersion,
                        StrConsent = checkOfferConsent.ConsentYN,
                        StrOffer = checkOfferConsent.OfferYN,
                        LastDownloadDate = lstDownload.ToString(),
                        CategoryCode = checkCategoryCode.ToString()
                    };
                    outRespnse.ResponseData = LoginResponseDefault.ToJsonSerialize();
                    break;
            }
            #endregion

            return outRespnse;
        }

        public async Task<OutResponse> VerifyUserIdAsync(AuthenticationRequest authenticationRequest)
        {
            var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<FIsUserAuthmanPolicyRequest>();

            replyData.UserId = replyData.EcbBlockEncryption ? replyData.UserId.ToDecryptEcbBlock(_appSettings.DecryptKey)
               : replyData.UserId.ToDecryptStringAES(_appSettings.DecryptKey, _appSettings.DecryptKeygen);

            replyData.OldUserId = replyData.EcbBlockEncryption ? replyData.OldUserId.ToDecryptEcbBlock(_appSettings.DecryptKey)
                 : replyData.OldUserId.ToDecryptStringAES(_appSettings.DecryptKey, _appSettings.DecryptKeygen);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var outRespnse = replyData.UserId == replyData.OldUserId ? await ValidateUserAsync(authenticationRequest) : await GetUserAuthmanAsync(authenticationRequest, replyData, AuthmanOptions.GenerateOTP);

            var result = outRespnse.ResponseData.ToJsonDeSerialize<FisUserValidateResponse>();

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.ReturnCode);

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.ToJsonSerialize() });
            outRespnse = await CommanBlockUserAsync(result, outRespnse, checkValidReturnCode);

            return outRespnse;
        }

        public async Task<OutResponse> LogOutUserAsync(AuthenticationRequest logOutRequest)
        {
            var replyData = logOutRequest.RequestData.ToJsonDeSerialize<dynamic>();
            replyData.access_token = logOutRequest.XAuthToken;

            var logOutUrl = await GetEsbUrlAsync(EsbUrls.EsbLogoutUrl);

            var request = GetWebRequestSettings<dynamic>(logOutUrl, replyData, logOutRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = logOutRequest.ServiceID, MethodId = logOutRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = logOutRequest.RequestId, CorelationSession = logOutRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = logOutRequest.RequestId, TokenID = logOutRequest.TokenId, TellerID = logOutRequest.TellerId, UserID = logOutRequest.ReturnId(), SessionID = logOutRequest.SessionId, MethodId = logOutRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {logOutRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);         

            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;
            var isLogOut = result.Data?.ResponseData is "Successfully Logout";

            var esbMessagesdata = isLogOut ? await _esbMessageService.GetEsbMessageByIdAsync(MessageTypeId.LogoutSuccessful.GetIntValue()) : await _esbMessageService.GetEsbMessageByIdAsync(MessageTypeId.LogoutFailed.GetIntValue());
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = logOutRequest.RequestId, TokenID = logOutRequest.TokenId, TellerID = logOutRequest.TellerId, UserID = logOutRequest.ReturnId(), SessionID = logOutRequest.SessionId, MethodId = logOutRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = logOutRequest.ServiceID, MethodId = logOutRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = logOutRequest.RequestId, CorelationSession = logOutRequest.SessionId, StatusCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : !isLogOut ? ResponseCode.Failure.GetIntValue() : ResponseCode.Success.GetIntValue(), ResponseMessage = result.ToJsonSerialize() });
            
            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                SessionExpiryTime = SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired),
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : !isLogOut ? ResponseCode.Failure.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = esbMessagesdata.CorrectedMessage,
                ResponseMessage_Hindi = esbMessagesdata.HindiMessage,
                MessageType = isNotValid || !isLogOut ? MessageType.Exclam.GetStringValue() : MessageType.Info.GetStringValue(),
                ResponseData = result.Data.ToJsonSerialize()
            };
            return outRespnse;
        }

        public async Task<OutResponse> GetAuthContextAsync(AuthenticationRequest authContextRequest)
        {

            return await GetCommonAsync<dynamic>(authContextRequest, EsbUrls.EsbAuthContextUrl, MessageTypeId.AuthContextDetailsSuccess, MessageTypeId.AuthContextDetailsFailed);

            //var replyData = authContextRequest.RequestData.ToJsonDeSerialize<dynamic>();

            //var authContextUrl = await GetEsbUrlAsync(EsbUrls.EsbAuthContextUrl);

            //var request = GetWebRequestSettings<dynamic>(authContextUrl, replyData, authContextRequest);

            //var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);

            //var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            //var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            //var esbMessagesdata = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.AuthContextDetailsSuccess.GetIntValue(), result.Data.ReturnCode) : await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.AuthContextDetailsFailed.GetIntValue(), result.Data.ReturnCode);

            //var outRespnse = new OutResponse
            //{
            //    RequestId = request.RequestId,
            //    SessionExpiryTime = checkValidReturnCode ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : string.Empty,
            //    ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : !checkValidReturnCode ? ResponseCode.Failure.GetIntValue() : ResponseCode.Success.GetIntValue(),
            //    ResponseMessage = esbMessagesdata.CorrectedMessage,
            //    ResponseMessage_Hindi = esbMessagesdata.HindiMessage,
            //    MessageType = esbMessagesdata.MessageType,
            //    ResponseData = result.Data.ToJsonSerialize()
            //};

            //return outRespnse;
        }

        public async Task<OutResponse> GetEsbFpAsync(AuthenticationRequest esbFpRequest)
        {
            var replyData = esbFpRequest.RequestData.ToJsonDeSerialize<dynamic>();

            var esbFpUrl = await GetEsbUrlAsync(EsbUrls.EsbFpVerificationUrl);


            var request = GetWebRequestSettings<dynamic>(esbFpUrl, replyData, esbFpRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = esbFpRequest.ServiceID, MethodId = esbFpRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = esbFpRequest.RequestId, CorelationSession = esbFpRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = esbFpRequest.RequestId, TokenID = esbFpRequest.TokenId, TellerID = esbFpRequest.TellerId, UserID = esbFpRequest.ReturnId(), SessionID = esbFpRequest.SessionId, MethodId = esbFpRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {esbFpRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);
            
            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            var esbMessageAlert = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.FpVerificationSuccess.GetIntValue(), result.Data.ReturnCode) : null;

            var esbMessageFaield = !checkValidReturnCode ? await _esbMessageService.GetEsbMessageByIdAsync(MessageTypeId.FpVerificationFailed.GetIntValue()) : null;

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = esbFpRequest.RequestId, TokenID = esbFpRequest.TokenId, TellerID = esbFpRequest.TellerId, UserID = esbFpRequest.ReturnId(), SessionID = esbFpRequest.SessionId, MethodId = esbFpRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = esbFpRequest.ServiceID, MethodId = esbFpRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = esbFpRequest.RequestId, CorelationSession = esbFpRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() });
            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                SessionExpiryTime = checkValidReturnCode ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : string.Empty,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : (!checkValidReturnCode) ? ResponseCode.Failure.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.CorrectedMessage : (esbMessageFaield is not null && !checkValidReturnCode) ? esbMessageFaield.CorrectedMessage : string.Empty,
                ResponseMessage_Hindi = !checkValidReturnCode ? esbMessageFaield.HindiMessage : string.Empty,
                MessageType = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.MessageType : !checkValidReturnCode ?? MessageType.Exclam.GetStringValue(),
                ResponseData = result.Data.ToJsonSerialize()
            };

            return outRespnse;

        }

        public async Task<OutResponse> ValidateTokenAsync(AuthenticationRequest authenticationRequest)
        {

            return await GetCommonAsync<dynamic>(authenticationRequest, EsbUrls.EsbValidateTokenUrl, MessageTypeId.TokenValidationSuccess, MessageTypeId.TokenValidationFailed);

            //var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<dynamic>();

            //var esbValidateTokenUrl = await GetEsbUrlAsync(EsbUrls.EsbValidateTokenUrl);

            //var request = GetWebRequestSettings<dynamic>(esbValidateTokenUrl, replyData, authenticationRequest);

            //var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);

            //var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            //var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            //var esbMessageAlert = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.TokenValidationSuccess.GetIntValue(), result.Data.ReturnCode) : await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.TokenValidationFailed.GetIntValue(), result.Data.ReturnCode);

            //var outRespnse = new OutResponse
            //{
            //    RequestId = request.RequestId,
            //    SessionExpiryTime = checkValidReturnCode ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : string.Empty,
            //    ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
            //    ResponseMessage = esbMessageAlert.CorrectedMessage,
            //    MessageType = esbMessageAlert.MessageType,
            //    ResponseData = result.Data.ToJsonSerialize()
            //};

            //return outRespnse;
        }

        public async Task<OutResponse> UserUnlockAsync(AuthenticationRequest authenticationRequest)
        {
            var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<dynamic>();

            var esbUrl = await GetEsbUrlAsync(EsbUrls.ESBUnlockUserDetailsUrl);

            var request = GetWebRequestSettings<dynamic>(esbUrl, replyData, authenticationRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);

            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            var esbMessageAlert = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.UserUnlockSuccess.GetIntValue(), result.Data.ReturnCode) : null;

            var esbMessageFaield = !checkValidReturnCode ? await _esbMessageService.GetEsbMessageByIdAsync(MessageTypeId.UserUnlockFailed.GetIntValue()) : null;

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() });

            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                SessionExpiryTime = checkValidReturnCode ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : string.Empty,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : (!checkValidReturnCode) ? ResponseCode.Failure.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.CorrectedMessage : (esbMessageFaield is not null && !checkValidReturnCode) ? esbMessageFaield.CorrectedMessage : string.Empty,
                ResponseMessage_Hindi = !checkValidReturnCode ? esbMessageFaield.HindiMessage : string.Empty,
                MessageType = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.MessageType : !checkValidReturnCode ?? MessageType.Exclam.GetStringValue(),
                ResponseData = result.Data.ToJsonSerialize()
            };

            return outRespnse;
        }

        public async Task<OutResponse> GetSecretQuestionAsync(AuthenticationRequest authenticationRequest)
        {
            var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<dynamic>();

            var esbUrl = await GetEsbUrlAsync(EsbUrls.EsbGetSecretQuestion);

            var request = GetWebRequestSettings<dynamic>(esbUrl, replyData, authenticationRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);

            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            var esbMessageAlert = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.GetSecretQuestionSuccess.GetIntValue(), result.Data.ReturnCode) : null;

            var esbMessageFaield = !checkValidReturnCode ? await _esbMessageService.GetEsbMessageByIdAsync(MessageTypeId.GetSecretQuestionFailed.GetIntValue()) : null;

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() });
            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                SessionExpiryTime = checkValidReturnCode ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : string.Empty,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : (!checkValidReturnCode) ? ResponseCode.Failure.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.CorrectedMessage : (esbMessageFaield is not null && !checkValidReturnCode) ? esbMessageFaield.CorrectedMessage : string.Empty,
                ResponseMessage_Hindi = !checkValidReturnCode ? esbMessageFaield.HindiMessage : string.Empty,
                MessageType = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.MessageType : !checkValidReturnCode ?? MessageType.Exclam.GetStringValue(),
                ResponseData = result.Data.ToJsonSerialize()
            };

            return outRespnse;
        }

        public async Task<OutResponse> UserFpAuthenticationAsync(AuthenticationRequest authenticationRequest)
        {
            var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<dynamic>();

            var esbUrl = await GetEsbUrlAsync(EsbUrls.EsbUserFPAuthentication);

            var request = GetWebRequestSettings<dynamic>(esbUrl, replyData, authenticationRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);

            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            var esbMessageAlert = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.AuthenticateSuccess.GetIntValue(), result.Data.ReturnCode) : await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.AuthenticateUnSuccess.GetIntValue(), result.Data.ReturnCode);

            var isMessageTypeInfo = result?.Data?.MessageTyep == MessageType.Info;

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() });
            
            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                ResponseCode = (isNotValid) ? ResponseCode.RemoteServerError.GetIntValue() : (checkValidReturnCode && isMessageTypeInfo) ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = esbMessageAlert.CorrectedMessage,
                MessageType = esbMessageAlert.MessageType,
                ResponseData = result.Data.ToJsonSerialize()
            };

            return outRespnse;
        }

        public async Task<OutResponse> ValidateSecretQuestionAsync(AuthenticationRequest authenticationRequest)
        {
            var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<dynamic>();

            var esbUrl = await GetEsbUrlAsync(EsbUrls.EsbUserValidateSecretQuestion);

            var request = GetWebRequestSettings<dynamic>(esbUrl, replyData, authenticationRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<dynamic, dynamic>(request);

            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);

            var esbMessageAlert = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.ValidateUserSecretQuestionSuccess.GetIntValue(), result.Data.ReturnCode) : null;

            var esbMessageFaield = !checkValidReturnCode ? await _esbMessageService.GetEsbMessageByIdAsync(MessageTypeId.ValidateUserSecretQuestionFailed.GetIntValue()) : null;

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() });
            
            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                SessionExpiryTime = checkValidReturnCode ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : string.Empty,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : (!checkValidReturnCode) ? ResponseCode.Failure.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.CorrectedMessage : (esbMessageFaield is not null && !checkValidReturnCode) ? esbMessageFaield.CorrectedMessage : string.Empty,
                ResponseMessage_Hindi = !checkValidReturnCode ? esbMessageFaield.HindiMessage : string.Empty,
                MessageType = (esbMessageAlert is not null && checkValidReturnCode) ? esbMessageAlert.MessageType : !checkValidReturnCode ?? MessageType.Exclam.GetStringValue(),
                ResponseData = result.Data.ToJsonSerialize()
            };

            return outRespnse;
        }

        public async Task<OutResponse> GetEncryptionKeyAsync(AuthenticationRequest authenticationRequest)
        {
            return await GetCommonAsync<dynamic>(authenticationRequest, EsbUrls.EsbURLGetEncryptKey, MessageTypeId.EncryptedKeySuccess, MessageTypeId.UnableToGetEncryptionKey);
        }


        #region Internal Method

        internal async Task<string> GetEsbUrlAsync(EsbUrls esbUrl)
        {
            return (await _esbUrlMemoryService.GetEsbUrlByIdAsync(esbUrl, ServiceName.LOGINSERVICE)).ESBUrl;
        }

        internal WebApiRequestSettings<T1> GetWebRequestSettings<T1>(string esbUrl, T1 data, AuthenticationRequest request) where T1 : new()
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

        internal async Task<OutResponse> GetCommonAsync<TRequest>(AuthenticationRequest authenticationRequest, EsbUrls esbUrls, MessageTypeId successType, MessageTypeId failType) where TRequest : new()
        {
            var replyData = authenticationRequest.RequestData.ToJsonDeSerialize<TRequest>();

            var esbUrl = await GetEsbUrlAsync(esbUrls);

            var request = GetWebRequestSettings<TRequest>(esbUrl, replyData, authenticationRequest);

            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<TRequest, TRequest>(request);

            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;


            var returnCode = typeof(TRequest).GetProperty("ReturnCode").GetValue(result.Data) as int?;

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(returnCode);

            var esbMessageAlert = checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, successType.GetIntValue(), returnCode) : await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, failType.GetIntValue(), returnCode);

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Error.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() });
            
            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                SessionExpiryTime = checkValidReturnCode ? SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired) : string.Empty,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : checkValidReturnCode ? ResponseCode.Success.GetIntValue() : ResponseCode.Failure.GetIntValue(),
                ResponseMessage = esbMessageAlert.StandardMessageDesc,
                MessageType = esbMessageAlert.MessageType,
                ResponseData = result.Data.ToJsonSerialize()
            };

            return outRespnse;
        }

        internal async Task<OutResponse> GetUserAuthmanAsync(AuthenticationRequest authenticationRequest, FIsUserAuthmanPolicyRequest replyData, AuthmanOptions authmanOptions)
        {

            var esbUrl = await GetEsbUrlAsync(EsbUrls.EsbCheckAuthenticationUrl);


            var request = new WebApiRequestSettings<FIsUserAuthmanPolicyRequest>
            {
                URL = esbUrl,
                PostParameter = replyData,
                Timeout = _appSettings.Timeout,
                XAuthToken = authenticationRequest.XAuthToken,
                RequesterId = authenticationRequest.ReturnId(),
                RequestId = authenticationRequest.RequestId
            };
            await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.BLL.GetIntValue(), RequestFlag = true, ResponseFlag = false, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = DefaultStatus.Default.GetIntValue(), ResponseMessage = "Authentication Service" });
            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBREQUEST} {authenticationRequest.RequestData}", PriorityId = LogPriority.BL1.GetIntValue() });

            var result = await _webApiRequestService.PostAsync<FisUserValidateResponse, FIsUserAuthmanPolicyRequest>(request);

            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            var esbMessagesdata = new EsbMessages();
            if (result.StatusCode is 503)
                esbMessagesdata = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.ServerUnavailable.GetIntValue());
            else if (result.StatusCode is not 200 && result.StatusCode is not 503)
                esbMessagesdata = await _esbMessageService.GetEsbMessage(string.Empty, ResponseCode.RemoteServerError.GetStringValue(), result.ErrorMessage);

            await _loggerService.WriteFillLogAsync(new FillLoggerRequest { RequestID = authenticationRequest.RequestId, TokenID = authenticationRequest.TokenId, TellerID = authenticationRequest.TellerId, UserID = authenticationRequest.ReturnId(), SessionID = authenticationRequest.SessionId, MethodId = authenticationRequest.MethodId, Module = new TraceCalling().ToModule(), Message = $"{CommonValues.ESBRESPONSE} {result.Data.ToJsonSerialize()}", PriorityId = LogPriority.BL2.GetIntValue() });
            var islogService = isNotValid ? await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = EsbsMessages.ServerUnavailable.GetIntValue(), ResponseMessage = "ESB Server UnAvailable" }) : 0;
            islogService = !isNotValid ? await _loggerService.WriteCorelationLogAsync(new CorelationLoggerRequest { ServiceId = authenticationRequest.ServiceID, MethodId = authenticationRequest.MethodId, LayerId = LayerType.ESB.GetIntValue(), RequestFlag = false, ResponseFlag = true, CorelationRequest = authenticationRequest.RequestId, CorelationSession = authenticationRequest.SessionId, StatusCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : ResponseCode.Success.GetIntValue(), ResponseMessage = result.Data?.ToJsonSerialize() }) : 0;

            var outRespnse = new OutResponse
            {
                RequestId = request.RequestId,
                ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : ResponseCode.Success.GetIntValue(),
                ResponseMessage = isNotValid ? esbMessagesdata?.CorrectedMessage : string.Empty,
                MessageType = isNotValid ? MessageType.Exclam.GetStringValue() : string.Empty,
                ResponseData = result?.Data?.ToJsonSerialize()
            };
            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);
            if (!checkValidReturnCode)
                return outRespnse;

            if (checkValidReturnCode && result.Data.EncryptionKey is not null && AuthmanOptions.GenerateOTP == authmanOptions)
            {
                var userRole = result.Data.UserRoles.LastOrDefault();
                var userType = await _userRepositories.GetUserTypeAsync(userRole);
                var isLoginOTP = userType?.LoginOTP is false and false;

                if (isLoginOTP)
                {
                    var esbcbsMessage = await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.AuthenticateSuccess.GetIntValue(), result.Data.ReturnCode);
                    outRespnse.ResponseMessage = esbcbsMessage.StandardMessageDesc;
                    outRespnse.MessageType = esbcbsMessage.MessageType;
                    outRespnse.SessionExpiryTime = SessionExpireTime.GetSessionExpireTime(_appSettings.SessionExpired);
                    outRespnse.AuthmanFlag = true;
                }
                else
                {
                    #region SendOTP
                    var otpData = new OtpRequest { MethodId = 1, CustomerMobileNo = result.Data.MobileNo, NotifyParam = new NotifyParameter { TemplateId = 523 } };
                    var otpRequestData = authenticationRequest.Clone();
                    otpRequestData.MethodId = 1; otpRequestData.IsEncrypt = false;
                    otpRequestData.RequestData = otpData.ToJsonSerialize();


                    var otpEsbUrl = await GetEsbUrlAsync(EsbUrls.EsbLoginSendOTP);

                    var otpRequest = new WebApiRequestSettings<dynamic>
                    {
                        URL = otpEsbUrl,
                        PostParameter = otpRequestData,
                        Timeout = _appSettings.Timeout,
                        XAuthToken = authenticationRequest.XAuthToken,
                        RequesterId = authenticationRequest.ReturnId(),
                        RequestId = authenticationRequest.RequestId
                    };

                    var otpResult = await _webApiRequestService.PostAsync<dynamic, dynamic>(otpRequest);

                    isNotValid = otpResult.StatusCode is not (int)HttpStatusCode.OK;

                    esbMessagesdata = new EsbMessages();
                    if (otpResult.StatusCode is 503)
                        esbMessagesdata = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.ServerUnavailable.GetIntValue());
                    else if (otpResult.StatusCode is not 200 && otpResult.StatusCode is not 503)
                        esbMessagesdata = await _esbMessageService.GetEsbMessage(string.Empty, ResponseCode.RemoteServerError.GetStringValue(), result.ErrorMessage);

                    outRespnse = new OutResponse
                    {
                        RequestId = otpRequestData.RequestId,
                        ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : ResponseCode.Success.GetIntValue(),
                        ResponseMessage = isNotValid ? esbMessagesdata.CorrectedMessage : string.Empty,
                        MessageType = isNotValid ? MessageType.Exclam.GetStringValue() : MessageType.Info.GetStringValue(),
                        AuthmanFlag = !!isNotValid,
                        ResponseData = otpResult.Data.ToJsonSerialize()
                    };

                    #endregion
                }
            }
            else
            {
                var esbcbsMessage = await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, MessageTypeId.AuthenticateUnSuccess.GetIntValue(), result.Data.ReturnCode);
                outRespnse.ResponseCode = ResponseCode.Failure.GetIntValue();
                outRespnse.ResponseMessage = esbcbsMessage.StandardMessageDesc;
                outRespnse.MessageType = esbcbsMessage.MessageType;
            }

            if (result?.Data is null && !checkValidReturnCode)
            {
                outRespnse.ResponseMessage = $"Unable to parse Authman response.";
                outRespnse.MessageType = MessageType.Exclam.GetStringValue();
            }

            return outRespnse;
        }

        internal async Task<Boolean> RestrictUserAccess(FisUserPasswordValidateRequest fisUserPasswordValidateRequest)
        {


            var isRestricted = !((fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null && fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "") &&
                       (fisUserPasswordValidateRequest?.SystemInfo?.CellId is not null) &&
                       (fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not null && fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "") &&
                       (fisUserPasswordValidateRequest?.SystemInfo?.Lattitude is not null) &&
                       (fisUserPasswordValidateRequest?.SystemInfo?.Longitude is not null));

            if (!isRestricted)
            {
                return isRestricted;
            }

            var userRestrictData = await _userRepositories.GetUserRestricationAsync(fisUserPasswordValidateRequest, _appSettings.LatitudeLongitude);

            isRestricted = userRestrictData.Any();

            return isRestricted;
        }

        internal async Task<int> SaveUserGeoInfoAsync(FisUserPasswordValidateRequest loginData, string requestId, string code, string glAccount)
        {
            var userGeoLocation = new GeoUserLocation
            {
                UserName = loginData?.UserId,
                Lattitude = loginData?.SystemInfo?.Lattitude.ToString(),
                Longitude = loginData?.SystemInfo?.Longitude.ToString(),
                PostalCode = loginData?.SystemInfo?.PostalCode,
                IPAddress = loginData?.SystemInfo?.Ip,
                TimeStamp = DateTime.Now,
                MacDeviceId = loginData?.SystemInfo?.MacDeviceId,
                CellId = loginData?.SystemInfo?.CellId,
                Channel = loginData?.SystemInfo?.Channel,
                ServiceProvider = loginData?.SystemInfo?.Isp,
                DeviceModel = loginData?.SystemInfo?.DeviceModel,
                DeviceOS = loginData?.SystemInfo?.DeviceOs,
                Mcc = loginData?.SystemInfo?.Mcc,
                Mnc = loginData?.SystemInfo?.Mnc,
                LanguageSupported = loginData?.SystemInfo?.LanguageSupported,
                AuthenticationType = loginData?.Password,
                Version = loginData?.SystemInfo?.Version,
                BrowserInfo = loginData?.SystemInfo?.Browser,
                UniqueRequestID = requestId,
                FPTemplate = $"FPTemplate",
                UserTypeName = code,
                AppDescName = loginData?.ClientId,
                GLAccount = glAccount
            };
            return await _userRepositories.AddUserGeoAsync(userGeoLocation);
        }

        internal async Task<OutResponse> CommanBlockUserAsync(FisUserValidateResponse fisUserValidate, OutResponse outResponse, bool isValid = true)
        {
            var updatedMessage = !isValid && fisUserValidate?.ReturnCode == 300 &&
                                 fisUserValidate?.BlockReasonCode is "11" &&
                                fisUserValidate?.ClientId is not "FINOMER" ? await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.BlockUser.GetIntValue()) : null;

            if (updatedMessage is not null)
            {
                outResponse.ResponseMessage = updatedMessage.CorrectedMessage;
                outResponse.ResponseMessage_Hindi = updatedMessage.HindiMessage;
            }
            else
            {
                var checkUserStatus = !isValid &&
                                        fisUserValidate?.ReturnCode is 300 && fisUserValidate?.BlockReasonCode is not "11" && fisUserValidate?.ClientId is not "FINOTLR" ?
                                        await _userRepositories.GetReasonsAsync(fisUserValidate?.BlockReasonCode) : null;

                if (checkUserStatus is not null)
                    outResponse.ResponseMessage = checkUserStatus?.ResponseMessage;
            }

            if (fisUserValidate?.ReturnCode is 300 && fisUserValidate?.BlockReasonCode is null)
            {
                var blockUserMessage = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.BlockUserPassword.GetIntValue());
                outResponse.ResponseMessage = blockUserMessage.CorrectedMessage;
                outResponse.ResponseMessage_Hindi = blockUserMessage.HindiMessage;
            }

            return outResponse;
        }
        #endregion
    }
}
