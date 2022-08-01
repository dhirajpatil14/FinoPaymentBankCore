using Newtonsoft.Json;
using System;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class MasterStatus
    {
        [JsonProperty("mstTableId")]
        public int? MstTableId { get; set; } = null;

        [JsonProperty("mstTableName")]
        public string MstTableName { get; set; }

        [JsonProperty("CacheName")]
        public string CacheName { get; set; }

        [JsonProperty("SqlQuery")]
        public string SqlQuery { get; set; }

        [JsonProperty("KeyCategory")]
        public string KeyCategory { get; set; }


        [JsonProperty("Version")]
        public int? Version { get; set; } = null;

        [JsonProperty("MBKeyCategory")]
        public int? MbKeyCategory { get; set; } = null;

        [JsonProperty("mstUpdateFlag")]
        public int? MstUpdateFlag { get; set; } = null;

        [JsonProperty("CreatedDate")]
        public DateTime? CreatedDate { get; set; } = null;


        [JsonProperty("CreatedBy")]
        public int? CreatedBy { get; set; } = null;

        [JsonProperty("status")]
        public bool? Status { get; set; } = true;
    }
}
