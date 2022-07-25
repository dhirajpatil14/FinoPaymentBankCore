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

namespace Shared.Services.MasterMessage
{
    public class MasterMessageService
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;

        private readonly SqlConnectionStrings _sqlConnectionStrings;

        private readonly Dictionary<string, IEnumerable<MasterMessages>> _cacheMasterMessages;

        private readonly HotRodCache _hotRodCache;

        private readonly string KEY = "MASTERMESSAGE_PBCONFIGURATION";

        private readonly string CACHEKEY = "GetMasterMessages";

        protected internal MasterMessageService()
        {
            _cacheMasterMessages = new Dictionary<string, IEnumerable<MasterMessages>>();
        }

        public MasterMessageService(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnection, HotRodCache hotRodCache)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            _sqlConnectionStrings = sqlConnection.Value;
            _hotRodCache = hotRodCache;

            if (_cacheMasterMessages is null)
            {
                _cacheMasterMessages = new Dictionary<string, IEnumerable<MasterMessages>>();
            }
        }

        protected async Task<IEnumerable<MasterMessages>> GetMasterMessageListAsync()
        {
            var dataValue = GetorNullAsync();

            if (!dataValue.Any())
            {
                var config = new DataDbConfigSettings<MasterMessages>
                {
                    DbConnection = _sqlConnectionStrings.PBConfigurationConnection,
                    TableEnums = PBConfiguration.MasterMessages,
                    Request = new MasterMessages()
                };
                var data = await _dataDbConfigurationService.GetDatasAsync<MasterMessages, MasterMessages>(config);
                return data;
            }
            return dataValue;
        }

        public async Task<MasterMessages> GetMasterMessgeAsync(string esbMessageByCache, int messageId)
        {

            var data = GetorNullAsync();

            if (!data.Any())
            {
                if (esbMessageByCache is "1")
                {
                    var esbcbsMessages = await _hotRodCache.GetCacheAsync(CACHEKEY);
                    data = esbcbsMessages.ToJsonDeSerialize<IEnumerable<MasterMessages>>();
                }
                else
                {
                    data = await GetMasterMessageListAsync();
                }

                lock (_cacheMasterMessages)
                {
                    _cacheMasterMessages[KEY] = data;
                }
            }
            var messageData = data.FirstOrDefault(xx => xx.MessageId == messageId);
            var messageView = messageData ?? new MasterMessages { Message = "Error Occured", MessageType = MessageType.Exclam.GetStringValue() };
            return messageView;
        }

        protected virtual IEnumerable<MasterMessages> GetorNullAsync()
        {
            lock (_cacheMasterMessages)
            {
                if (_cacheMasterMessages.TryGetValue(KEY, out var value))
                {
                    return value;
                }
            }
            return Enumerable.Empty<MasterMessages>();
        }

        public virtual void ClearAll()
        {
            lock (_cacheMasterMessages)
            {
                _cacheMasterMessages.Clear();
            }
        }

        public virtual void Clear()
        {
            lock (_cacheMasterMessages)
            {
                _cacheMasterMessages.Remove(KEY);
            }
        }

    }
}
