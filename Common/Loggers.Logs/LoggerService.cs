using Common.Enums;
using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using Loggers.Logs.Model;
using Microsoft.Extensions.Options;
using SQL.Helper;
using System.Threading.Tasks;

namespace Loggers.Logs
{
    public class LoggerService : ILoggerService
    {
        private readonly SqlConnectionStrings _sqlConnectionStrings;
        private readonly LoggingSettings _loggingSettings;
        private readonly IDataDbConfigurationService _dataDbConfigurationService;

        public LoggerService(IOptions<SqlConnectionStrings> sqlConnectionStrings, IDataDbConfigurationService dataDbConfigurationService, IOptions<LoggingSettings> loggingSettings)
        {
            _sqlConnectionStrings = sqlConnectionStrings.Value;
            _dataDbConfigurationService = dataDbConfigurationService;
            _loggingSettings = loggingSettings.Value;
        }

        private async Task<int> WriteLogAsync<TRequest>(LogSettings<TRequest> loggerRequest) where TRequest : new()
        {
            if (loggerRequest.LogEnable)
            {
                var dataDbConfig = new DataDbConfigSettings<TRequest>
                {
                    DbConnection = _sqlConnectionStrings.PBLogsConnection,
                    Request = loggerRequest.Request,
                    TableEnums = loggerRequest.LogTable
                };
                return await _dataDbConfigurationService.AddDataAsync<TRequest>(dataDbConfig);
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> WriteCorelationLogAsync(CorelationLoggerRequest loggerRequest)
        {
            var corelationLogSettings = new LogSettings<CorelationLoggerRequest>()
            {
                LogEnable = _loggingSettings.EnableCorelation,
                LogTable = LogsEnums.CORELATIONLOG,
                Request = loggerRequest
            };
            return await WriteLogAsync<CorelationLoggerRequest>(corelationLogSettings);
        }

        public async Task<int> WriteFillLogAsync(FillLoggerRequest loggerRequest)
        {
            var corelationLogSettings = new LogSettings<FillLoggerRequest>()
            {
                LogEnable = _loggingSettings.EnableCorelation,
                LogTable = LogsEnums.TABLELOG,
                Request = loggerRequest
            };
            return await WriteLogAsync<FillLoggerRequest>(corelationLogSettings);
        }
    }
}
