using Common.Application.Model;
using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Services.ESBMessageService
{
    public class EsbMessageService
    {
        private readonly IDataDbConfigurationService _dataDbConfigurationService;

        private readonly Dictionary<string, IEnumerable<EsbMessages>> _cacheEsbMessages;

        private readonly SqlConnectionStrings _sqlConnectionStrings;

        private readonly string KEY = "ESBMESSAGE_PBMASTER";

        protected internal EsbMessageService()
        {
            _cacheEsbMessages = new Dictionary<string, IEnumerable<EsbMessages>>();
        }

        public EsbMessageService(IDataDbConfigurationService dataDbConfigurationService, IOptions<SqlConnectionStrings> sqlConnection)
        {
            _dataDbConfigurationService = dataDbConfigurationService;
            if (_cacheEsbMessages is null)
            {
                _cacheEsbMessages = new Dictionary<string, IEnumerable<EsbMessages>>();
            }
            _sqlConnectionStrings = sqlConnection.Value;
        }


        protected async Task<IEnumerable<EsbMessages>> AddESBMessageListAsync()
        {
            var dataValue = GetorNullAsync();

            if (!dataValue.Any())
            {
                var config = new DataDbConfigSettings<EsbMessages>
                {
                    DbConnection = _sqlConnectionStrings.PBMasterConnection,
                    TableEnums = PBMaster.ESBMessages,
                    Request = new EsbMessages()

                };

                var data = await _dataDbConfigurationService.GetDatasAsync<EsbMessages, EsbMessages>(config);

                lock (_cacheEsbMessages)
                {
                    _cacheEsbMessages[KEY] = data;
                }
                return data;
            }
            return dataValue;

        }

        protected virtual IEnumerable<EsbMessages> GetorNullAsync()
        {
            lock (_cacheEsbMessages)
            {
                if (_cacheEsbMessages.TryGetValue(KEY, out var value))
                {
                    return value;
                }
            }
            return Enumerable.Empty<EsbMessages>();
        }
        public virtual async Task<int> AddEsbMessageAsync(EsbMessages esbMessage)
        {
            var config = new DataDbConfigSettings<EsbMessages>
            {
                TableEnums = PBMaster.ESBMessages,
                Request = esbMessage,
                DbConnection = _sqlConnectionStrings.PBMasterConnection
            };
            var reply = await _dataDbConfigurationService.AddDataAsync<EsbMessages>(config);

            var dataValue = GetorNullAsync();
            if (dataValue is null)
            {
                await AddESBMessageListAsync();
            }
            else
            {
                var updatedList = dataValue.Append<EsbMessages>(esbMessage).ToList();
                lock (_cacheEsbMessages)
                {
                    _cacheEsbMessages[KEY] = updatedList.AsEnumerable();
                }

            }
            return reply;
        }

        public async virtual Task<EsbMessages> GetEsbMessageByIdAsync(int messageId)
        {
            var data = await AddESBMessageListAsync();

            if (data is not null)
            {
                return data.SingleOrDefault(xx => xx.MessageId == messageId);
            }

            return null;
        }


        public async virtual Task<EsbMessages> GetEsbMessage(string transcationType, string returnCode, string esbMessage)
        {
            var data = await AddESBMessageListAsync();

            if (!string.IsNullOrEmpty(transcationType) && !string.IsNullOrEmpty(returnCode))
            {
                var esbMessages = data.FirstOrDefault(xx => xx.TransactionType == transcationType && xx.ReturnCode == returnCode && xx.EsbMessage.Contains(esbMessage));
                if (!(esbMessages is null) && !(string.IsNullOrEmpty(esbMessages.CorrectedMessage)))
                {
                    return esbMessages;
                }
                else
                {
                    var temp = await GetCorrectMessage(esbMessage);
                    return (!(temp is null) ? temp : new EsbMessages { CorrectedMessage = esbMessage });
                }
            }
            return null;
        }


        private async Task<EsbMessages> GetCorrectMessage(string esbMessage)
        {
            var messageKey = string.Empty;
            if (esbMessage.ToLower().Contains("server not responding"))
                messageKey = "server_not_responding";
            else if (esbMessage.ToLower().Contains("insufficient balance"))
                messageKey = "insufficient_balance";
            else if (esbMessage.ToLower().Contains("sessionkilled"))
                messageKey = "sessionkilled";
            else if (esbMessage.ToLower().Contains("exception occured"))
                messageKey = "exception_occured";
            else if (esbMessage.ToLower().Contains("error occured"))
                messageKey = "error_occured";
            else if (esbMessage.ToLower().Contains("contract error"))
                messageKey = "contract_error";
            else if (esbMessage.ToLower().Contains("object reference not set"))
                messageKey = "object_reference_not_set";


            if (!string.IsNullOrEmpty(messageKey))
            {
                var data = await AddESBMessageListAsync();
                var message = data.FirstOrDefault(xx => xx.EsbMessage.ToLower().Contains(messageKey) && xx.ReturnCode is "D1" && xx.TransactionType is "Default");
                if (!(message is null) && !string.IsNullOrEmpty(message.CorrectedMessage))
                {
                    return message;
                }
            }

            return null;
        }

        public virtual void ClearAll()
        {
            lock (_cacheEsbMessages)
            {
                _cacheEsbMessages.Clear();
            }
        }

        public virtual void Clear()
        {
            lock (_cacheEsbMessages)
            {
                _cacheEsbMessages.Remove(KEY);
            }
        }

    }
}
