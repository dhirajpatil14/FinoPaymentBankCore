using Newtonsoft.Json;

namespace LoginService.Application.Models
{
    public class CommonChannelIdOne : LoginResponse
    {



        [JsonProperty("MandatoryVersion")]
        public string MandatoryVersion { get; set; }

        [JsonProperty("CurrentVersion")]
        public string CurrentVersion { get; set; }

        [JsonProperty("ev_mandat")]
        public string EvMandat { get; set; }

        [JsonProperty("ev_current")]
        public string EvCurrent { get; set; }

        [JsonProperty("morp_mandat")]
        public string MorpMandat { get; set; }

        [JsonProperty("morp_current")]
        public string MorpCurrent { get; set; }

        [JsonProperty("MastersVersion")]
        public string MastersVersion { get; set; }

    }
}
