using Newtonsoft.Json;

namespace Common.Application.Model
{
    public class EsbMessages
    {
        [JsonProperty("messageId")]
        public int? MessageId { get; set; } = null;

        [JsonProperty("transactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("returnCode")]
        public string ReturnCode { get; set; }

        [JsonProperty("esbMessage")]
        public string EsbMessage { get; set; }

        [JsonProperty("correctedMessage")]
        public string CorrectedMessage { get; set; }

        [JsonProperty("hindiMessage")]
        public string HindiMessage { get; set; }

    }
}
