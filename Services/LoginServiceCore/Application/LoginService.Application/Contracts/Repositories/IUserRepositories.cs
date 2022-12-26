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

        Task<string> GetProductTypesAsync(string cacheName);

        Task<FosAppVersion> GetFosVersionAsync(string authenticator, string cacheName);


        Task<MobileVersion> GetMobileVersionDataAsync(string cacheName);

        Task<string> GetMobileVersionCommanAsync(string cacheName);

    }
}
