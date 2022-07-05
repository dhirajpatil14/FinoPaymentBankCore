using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using LoginService.Application.Contracts.Repositories;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Login.Infrastructure.Repositories
{
    class UserRepositories : IUserRepositories
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;
        private readonly SqlConnectionStrings _sqlConnectionStrings;

        public UserRepositories(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnectionStrings)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnectionStrings.Value;
        }

        public async Task<Reasons> GetReasonsAsync(string reasonsCode)
        {
            var config = new DataDbConfigSettings<Reasons>
            {
                TableEnums = PBMaster.ReasonMaster,
                Request = new Reasons { RevokeReason = reasonsCode },
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDataAsync<Reasons, Reasons>(configSettings: config);
        }

        public async Task<IEnumerable<UserRestriction>> GetUserRestricationAsync(FisUserPasswordValidateRequest fisUserPasswordValidateRequest, int latlong)
        {
            var parameter = new
            {
                Ip = fisUserPasswordValidateRequest?.SystemInfo?.Ip?.ToString(),
                CellId = fisUserPasswordValidateRequest?.SystemInfo?.CellId.ToString(),
                MacDeviceId = fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId.ToString(),
                Mcc = fisUserPasswordValidateRequest?.SystemInfo?.Mcc.ToString(),
                Lattitude = fisUserPasswordValidateRequest?.GeoLocation?.Lattitude.ToString(),
                Longitude = fisUserPasswordValidateRequest?.GeoLocation?.Longitude.ToString()
            };

            var geoCoordinate = new GeoCoordinate.NetStandard2.GeoCoordinate(fisUserPasswordValidateRequest.GeoLocation.Longitude, fisUserPasswordValidateRequest.GeoLocation.Longitude);
            if (geoCoordinate.IsUnknown)
            {

                ////var lat = Convert.ToDouble(fisUserPasswordValidateRequest?.GeoLocation?.Lattitude.ToString().Substring(0, latlong));
                ////var longt = Convert.ToDouble(fisUserPasswordValidateRequest?.GeoLocation?.Longitude.ToString().Substring(0, latlong));
                //fisUserPasswordValidateRequest.GeoLocation.Lattitude = lat;
                //fisUserPasswordValidateRequest.GeoLocation.Longitude = longt;
                fisUserPasswordValidateRequest.GeoLocation.Lattitude = 0;
                fisUserPasswordValidateRequest.GeoLocation.Longitude = 0;
            }


            StringBuilder query = new();
            query.Append("SELECT * FROM tblUserRestriction WITH (NOLOCK) WHERE Status= 1 AND ( ");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" && fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null ? $"IPAddress = @Ip " : "");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" && fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null && !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId) ? $" OR CellID=@CellId" : !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId) ? $" CellID=@CellId" : "");
            query.Append(!string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId) && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId)) ? $" OR DeviceId=@MacDeviceId" : !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId) ? $" DeviceId=@MacDeviceId" : "");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "" && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId) || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId)) ? $" OR MCC=@Mcc" : fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "" ? $" MCC=@Mcc" : "");
            query.Append(fisUserPasswordValidateRequest?.GeoLocation?.Lattitude is not 0 && fisUserPasswordValidateRequest?.GeoLocation?.Longitude is not 0 && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.Ip is not null || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.CellId) || !string.IsNullOrEmpty(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId) || fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "") ? $" OR ( Latitude=@Lattitude AND Longitude=@Longitude )" : fisUserPasswordValidateRequest?.GeoLocation?.Lattitude is not 0 && fisUserPasswordValidateRequest?.GeoLocation?.Longitude is not 0 ? $" Latitude=@Lattitude AND Longitude=@Longitude " : "");
            query.Append(" ) ");
            var config = new DataDbConfigSettings<object>
            {
                PlainQuery = query.ToString(),
                Request = parameter,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            return await _dataDbConfigurationService.GetDatasAsync<object, UserRestriction>(configSettings: config);
        }
    }
}
