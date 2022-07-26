using Newtonsoft.Json;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class MasterStatus
    {
        [JsonProperty("mstTableName")]
        public string MstTableName { get; set; }

        [JsonProperty("CacheName")]
        public string CacheName { get; set; }

        [JsonProperty("SqlQuery")]
        public string SqlQuery { get; set; }

        [JsonProperty("KeyCategory")]
        public string KeyCategory { get; set; }

        [JsonProperty("status")]
        public bool? Status { get; set; } = null;
    }
}
