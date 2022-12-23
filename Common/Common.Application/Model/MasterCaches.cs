using Newtonsoft.Json;
using System;

namespace Common.Application.Model
{
    public class MasterCaches
    {
        [JsonProperty("MasterCacheKey")]
        public string MasterCacheKey { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("UpdateDate")]
        public DateTime? UpdateDate { get; set; } = null;

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("MobileVersion")]
        public int? MobileVersion { get; set; }


        [JsonProperty("MBBPAYVersion")]
        public int? MBBPAYVersion { get; set; }

    }
}
