using Newtonsoft.Json;
using System;

namespace Common.Application.Model
{
    public class CacheAuditTrail
    {
        [JsonProperty("Id")]
        public int? Id { get; set; } = null;

        [JsonProperty("IpAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("CacheKey")]
        public string CacheKey { get; set; }

        [JsonProperty("OldData")]
        public string OldData { get; set; }

        [JsonProperty("NewData")]
        public string NewData { get; set; }

        [JsonProperty("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; } = null;
    }
}
