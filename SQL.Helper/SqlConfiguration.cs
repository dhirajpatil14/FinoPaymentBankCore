namespace SQL.Helper
{
    public abstract class SqlConfiguration
    {
        protected SqlConfiguration() { }

        public string SchemaName { get; set; }
        public string ParameterNotation { get; set; }
        public string TableColumnStartNotation { get; set; }
        public string TableColumnEndNotation { get; set; }

        public string TableName { get; set; }
        public string Query { get; set; }
        public string SelectQuery { get; set; }
        public string InsertQuery { get; set; }
        public string UpdateQuery { get; set; }
        public string DeleteQuery { get; set; }
    }
}
