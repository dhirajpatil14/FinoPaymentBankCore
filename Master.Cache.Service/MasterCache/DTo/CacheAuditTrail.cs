using Newtonsoft.Json;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class CacheAuditTrail
    {
        [JsonProperty("IpAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("CacheKey")]
        public string CacheKey { get; set; }

        [JsonProperty("OldData")]
        public string OldData { get; set; }

        [JsonProperty("NewData")]
        public string NewData { get; set; }
    }
}
