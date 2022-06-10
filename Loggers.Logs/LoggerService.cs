using SQL.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Loggers.Logs
{
    public class LoggerService : ILoggerService
    {
        private readonly DBService dBService = new DBService();

        public async Task<int> WriteLogAsync<TLogSettings>(LogSettings<TLogSettings> loggerRequest)
        {
            var _sqlConfiguration = new LoggerQueryConfiguration(loggerRequest.LayerId);

            var columns = loggerRequest.GetColumns(_sqlConfiguration, fetchJsonProperties: true);
            var colvalue = loggerRequest.GetColumns(_sqlConfiguration, fetchJsonProperties: false);

            var valuesArray = new List<string>(columns.Count());
            valuesArray = valuesArray.InsertQueryValuesFragment(_sqlConfiguration.ParameterNotation, colvalue);

            var query = _sqlConfiguration.InsertQuery
                                         .ReplaceInsertQueryParameters(_sqlConfiguration.SchemaName,
                                                                       _sqlConfiguration.TableName,
                                                                       columns.GetCommaSeparatedColumns(),
                                                                       string.Join(", ", valuesArray));
            return await dBService.ExecuteAsync(ConnectionString: loggerRequest.LogDbConnection, sql: query, parameter: loggerRequest.Request);
        }
    }
}
