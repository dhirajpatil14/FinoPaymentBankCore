using Newtonsoft.Json;

namespace LoginService.Application.DTOs
{
    public class FIsUserAuthmanPolicyRequest
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("old_user_id")]
        public string OldUserId { get; set; }

        [JsonProperty("ECBBlockEncryption")]
        public bool EcbBlockEncryption { get; set; }
    }
}
