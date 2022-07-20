using System.Text.Json.Serialization;

namespace Common.Application.Model
{
    public class Common
    {
        [JsonPropertyName("RequestId")]
        public string RequestId { get; set; }
        [JsonPropertyName("SessionId")]
        public string SessionId { get; set; }
        [JsonPropertyName("SessionExpiryTime")]
        public string SessionExpiryTime { get; set; }
    }
}
