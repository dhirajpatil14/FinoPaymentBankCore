using Newtonsoft.Json;

namespace LoginService.Application.DTOs
{
    public class FisUserValidateRequest
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("ECBBlockEncryption")]
        public bool EcbBlockEncryption { get; set; }
    }
}
