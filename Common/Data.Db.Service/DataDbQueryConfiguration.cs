using SQL.Helper;
using System;
using Utility.Extensions;

namespace Data.Db.Service
{
    public class DataDbQueryConfiguration : CommanSqlQueryConfiguration
    {
        public DataDbQueryConfiguration(Enum TableEnums)
        {
            TableName = TableEnums.GetStringValue();
        }
    }
}
