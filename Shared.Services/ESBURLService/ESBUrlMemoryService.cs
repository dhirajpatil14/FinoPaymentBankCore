using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Shared.Services.ESBURLService
{
    public class EsbUrlMemoryService
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;

        private readonly Dictionary<string, IEnumerable<EsbUrl>> _cacheESBUrls;

        private readonly SqlConnectionStrings _sqlConnectionStrings;

        protected internal EsbUrlMemoryService()
        {
            _cacheESBUrls = new Dictionary<string, IEnumerable<EsbUrl>>();
        }

        public EsbUrlMemoryService(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnection)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            if (_cacheESBUrls == null)
            {
                _cacheESBUrls = new Dictionary<string, IEnumerable<EsbUrl>>();
            }
            _sqlConnectionStrings = sqlConnection.Value;
        }

        protected async Task<IEnumerable<EsbUrl>> AddESBListAsync(string key, int serviceId, int serviceName)
        {
            var dataValue = GetorNullAsync(key);

            if (!dataValue.Any())
            {
                var config = new DataDbConfigSettings<EsbUrl>
                {
                    DbConnection = _sqlConnectionStrings.PBConfigurationConnection,
                    TableEnums = PBConfiguration.ESBURL,
                    Request = new EsbUrl
                    {
                        ServiceUrlId = serviceName.ToString()
                    }
                };
                var data = await _dataDbConfigurationService.GetDataAsync<EsbUrl, EsbUrl>(config);

                lock (_cacheESBUrls)
                {
                    _cacheESBUrls[key] = data;
                }
                return data;
            }
            return dataValue;

        }


        protected virtual IEnumerable<EsbUrl> GetorNullAsync(string key)
        {
            lock (_cacheESBUrls)
            {
                if (_cacheESBUrls.TryGetValue(key, out var value))
                {
                    return value;
                }
            }
            return Enumerable.Empty<EsbUrl>();
        }

        public virtual async Task<int> AddEsbUrlAsync(EsbUrl eSBURL, EsbUrls esbUrlId, ServiceName serviceName)
        {
            var config = new DataDbConfigSettings<EsbUrl>
            {
                TableEnums = PBConfiguration.ESBURL,
                Request = eSBURL,
                DbConnection = _sqlConnectionStrings.PBConfigurationConnection
            };
            var reply = await _dataDbConfigurationService.AddDataAsync<EsbUrl>(config);

            var dataValue = GetorNullAsync(serviceName.ToString());
            if (dataValue == null)
            {
                await AddESBListAsync(serviceName.ToString(), esbUrlId.GetIntValue(), serviceName.GetIntValue());
            }
            else
            {
                var updatedList = dataValue.Append<EsbUrl>(eSBURL).ToList();
                lock (_cacheESBUrls)
                {
                    _cacheESBUrls[serviceName.ToString()] = updatedList.AsEnumerable();
                }

            }
            return reply;
        }

        public async virtual Task<EsbUrl> GetEsbUrlByIdAsync(EsbUrls esbUrlId, ServiceName serviceName)
        {
            var data = await AddESBListAsync(serviceName.ToString(), esbUrlId.GetIntValue(), serviceName.GetIntValue());

            if (data != null)
            {
                return data.SingleOrDefault(xx => xx.ESBUrlId == esbUrlId.GetIntValue());
            }

            return null;
        }
        public virtual void Clear()
        {
            lock (_cacheESBUrls)
            {
                _cacheESBUrls.Clear();
            }
        }

        public virtual void Clear(string key)
        {
            lock (_cacheESBUrls)
            {
                _cacheESBUrls.Remove(key);
            }
        }

    }
}
