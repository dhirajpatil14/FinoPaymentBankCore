using System;

namespace Data.Db.Service.Model
{
    public class DataDbConfigSettings<TRequest> where TRequest : new()
    {
        public Enum TableEnums { get; set; }
        public TRequest Request { get; set; }

        public string DbConnection { get; set; }


    }
}
