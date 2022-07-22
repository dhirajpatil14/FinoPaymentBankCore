using Newtonsoft.Json;

namespace LoginService.Application.DTOs
{
    public class FisValidateSecretQuestionRequest
    {
        [JsonProperty("UserTypeID")]

        public long UserTypeId { get; set; }

        [JsonProperty("ChannelID")]
        public long ChannelId { get; set; }

        [JsonProperty("productTypeID")]
        public string ProductTypeId { get; set; }

        [JsonProperty("IsFinancial")]
        public string IsFinancial { get; set; }

        [JsonProperty("LendingBankName")]
        public string LendingBankName { get; set; }
    }
}
