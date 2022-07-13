using Common.Application.Model;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginService.Application.Contracts.Repositories
{
    public interface IUserRepositories
    {
        Task<IEnumerable<UserRestriction>> GetUserRestricationAsync(FisUserPasswordValidateRequest fisUserPasswordValidateRequest, int latlong);

        Task<Reasons> GetReasonsAsync(string reasonsCode);

        Task<int> AddUserGeoAsync(GeoUserLocation geoUserLocation);

        Task<UserType> GetUserType(string userType);




        Task<int> CheckEagreement(string merchantName, string merchantId, int expiryday);

        Task<int> CheckCASAaddendum(string merchantId);

        Task<int> CheckFilebaseCasa(string merchantId);

        Task<int> CheckSurvey(string channelId, string userClass, string appId, string tellerId);

        Task<int> CheckCategoryCode(string merchantId);

        Task<OfferConsent> CheckOfferConsent(string merchantId);

        Task<string> CheckLoyaltyRewards(string merchantId);

        Task<string> GetLastDownload();

        Task<string> GetGLZeroizeDateTime(string userId);

        public Task<IEnumerable<string>> GetLendingVersion();

        public Task<string> GetDbVersion(DbVersion dbVersion);

        public Task<string> GetVersionFromCache(string cacheName, bool isFetchMaster);

        Task<string> GetMobileVersion(string cacheName);

        Task<string> GetProfileType(string cacheName);

        Task<string> GetProfileTypeCache(string cacheName);

        Task<string> GetProductTranscation(string cacheName);
        Task<string> GetProductTranscationCache(string cacheName);

        Task<string> GetSequenceMap(string cacheName);

        Task<string> GetSquenceMapCache(string cacheName);

        Task<string> GetMobileTabControl(string cacheName);

        Task<string> GetMobileTabControlCache(string cacheName);

        Task<string> GetIinCacheData(string cacheName);

        Task<string> GetIinCache(string cacheName);

        Task<string> GetPrintData(string cacheName);

        Task<string> GetPrintCache(string cacheName);

        Task<string> GetCrossSellData(string cacheName);

        Task<string> GetCrossSellCache(string cacheName);

        Task<string> GetProductTypesAsync(string cacheName);

        Task<FosAppVersion> GetFosVersion(string authenticator, string cacheName);

        Task<string> GetAuaExpiryData(int status, int id);

        Task<MobileVersion> GetMobileVersionDataAsync(string cacheName);

        Task<string> GetMobileVersionComman(string cacheName);

    }
}
