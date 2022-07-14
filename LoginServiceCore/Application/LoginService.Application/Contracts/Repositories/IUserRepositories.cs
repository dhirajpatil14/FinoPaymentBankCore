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

        Task<UserType> GetUserTypeAsync(string userType);

        Task<int> CheckEagreementAsync(string merchantName, string merchantId, int expiryday);

        Task<int> CheckCASAaddendumAsync(string merchantId);

        Task<int> CheckFilebaseCasaAsync(string merchantId);

        Task<int> CheckSurveyAsync(string channelId, string userClass, string appId, string tellerId);

        Task<int> CheckCategoryCodeAsync(string merchantId);

        Task<OfferConsent> CheckOfferConsentAsync(string merchantId);

        Task<string> CheckLoyaltyRewardsAsync(string merchantId);

        Task<string> GetLastDownloadAsync();

        Task<string> GetGLZeroizeDateTimeAsync(string userId);

        public Task<IEnumerable<string>> GetLendingVersionAsync();

        public Task<string> GetDbVersionAsync(DbVersion dbVersion);

        public Task<string> GetVersionFromCacheAsync(string cacheName, bool isFetchMaster);

        // Task<string> GetMobileVersion(string cacheName);

        //Task<string> GetProfileType(string cacheName);

        //Task<string> GetProfileTypeCache(string cacheName);

        //Task<string> GetProductTranscation(string cacheName);
        //Task<string> GetProductTranscationCache(string cacheName);

        //Task<string> GetSequenceMap(string cacheName);

        //Task<string> GetSquenceMapCache(string cacheName);

        //Task<string> GetMobileTabControl(string cacheName);

        //Task<string> GetMobileTabControlCache(string cacheName);

        //Task<string> GetIinCacheData(string cacheName);

        //Task<string> GetIinCache(string cacheName);

        //Task<string> GetPrintData(string cacheName);

        //Task<string> GetPrintCache(string cacheName);

        //Task<string> GetCrossSellData(string cacheName);

        //Task<string> GetCrossSellCache(string cacheName);

        Task<string> GetProductTypesAsync(string cacheName);

        Task<FosAppVersion> GetFosVersionAsync(string authenticator, string cacheName);

        Task<string> GetAuaExpiryDataAsync(int status, int id);

        Task<MobileVersion> GetMobileVersionDataAsync(string cacheName);

        Task<string> GetMobileVersionCommanAsync(string cacheName);

    }
}
