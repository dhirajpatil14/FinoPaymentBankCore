namespace SQL.Helper
{
    public class CommanSqlQueryConfiguration : SqlConfiguration
    {
        public CommanSqlQueryConfiguration()
        {
            ParameterNotation = "@";
            SchemaName = "[dbo]";
            TableColumnStartNotation = "[";
            TableColumnEndNotation = "]";
            InsertQuery = "INSERT INTO %SCHEMA%.%TABLENAME% %COLUMNS% VALUES(%VALUES%)";
            SelectQuery = "SELECT * FROM %SCHEMA%.%TABLENAME% with (NOLOCK) ";
            UpdateQuery = "UPDATE %SCHEMA%.%TABLENAME% %SETVALUES% WHERE %WHERESETVALUE%";
            DeleteQuery = "";

        }
    }
}
