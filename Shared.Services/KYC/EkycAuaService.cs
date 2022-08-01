using Common.Application.Interface;
using Common.Application.Model;
using Common.Application.Model.EKYC;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Threading.Tasks;

namespace Shared.Services.KYC
{
    public class EkycAuaService : IEkycAuaService
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly SqlConnectionStrings _sqlConnectionStrings;

        public EkycAuaService(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnectionStrings)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnectionStrings.Value;
        }

        public async Task<EkycAuaAadharRd> GetKycAadhar()
        {
            var config = new DataDbConfigSettings<EkycAuaAadharRd>
            {
                TableEnums = PBConfiguration.AuaRequestRd,
                Request = new EkycAuaAadharRd(),
                DbConnection = _sqlConnectionStrings.PBConfigurationConnection
            };

            return await _dataDbConfigurationService.GetDataAsync<EkycAuaAadharRd, EkycAuaAadharRd>(configSettings: config);
        }

        public async Task<MasterAua> GetMasterAuaAsync(MasterAua masterAua)
        {
            var config = new DataDbConfigSettings<MasterAua>
            {
                TableEnums = PBConfiguration.MSTAUA,
                Request = masterAua,
                DbConnection = _sqlConnectionStrings.PBConfigurationConnection
            };
            return await _dataDbConfigurationService.GetDataAsync<MasterAua, MasterAua>(configSettings: config);
        }
    }
}
