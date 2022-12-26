using Newtonsoft.Json;

namespace LoginService.Application.DTOs
{
    public class FisUserUnlockRequest
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Version")]

        public long Version { get; set; }

        [JsonProperty("PixType")]
        public string PixType { get; set; }
    }
}
