using Newtonsoft.Json;

namespace Common.Application.Model
{
    public class MasterMessages
    {
        [JsonProperty("MessageID")]
        public int? MessageId { get; set; } = null;

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("MessageType")]
        public string MessageType { get; set; }
    }
}
