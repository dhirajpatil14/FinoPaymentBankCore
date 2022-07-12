using Common.Application.Interface;
using Common.Application.Model;
using Common.Application.Model.Settings;
using Common.Enums;
using Data.Db.Service.Interface;
using Loggers.Logs;
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
                esbMessagesdata = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.ServerUnavailable.GetIntValue());
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
                                 result?.Data?.ClientId is not "FINOMER" ? await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.BlockUser.GetIntValue()) : null;

            if (updatedMessage is not null)
            {
                outRespnse.ResponseMessage = updatedMessage.CorrectedMessage;
                outRespnse.ResponseMessage_Hindi = updatedMessage.HindiMessage;
            }
            else
            {
                var checkUserStatus = !checkValidReturnCode &&
                                        result?.Data?.ReturnCode is 300 && result?.Data?.BlockReasonCode is not "11" && result?.Data?.ClientId is not "FINOTLR" ?
                                        await _userRepositories.GetReasonsAsync(result?.Data?.BlockReasonCode) : null;

                if (checkUserStatus is not null)
                    outRespnse.ResponseMessage = checkUserStatus?.ResponseMessage;
            }
            if (result?.Data?.BlockReasonCode is not null)
            {
                var blockUserMessage = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.BlockUserPassword.GetIntValue());
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

        public async Task<OutResponse> ValidateUser(AuthenticationRequest authenticationRequest)
        {
            var loginData = authenticationRequest.RequestData.ToJsonDeSerialize<FisUserPasswordValidateRequest>();
            var isUserRestricted = await RestrictUserAccess(loginData);

            var outRespnse = new OutResponse
            {
                ResponseMessage = isUserRestricted ? "User not authorized to proceed !" : string.Empty,
                // ResponseData = isUserRestricted ? "{\"Login_Data\":null}" : string.Empty
                ResponseData = isUserRestricted ? new LoginDataResponse().ToJsonSerialize() : string.Empty
            };
            outRespnse.ResponseCode = ResponseCode.Failure.GetIntValue();
            outRespnse.MessageType = MessageType.Exclam.GetStringValue();
            outRespnse.SessionId = authenticationRequest.SessionId;
            outRespnse.SessionExpiryTime = authenticationRequest.SessionExpiryTime;


            if (isUserRestricted)
                return outRespnse;

            outRespnse.RequestId = authenticationRequest.RequestId;

            if (loginData.Aadhaar.RequestData is not null)
                loginData.Aadhaar.RequestData = await AadharExtension.GetAadharXmlAsync(loginData.Aadhaar, _ekycAuaService);



            var responseMessage = loginData?.EncType is not null and not "NEW" ? await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.UnableToProcessRequest.GetIntValue()) : null;
            outRespnse.ResponseMessage = responseMessage?.CorrectedMessage ?? string.Empty;
            if (responseMessage is not null)
                return outRespnse;

            loginData.UserId = loginData.EcbBlockEncryption ? loginData?.UserId.ToDecryptEcbBlock(_appSettings.DecryptKey) : loginData.UserId;
            loginData.UserId = !loginData.EcbBlockEncryption ? loginData.UserId.ToDecryptStringAES(_appSettings.DecryptKey, _appSettings.DecryptKeygen) : loginData?.UserId;


            //loginData.Password = loginData?.EncType is null && loginData.EcbBlockEncryption && loginData?.Password is not null ? (loginData?.Password?.Split('|')[1].ToDecryptEcbBlock(_appSettings.DecryptKey)).ToEncriptEcbBlock(loginData?.Password?.Split('|')[0]) : loginData?.Password;
            //loginData.Password = loginData?.EncType is null && !loginData.EcbBlockEncryption && loginData?.Password is not null ? (loginData?.Password?.Split('|')[1].ToDecryptStringAES(_appSettings.DecryptKey, _appSettings.DecryptKeygen)).ToEncryptPassword(loginData?.Password?.Split('|')[0]) : loginData?.Password;

            var urlData = await _esbUrlMemoryService.GetEsbUrlByIdAsync(EsbUrls.EsbNewTokenUrl, ServiceName.LOGINSERVICE);

            var request = new WebApiRequestSettings<FisUserPasswordValidateRequest>
            {
                URL = urlData?.ESBUrl,
                PostParameter = loginData,
                Timeout = _appSettings.Timeout,
                XAuthToken = authenticationRequest.XAuthToken,
                RequesterId = authenticationRequest.ReturnId(),
                RequestId = authenticationRequest.RequestId,
                TokenId = authenticationRequest.TokenId
            };

            var result = await _webApiRequestService.PostAsync<FisUserPasswordValidateResponse, FisUserPasswordValidateRequest>(request);
            var isNotValid = result.StatusCode is not (int)HttpStatusCode.OK;

            if (result.StatusCode is 503)
                responseMessage = await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.ServerUnavailable.GetIntValue());
            else if (result.StatusCode is not 200 && result.StatusCode is not 503)
                responseMessage = await _esbMessageService.GetEsbMessage(string.Empty, ResponseCode.RemoteServerError.GetStringValue(), result.ErrorMessage);


            outRespnse.ResponseCode = isNotValid ? ResponseCode.RemoteServerError.GetIntValue() : ResponseCode.Success.GetIntValue();
            outRespnse.ResponseMessage = isNotValid ? responseMessage.CorrectedMessage : string.Empty;
            outRespnse.MessageType = !isNotValid ? string.Empty : outRespnse.MessageType;
            outRespnse.ResponseData = isNotValid ? responseMessage?.CorrectedMessage : result?.Data?.ToJsonSerialize();

            var checkValidReturnCode = ValidReturnCodeExtension.IsValidCode(result?.Data?.ReturnCode);
            var messageType = checkValidReturnCode ? MessageTypeId.LoginSuccess.GetIntValue() : MessageTypeId.LoginUnSuccess.GetIntValue();

            var isAccessToken = result?.Data?.AccessToken is not null;

            #region IF Return Code Not Zero
            var esbMessageResponse = result?.Data is not null && !checkValidReturnCode ? await _esbCbsMessageService.GetEsbCbsMessgeAsync(_appSettings.ESBCBSMessagesByCache, messageType, result.Data.ReturnCode) : null;
            outRespnse.ResponseMessage = esbMessageResponse is not null ? esbMessageResponse.StandardMessageDesc : outRespnse.ResponseMessage;
            outRespnse.MessageType = esbMessageResponse is not null ? esbMessageResponse.MessageType : outRespnse.MessageType;
            var esbMessageMaster = result?.Data is null || !checkValidReturnCode ? await _esbMessageService.GetEsbMessageByIdAsync(EsbsMessages.UnableToParseLogin.GetIntValue()) : null;
            outRespnse.ResponseMessage = esbMessageMaster is not null ? esbMessageMaster.CorrectedMessage : outRespnse.ResponseMessage;
            outRespnse.MessageType = esbMessageMaster is not null ? MessageType.Exclam.GetStringValue() : outRespnse.MessageType;
            outRespnse.ResponseCode = esbMessageResponse is not null || esbMessageMaster is not null ? ResponseCode.Failure.GetIntValue() : outRespnse.ResponseCode;

            if (esbMessageResponse is not null || esbMessageMaster is not null)
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
            var userType = await _userRepositories.GetUserType(result?.Data?.UserDetails?.UserClass?.Code);
            #endregion

            //Start-RN2041 casa addendum addition
            #region Check EAgreement & Check CASAaddendum
            var checkEAgreement = userType is not null && userType?.UserRole > 0 && userType?.EAgreement == 1 ? await _userRepositories.CheckEagreement(result?.Data?.UserDetails?.Name, result?.Data?.UserDetails?.Identifier?.ToString(), _appSettings.AgreementExpiryday) : 0;
            var checkcasAaddendum = userType is not null && userType?.UserRole > 0 && userType?.EAgreement == 1 ? await _userRepositories.CheckCASAaddendum(result?.Data?.UserDetails?.Identifier?.ToString()) : 0;
            #endregion

            #region Check FilebaseCasa
            var checkFilebaseCasa = await _userRepositories.CheckFilebaseCasa(result?.Data?.UserDetails?.Identifier?.ToString());
            #endregion

            #region Check Survey
            var checkSurvey = userType?.Survey is 1 ? await _userRepositories.CheckSurvey(loginData?.SystemInfo?.Channel, result?.Data?.UserDetails?.UserClass?.Code, loginData?.ClientId, authenticationRequest?.TellerId) : 0;
            #endregion

            #region Check Category Code
            var checkCategoryCode = await _userRepositories.CheckCategoryCode(result?.Data?.UserDetails?.Identifier?.ToString());
            #endregion

            #region Check Offer Consent
            var checkOfferConsent = await _userRepositories.CheckOfferConsent(result?.Data?.UserDetails?.Identifier?.ToString());
            #endregion

            #region Check Rewrd Points
            var checkRewrdPoints = await _userRepositories.CheckLoyaltyRewards(result?.Data?.UserDetails?.Identifier?.ToString());
            #endregion

            #region Get Last Download date

            var lstDownload = await _userRepositories.GetLastDownload();
            var checkZeroeDate = await _userRepositories.GetGLZeroizeDateTime(loginData.UserId);
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
                    var dbVersion = _appSettings.IsCacheFromDB is 1 ? await _userRepositories.GetDbVersion(new DbVersion { MasterVersion = "MastersVersion" }) : null;
                    dataVersion = $"{dataVersion}{dbVersion}";
                    dataVersion = dataVersion.Remove(dbVersion.Length - 1);


                    //Get Master Version
                    dataVersion = _appSettings.IsCacheFromDB is not 1 ? await _userRepositories.GetVersionFromCache("MastersVersion", true) : dataVersion;
                    dataVersion = $"{dataVersion} |";


                    //Get Mobile Version

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionComman($"ProfileTypeDataMenu{userType.UserTypeId}{loginData.SystemInfo.Channel}")}";
                    //var mobileVersion = await _userRepositories.GetVersionFromCache($"ProfileTypeDataMenu{userType.UserTypeId}{loginData.SystemInfo.Channel}", false);
                    //var verId = mobileVersion is not null ? await _userRepositories.GetMobileVersion($"ProfileTypeDataMenu{userType.UserTypeId}{loginData.SystemInfo.Channel}") : null;
                    //dataVersion = mobileVersion is not null ? $"{dataVersion}ProfileTypeDataMenu{userType.UserTypeId}{loginData.SystemInfo.Channel}#{verId}~" : dataVersion;
                    //dataVersion = mobileVersion is null ? $"{dataVersion}ProfileTypeDataMenu{userType.UserTypeId}{loginData.SystemInfo.Channel}#0000~" : dataVersion;

                    //Get Profile Type

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionComman($"ProfileTypeMasterData{userType.UserTypeId}{loginData.SystemInfo.Channel}")}";
                    //var profileType = await _userRepositories.GetProfileType($"ProfileTypeMasterData{userType.UserTypeId}{loginData.SystemInfo.Channel}");
                    //var profileTypeId = profileType is not null ? await _userRepositories.GetProfileTypeCache($"ProfileTypeMasterData") : null;
                    //dataVersion = profileTypeId is not null ? $"{dataVersion}ProfileTypeMasterData{userType.UserTypeId}{loginData.SystemInfo.Channel}#{profileTypeId}~" : dataVersion;
                    //dataVersion = profileTypeId is null ? $"{dataVersion}ProfileTypeMasterData{userType.UserTypeId}{loginData.SystemInfo.Channel}#0000~" : dataVersion;

                    //1207
                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionComman($"ProductTransMap{userType.UserTypeId}{loginData.SystemInfo.Channel}")}";

                    //var productTranscation = await _userRepositories.GetProductTranscation($"ProductTransMap{userType.UserTypeId}{loginData.SystemInfo.Channel}");
                    //var productType = productTranscation is not null ? _userRepositories.GetProductTranscationCache($"ProductTransMap{userType.UserTypeId}{loginData.SystemInfo.Channel}") : null;
                    //dataVersion = productType is not null ? $"{dataVersion}ProductTransMap{userType.UserTypeId}{loginData.SystemInfo.Channel}#{productType}~" : dataVersion;
                    //dataVersion = productType is null ? $"{dataVersion}ProductTransMap{userType.UserTypeId}{loginData.SystemInfo.Channel}#0000~" : dataVersion;

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionComman($"MobSequenceMasterList")}";


                    //var sequence = await _userRepositories.GetSequenceMap($"MobSequenceMasterList");
                    //var sequenceMap = sequence is not null ? _userRepositories.GetSquenceMapCache($"MobSequenceMasterList") : null;
                    //dataVersion = sequenceMap is not null ? $"{dataVersion}MobSequenceMasterList#{sequenceMap}~" : dataVersion;
                    //dataVersion = sequenceMap is null ? $"{dataVersion}MobSequenceMasterList#0000~" : dataVersion;

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionComman($"MobileTabCntrl")}";


                    //var mobileTabControl = await _userRepositories.GetMobileTabControl($"MobileTabCntrl");
                    //var mobileTab = mobileTabControl is not null ? _userRepositories.GetMobileTabControlCache($"MobileTabCntrl") : null;
                    //dataVersion = mobileTab is not null ? $"{dataVersion}MobileTabCntrl#{mobileTab}~" : dataVersion;
                    //dataVersion = mobileTab is null ? $"{dataVersion}MobileTabCntrl#0000~" : dataVersion;

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionComman($"IINMasterMob")}";

                    //var iinCacheData = await _userRepositories.GetIinCacheData($"IINMasterMob");
                    //var iinCache = iinCacheData is not null ? _userRepositories.GetIinCache($"IINMasterMob") : null;
                    //dataVersion = iinCache is not null ? $"{dataVersion}IINMasterMob#{iinCache}~" : dataVersion;
                    //dataVersion = iinCache is null ? $"{dataVersion}IINMasterMob#0000~" : dataVersion;

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionComman($"MstPrintFormat1")}";

                    //var printFormatData = await _userRepositories.GetPrintData($"MstPrintFormat1");
                    //var printCache = printFormatData is not null ? _userRepositories.GetPrintCache("MstPrintFormat1") : null;
                    //dataVersion = printCache is not null ? $"{dataVersion}MstPrintFormat1#{printCache}~" : dataVersion;
                    //dataVersion = printCache is null ? $"{dataVersion}MstPrintFormat1#0000~" : dataVersion;

                    dataVersion = $"{ dataVersion}{await _userRepositories.GetMobileVersionComman($"mstCrossSelling{userType.UserTypeId}{loginData.SystemInfo.Channel}")}";

                    //var crossSellingData = await _userRepositories.GetCrossSellData($"mstCrossSelling{userType.UserTypeId}{loginData.SystemInfo.Channel}");
                    //var crossCache = crossSellingData is not null ? _userRepositories.GetCrossSellCache($"mstCrossSelling{userType.UserTypeId}{loginData.SystemInfo.Channel}") : null;
                    //dataVersion = crossCache is not null ? $"{dataVersion}mstCrossSelling{userType.UserTypeId}{loginData.SystemInfo.Channel}#{crossCache}~" : dataVersion;
                    //dataVersion = crossCache is null ? $"{dataVersion}mstCrossSelling{userType.UserTypeId}{loginData.SystemInfo.Channel}#0000~" : dataVersion;


                    dataVersion = $"{dataVersion}{await _userRepositories.GetProductTypesAsync("MobileTabCntrl")}";

                    dataVersion = dataVersion.Remove(dataVersion.Length - 1);

                    #region FOS DATA
                    var fosData = new FosAppVersion();

                    var authenticaterType = loginData?.ClientId.ToString() == AuthenticatorType.FINOTLR.GetStringValue() || loginData?.ClientId.ToString() == AuthenticatorType.FINOMB.GetStringValue() ? AuthenticatorType.FINOTLR : loginData?.ClientId.ToString() == AuthenticatorType.FINOMER.GetStringValue() || loginData?.ClientId.ToString() == AuthenticatorType.FINOMERNP.GetStringValue() ? AuthenticatorType.FINOMER : AuthenticatorType.FINOMER;

                    if (loginData?.ClientId.ToString() == AuthenticatorType.FINOTLR.GetStringValue() || loginData?.ClientId.ToString() == AuthenticatorType.FINOMB.GetStringValue())
                    {
                        loginData.ClientId = AuthenticatorType.FINOTLR.GetStringValue();
                        fosData = await _userRepositories.GetFosVersion(AuthenticatorType.FINOTLR.GetStringValue(), $"FOSAppVersionNew{AuthenticatorType.FINOTLR.GetStringValue()}{loginData.SystemInfo.Channel}");
                    }
                    else if (loginData?.ClientId.ToString() == AuthenticatorType.FINOMER.GetStringValue() || loginData?.ClientId.ToString() == AuthenticatorType.FINOMERNP.GetStringValue())
                    {
                        loginData.ClientId = AuthenticatorType.FINOMER.GetStringValue();
                        fosData = await _userRepositories.GetFosVersion(AuthenticatorType.FINOMER.GetStringValue(), $"MERAppVersionNew{AuthenticatorType.FINOMER.GetStringValue()}{loginData.SystemInfo.Channel}");
                    }
                    else
                    {
                        loginData.ClientId = AuthenticatorType.FINOIPS.GetStringValue();
                        fosData = await _userRepositories.GetFosVersion(AuthenticatorType.FINOIPS.GetStringValue(), $"MERAppVersionNew{AuthenticatorType.FINOIPS.GetStringValue()}{loginData.SystemInfo.Channel}");
                    }
                    #endregion

                    #region Get Certificate Expiry Date
                    var expiryDate = await _userRepositories.GetAuaExpiryData(1, 11);
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

                        fosData = await _userRepositories.GetFosVersion(AuthenticatorType.FINOPDS.GetStringValue(), $"PDSAppVersion{AuthenticatorType.FINOPDS.GetStringValue()}{loginData.SystemInfo.Channel}");

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
                        fosData = await _userRepositories.GetFosVersion(AuthenticatorType.FINOINGE.GetStringValue(), $"INGEAppVersion{AuthenticatorType.FINOINGE.GetStringValue()}{loginData.SystemInfo.Channel}");
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
                    fosData = await _userRepositories.GetFosVersion(AuthenticatorType.FINOMER.GetStringValue(), $"FINOMERAppVersion{AuthenticatorType.FINOMER.GetStringValue()}{loginData.SystemInfo.Channel}");
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




    }
}
