using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Threading.Tasks;

namespace Shared.Services.MasterCache
{
    public class MasterCacheService
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly SqlConnectionStrings _sqlConnectionStrings;

        public MasterCacheService(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnection)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnection.Value;
        }

        public virtual async Task<MasterCaches> GetMasterByCacheNameAsync(string cacheName)
        {
            var parameter = new
            {
                MasterCacheKey = cacheName
            };
            var config = new DataDbConfigSettings<object>
            {
                TableEnums = PBMaster.MasterCache,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.GetDataAsync<object, MasterCaches>(configSettings: config);
        }

        public virtual async Task<int> UpdateMasterCacheByMasterKey(string version, string masterCacheKey)
        {
            var parameter = new
            {
                Version = version,
                MasterCacheKey = masterCacheKey
            };
            var sql = $"update MasterCache set Version=@Version where MasterCacheKey=@MasterCacheKey";
            var config = new DataDbConfigSettings<object>
            {

                TableEnums = PBMaster.MasterCache,
                PlainQuery = sql,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.UpdateDataAsync<object>(configSettings: config);
        }


        public virtual async Task<FosAppVersion> GetFOSApplicationVersionAsync(string authenticator)
        {
            var parameter = new
            {
                AuthenticatorCategory = authenticator
            };

            var query = "   SELECT x.MandatoryVersion, y.CurrentVersion  FROM  " +
                "(SELECT VersionCode MandatoryVersion FROM dbo.mstFOSAppVersionNew WITH (NOLOCK) where MandatoryVersion=1 and AuthenticatorCategory=@AuthenticatorCategory) as x, " +
                "(SELECT VersionCode CurrentVersion FROM dbo.mstFOSAppVersionNew WITH (NOLOCK) where CurrentVersion=1 and AuthenticatorCategory=@AuthenticatorCategory) as y ";
            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDataAsync<object, FosAppVersion>(configSettings: config);
        }

        public virtual async Task<MobileVersion> GetMobileVersionAsync()
        {
            var config = new DataDbConfigSettings<MobileVersion>
            {
                TableEnums = PBMaster.MobileVersion,
                Request = new MobileVersion { Status = true },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.GetDataAsync<MobileVersion, MobileVersion>(configSettings: config);
        }

    }
}
