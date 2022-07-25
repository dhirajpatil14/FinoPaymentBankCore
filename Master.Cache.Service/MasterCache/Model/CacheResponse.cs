using Newtonsoft.Json;

namespace Master.Cache.Service.MasterCache.Model
{
    public class CacheResponse
    {
        [JsonProperty("CacheMaster")]
        public dynamic CacheMaster { get; set; }

        [JsonProperty("versionID")]
        public int? VersionId { get; set; }

        [JsonProperty("MastersVersion")]
        public string MastersVersion { get; set; }

    }
}
