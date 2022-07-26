using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using HotRod.Cache.Connector.Application;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Threading.Tasks;

namespace HotRod.Cache.Connector.Infrastructure
{
    public class CacheRepositories : ICacheRepositories
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly SqlConnectionStrings _sqlConnectionStrings;

        public CacheRepositories(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnection)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnection.Value;
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

        public virtual async Task<MasterCaches> GetMasterByCacheNameAsync(string cacheName)
        {
            var config = new DataDbConfigSettings<MasterCaches>
            {
                TableEnums = PBMaster.MasterCache,
                Request = new MasterCaches { MasterCacheKey = cacheName },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDataAsync<MasterCaches, MasterCaches>(configSettings: config);
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

        public virtual async Task<int> UpdateMasterCacheAsync(string cacheName, string cacheValue, string version)
        {
            var parameter = new
            {
                CacheName = cacheName,
                CacheValue = cacheValue,
                Version = version
            };

            string query = $"IF EXISTS(SELECT* FROM MasterCache WITH (NOLOCK) WHERE MasterCacheKey=@CacheName) UPDATE MasterCache SET Value =@CacheValue ,[Version] = @Version, UpdateDate = getDate()  WHERE MasterCacheKey =@CacheName  ELSE INSERT INTO MasterCache(MasterCacheKey, Value, UpdateDate, [Version]) VALUES(@CacheName, @cacheValue, getDate(), @version)";

            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.UpdateDataAsync<object>(config);
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

        public virtual async Task<int> InsertCacheAuditTrailLog(CacheAuditTrail cacheAuditTrail)
        {
            var config = new DataDbConfigSettings<CacheAuditTrail>
            {
                TableEnums = PBMaster.CacheAuditTrail,
                Request = cacheAuditTrail,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.AddDataAsync<CacheAuditTrail>(config);
        }

        public async Task<int> UpdateCacheAuditTrailLog(CacheAuditTrail cacheAuditTrail)
        {
            var config = new DataDbConfigSettings<CacheAuditTrail>
            {
                PlainQuery = "update tblCacheAuditTrail set NewData = @NewData where Cachekey = @CacheKey and Id= @Id",
                Request = cacheAuditTrail,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.UpdateDataAsync<CacheAuditTrail>(config);
        }
    }
}
