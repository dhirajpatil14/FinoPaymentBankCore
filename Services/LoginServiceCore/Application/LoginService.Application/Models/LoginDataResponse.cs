using Newtonsoft.Json;

namespace LoginService.Application.Models
{
    public class LoginDataResponse
    {
        [JsonProperty("Login_Data")]
        public string LoginData { get; set; } = null;
    }
}
