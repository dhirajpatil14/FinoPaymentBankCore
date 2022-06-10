using SQL.Helper;

namespace Loggers.Logs
{
    public class LoggerQueryConfiguration : CommanSqlQueryConfiguration
    {
        public LoggerQueryConfiguration(int LayerId)
        {
            TableName = LayerId == 1 || LayerId == 2 || LayerId == 3 ? "Tbl_Corelation_Log" : LayerId == 4 ? "tblLog" : "";
        }
    }
}
