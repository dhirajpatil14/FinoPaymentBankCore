using System.Text.Json.Serialization;

namespace Common.Application.Model
{
    public class OutResponse : Common
    {
        [JsonPropertyName("ResponseCode")]
        public int ResponseCode { get; set; }
        [JsonPropertyName("DisplayMessage")]
        public string DisplayMessage { get; set; }
        [JsonPropertyName("ResponseMessage")]
        public string ResponseMessage { get; set; }
        [JsonPropertyName("MessageType")]
        public string MessageType { get; set; }
        [JsonPropertyName("ResponseData")]
        public string ResponseData { get; set; }
        [JsonPropertyName("MessageId")]
        public string MessageId { get; set; }
        [JsonPropertyName("RouteID")]
        public string RouteID { get; set; }
        [JsonPropertyName("ErrorCode")]
        public int ErrorCode { get; set; }
        [JsonPropertyName("XMLData")]
        public string XMLData { get; set; }
        [JsonPropertyName("AuthmanFlag")]
        public bool AuthmanFlag { get; set; }
        [JsonPropertyName("ServiceID")]
        public int ServiceID { get; set; }
        [JsonPropertyName("ResponseMessage_Hindi")]
        public string ResponseMessage_Hindi { get; set; }
    }
}
