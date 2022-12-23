using Newtonsoft.Json;

namespace Common.Application.Model
{
    public class Reasons
    {
        [JsonProperty("id")]
        public int? Id { get; set; } = null;

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("RevokeReason")]
        public string RevokeReason { get; set; }

        [JsonProperty("ResponseMessage")]
        public string ResponseMessage { get; set; }
    }
}
