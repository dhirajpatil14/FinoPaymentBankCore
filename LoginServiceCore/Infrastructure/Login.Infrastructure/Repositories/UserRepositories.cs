using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using LoginService.Application.Contracts.Repositories;
using LoginService.Application.DTOs;
using LoginService.Application.Models;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System;
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
                fisUserPasswordValidateRequest?.SystemInfo?.Ip,
                fisUserPasswordValidateRequest?.SystemInfo?.CellId,
                fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId,
                fisUserPasswordValidateRequest?.SystemInfo?.Mcc,
                fisUserPasswordValidateRequest?.GeoLocation?.Lattitude,
                fisUserPasswordValidateRequest?.GeoLocation?.Longitude
            };

            var geoCoordinate = new GeoCoordinate.NetStandard2.GeoCoordinate(fisUserPasswordValidateRequest.GeoLocation.Longitude, fisUserPasswordValidateRequest.GeoLocation.Longitude);
            if (!geoCoordinate.IsUnknown)
            {
                var lat = Convert.ToDouble(fisUserPasswordValidateRequest?.GeoLocation?.Lattitude.ToString().Substring(0, latlong));
                var longt = Convert.ToDouble(fisUserPasswordValidateRequest?.GeoLocation?.Longitude.ToString().Substring(0, latlong));
                fisUserPasswordValidateRequest.GeoLocation.Lattitude = lat;
                fisUserPasswordValidateRequest.GeoLocation.Longitude = longt;
            }
            else
            {
                fisUserPasswordValidateRequest.GeoLocation.Lattitude = 0;
                fisUserPasswordValidateRequest.GeoLocation.Longitude = 0;
            }

            StringBuilder query = new();
            query.Append("SELECT * FROM tblUserRestriction WITH (NOLOCK) WHERE Status= 1 AND ( ");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" ? $"IPAddress = @Ip " : "");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" && fisUserPasswordValidateRequest?.SystemInfo?.CellId is not 0 ? $" OR CellID=@CellId" : fisUserPasswordValidateRequest?.SystemInfo?.CellId is not 0 ? $" CellID=@CellId" : "");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId is not 0 && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.CellId is not 0) ? $" OR DeviceId=@MacDeviceId" : fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId is not 0 ? $" DeviceId=@MacDeviceId" : "");
            query.Append(fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "" && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.CellId is not 0 || fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId is not 0) ? $" OR MCC=@Mcc" : fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "" ? $" MCC=@Mcc" : "");
            query.Append(fisUserPasswordValidateRequest?.GeoLocation?.Lattitude is not 0 && fisUserPasswordValidateRequest?.GeoLocation?.Longitude is not 0 && (fisUserPasswordValidateRequest?.SystemInfo?.Ip is not "" || fisUserPasswordValidateRequest?.SystemInfo?.CellId is not 0 || fisUserPasswordValidateRequest?.SystemInfo?.MacDeviceId is not 0 || fisUserPasswordValidateRequest?.SystemInfo?.Mcc is not "") ? $" OR ( Latitude=@Lattitude AND Longitude=@Longitude )" : fisUserPasswordValidateRequest?.GeoLocation?.Lattitude is not 0 && fisUserPasswordValidateRequest?.GeoLocation?.Longitude is not 0 ? $" Latitude=@Lattitude AND Longitude=@Longitude " : "");
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
