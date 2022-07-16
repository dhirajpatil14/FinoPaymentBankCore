using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using HotRod.Cache;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Shared.Services.ESBCBSMessageService
{
    public class EsbCbsMessageService
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;

        private readonly SqlConnectionStrings _sqlConnectionStrings;

        private readonly Dictionary<string, IEnumerable<EsbCbsMessages>> _cacheEsbCbsMessages;

        private readonly HotRodCache _hotRodCache;

        private readonly string KEY = "ESBCBSMESSAGE_PBCONFIGURATION";

        private readonly string CACHEKEY = "GetEsbCbsMessages";

        protected internal EsbCbsMessageService()
        {
            _cacheEsbCbsMessages = new Dictionary<string, IEnumerable<EsbCbsMessages>>();
        }

        public EsbCbsMessageService(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnection, HotRodCache hotRodCache)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnection.Value;
            _hotRodCache = hotRodCache;

            if (_cacheEsbCbsMessages is null)
            {
                _cacheEsbCbsMessages = new Dictionary<string, IEnumerable<EsbCbsMessages>>();
            }
        }

        protected async Task<IEnumerable<EsbCbsMessages>> GetESBCBSMessageListAsync()
        {
            var dataValue = GetorNullAsync();

            if (!dataValue.Any())
            {
                var config = new DataDbConfigSettings<EsbCbsMessages>
                {
                    DbConnection = _sqlConnectionStrings.PBConfigurationConnection,
                    TableEnums = PBConfiguration.ESBCBSMessages,
                    Request = new EsbCbsMessages()
                };
                var data = await _dataDbConfigurationService.GetDatasAsync<EsbCbsMessages, EsbCbsMessages>(config);
                return data;
            }
            return dataValue;
        }

        public async Task<EsbCbsMessages> GetEsbCbsMessgeAsync(string esbMessageByCache, int messageId, int? cbsId)
        {

            var data = GetorNullAsync();

            if (!data.Any())
            {
                if (esbMessageByCache is "1")
                {
                    var esbcbsMessages = await _hotRodCache.GetCacheAsync(CACHEKEY);
                    data = esbcbsMessages.ToJsonDeSerialize<IEnumerable<EsbCbsMessages>>();
                }
                else
                {
                    data = await GetESBCBSMessageListAsync();
                }

                lock (_cacheEsbCbsMessages)
                {
                    _cacheEsbCbsMessages[KEY] = data;
                }
            }
            var messageData = data.FirstOrDefault(xx => xx.MethodId == messageId && xx.CBSResponseCode == cbsId);
            var messageView = messageData ?? new EsbCbsMessages { StandardMessageDesc = "Error Occured", MessageType = MessageType.Exclam.GetStringValue() };
            return messageView;
        }

        protected virtual IEnumerable<EsbCbsMessages> GetorNullAsync()
        {
            lock (_cacheEsbCbsMessages)
            {
                if (_cacheEsbCbsMessages.TryGetValue(KEY, out var value))
                {
                    return value;
                }
            }
            return Enumerable.Empty<EsbCbsMessages>();
        }

        public virtual void ClearAll()
        {
            lock (_cacheEsbCbsMessages)
            {
                _cacheEsbCbsMessages.Clear();
            }
        }

        public virtual void Clear()
        {
            lock (_cacheEsbCbsMessages)
            {
                _cacheEsbCbsMessages.Remove(KEY);
            }
        }

    }
}
