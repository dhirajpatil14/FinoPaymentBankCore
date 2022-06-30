using Newtonsoft.Json;

namespace Common.Application.Model
{
    public class EsbCbsMessages
    {
        [JsonProperty("ResponseID")]
        public int? ResponseId { get; set; } = null;


        [JsonProperty("MethodID")]
        public int? MethodId { get; set; } = null;

        [JsonProperty("MessageType")]
        public string MessageType { get; set; }


        [JsonProperty("ResponseDesc")]
        public string ResponseDescription { get; set; }

        [JsonProperty("StandardMessageDesc")]
        public string StandardMessageDescription { get; set; }

        [JsonProperty("CBSResponseCode")]
        public int? CBSResponseCode { get; set; } = null;

        [JsonProperty("CBSResponseDesc")]
        public string CBSResponseDescription { get; set; }
    }
}
