using System.Text.Json.Serialization;

namespace Common.Application.Model
{
    public class InRequest : Common
    {
        [JsonPropertyName("MethodId")]
        public int MethodId { get; set; }
        [JsonPropertyName("TellerID")]
        public string TellerId { get; set; }
        [JsonPropertyName("TokenId")]
        public string TokenId { get; set; }
        [JsonPropertyName("IsEncrypt")]
        public bool IsEncrypt { get; set; }
        [JsonPropertyName("RequestData")]
        public string RequestData { get; set; }
        [JsonPropertyName("X_Auth_Token")]
        public string XAuthToken { get; set; }
        [JsonPropertyName("ChannelID")]
        public int ChannelID { get; set; }
        [JsonPropertyName("ProductCode")]
        public string ProductCode { get; set; }
        [JsonPropertyName("ServiceID")]
        public int ServiceID { get; set; }

        public string ReturnId()
        {
            if (!string.IsNullOrEmpty(this.RequestId))
            {
                return this.RequestId.Split('_')[0].ToString();
            }
            return string.Empty;
        }
    }
}
