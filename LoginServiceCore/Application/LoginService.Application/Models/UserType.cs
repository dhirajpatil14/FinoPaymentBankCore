using Newtonsoft.Json;

namespace LoginService.Application.Models
{
    public class UserType
    {
        [JsonProperty("UserTypeId")]
        public int? UserTypeId { get; set; }

        [JsonProperty("UserRole")]
        public int? UserRole { get; set; }

        [JsonProperty("EAgreement")]
        public int? EAgreement { get; set; }

        [JsonProperty("Survey")]
        public int? Survey { get; set; }

        [JsonProperty("CASAEagreement")]
        public int? CASAEagreement { get; set; }

        [JsonProperty("UserTypeName")]
        public string UserTypeName { get; set; }

    }
}
