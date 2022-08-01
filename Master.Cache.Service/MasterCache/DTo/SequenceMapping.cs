using System.Text.Json.Serialization;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class SequenceMapping
    {
        [JsonPropertyName("NewProductCode")]
        public int NewProductType { get; set; }

        [JsonPropertyName("eKYC")]
        public string EkycFlag { get; set; }

        [JsonPropertyName("ExistingProduct")]
        public string ExistingProductType { get; set; }

        [JsonPropertyName("SequenceData")]
        public string SequenceList { get; set; }

        [JsonPropertyName("Mode")]
        public int Mode { get; set; }

        [JsonPropertyName("RFU")]
        public string RFU { get; set; }

        [JsonPropertyName("RFU1")]
        public string RFU1 { get; set; }

        [JsonPropertyName("RFU2")]
        public string RFU2 { get; set; }

        [JsonPropertyName("AuthTypeId")]
        public string AuthTypeId { get; set; }

        [JsonPropertyName("LendingParam")]
        public string LendingParam { get; set; }

    }
}
