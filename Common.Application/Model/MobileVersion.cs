using Newtonsoft.Json;

namespace Common.Application.Model
{
    public class MobileVersion
    {
        [JsonProperty("ev_mandat")]
        public string EvMandat { get; set; } = "0";

        [JsonProperty("ev_current")]
        public string EvCurrent { get; set; } = "0";

        [JsonProperty("morp_mandat")]
        public string MorpMandat { get; set; } = "0";

        [JsonProperty("morp_current")]
        public string MorpCurrent { get; set; } = "0";

        [JsonProperty("Status")]
        public bool Status { get; set; }
    }
}
