using Newtonsoft.Json;

namespace LoginService.Application.Models
{
    public class CommonChannelIdThree : LoginResponse
    {
        [JsonProperty("MandatoryVersion")]
        public string MandatoryVersion { get; set; }

        [JsonProperty("CurrentVersion")]
        public string CurrentVersion { get; set; }
        [JsonProperty("MastersVersion")]
        public string MastersVersion { get; set; }
    }
}
