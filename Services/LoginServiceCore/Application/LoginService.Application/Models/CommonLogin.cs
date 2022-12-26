using Newtonsoft.Json;

namespace LoginService.Application.Models
{
    public class CommonChannelIdTwo : LoginResponse
    {
        [JsonProperty("SessionId")]
        public string SessionId { get; set; }

        [JsonProperty("NoOfFinger")]
        public string NoOfFinger { get; set; }

        [JsonProperty("Threshold")]
        public string Threshold { get; set; }

        [JsonProperty("Ekyc")]
        internal string Ekyc { get; set; } = "1";

        [JsonProperty("Roles")]
        internal string Roles { get; set; } = "Customer";

        [JsonProperty("MaxMinLimit")]
        internal string MaxMinLimit { get; set; } = "100000,1000";

    }
}
