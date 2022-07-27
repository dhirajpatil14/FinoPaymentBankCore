using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Master.Cache.Service.MasterCache.DTo;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Cache.Service.MasterCache.Repositories
{
    public class MasterCacheRepositories : IMasterCacheRepositories
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly SqlConnectionStrings _sqlConnectionStrings;

        public MasterCacheRepositories(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnectionStrings)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnectionStrings.Value;
        }


        public async Task<IEnumerable<MasterStatus>> GetMasterVersionAsync(string keyCategory = null, int? mBKeyCategory = null)
        {
            var config = new DataDbConfigSettings<MasterStatus>
            {
                TableEnums = PBMaster.MasterStatus,
                Request = new MasterStatus { Status = true, KeyCategory = keyCategory, MbKeyCategory = mBKeyCategory },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<MasterStatus, MasterStatus>(configSettings: config);
        }

        public async Task<dynamic> ExecuteQueryAsync(string query)
        {
            var config = new DataDbConfigSettings<dynamic>
            {
                PlainQuery = query,
                TableEnums = PBMaster.MasterStatus,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<dynamic, dynamic>(configSettings: config);
        }

        public async Task<int> UpdateMasterStatusAsync(MasterStatus masterStatus)
        {
            var query = "update tblmastersStatus set [Version]=@Version ,UpdatedDate = getDate() where mstTableName = @MstTableName";
            var config = new DataDbConfigSettings<MasterStatus>
            {
                PlainQuery = query,
                Request = masterStatus,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };

            return await _dataDbConfigurationService.UpdateDataAsync<MasterStatus>(configSettings: config);
        }
    }
}
