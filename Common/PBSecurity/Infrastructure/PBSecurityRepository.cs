using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Microsoft.Extensions.Options;
using PBSecurity.Application;
using PBSecurity.Model;
using SQL.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBSecurity.Infrastructure
{
    public class PBSecurityRepository : IPBSecurityRepository
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly SqlConnectionStrings _sqlConnectionStrings;
        public PBSecurityRepository(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnection)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnection.Value;
        }
        public virtual async Task<MstSSLCertificate> GetValidCertificate(int AppChannelId, string CertificateId = "")
        {
            var parameter = new
            {
                AppChannelId = AppChannelId,
                CertificateId = CertificateId
            };

            var sqlQuery = "SELECT TOP 1 Id,CertificateName,CertificateId,CertificatePath,CertificatePassword,KeyExpiryDate " +
                           "FROM MstSSLCretificate (nolock) " +
                           "WHERE Convert(date,KeyExpiryDate) >= Convert(date,GETDATE()) " +
                           "AND ('"+ CertificateId + "' = '' " +
                           "OR CertificateId = '"+ CertificateId + "') " +
                           "AND IsActive=1 AND AppChannelId = "+ AppChannelId + " " +
                           "ORDER BY Convert(date,KeyExpiryDate) ";
            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = sqlQuery,
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDataAsync<object, MstSSLCertificate>(configSettings: config);
        }
    }
}
