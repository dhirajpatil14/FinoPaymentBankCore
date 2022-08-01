using Newtonsoft.Json;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class MasterProductFeature
    {
        [JsonProperty("ProductCode")]
        public int? ProductCode { get; set; }


        [JsonProperty("ekyc")]
        public bool? Ekyc { get; set; }

        [JsonProperty("MinFPCaptureCount")]
        public int MinFPCaptureCount { get; set; }

        [JsonProperty("FPUploadCount")]
        public int FPUploadCount { get; set; }


        [JsonProperty("FPType")]
        public string FPType { get; set; }

        [JsonProperty("ThresholdValue")]
        public int ThreSholdValue { get; set; }


        [JsonProperty("FPCompressionType")]
        public string FPCompressionType { get; set; }

        [JsonProperty("FaceDetection")]
        public bool FaceDetection { get; set; }

        [JsonProperty("MinorCustomerAllowed")]
        public bool MinorCustomerAllowed { get; set; }


        [JsonProperty("MinorNomineeAllowed")]
        public bool MinorNomineeAllowed { get; set; }

        [JsonProperty("ImageResolution")]
        public string ImageResolution { get; set; }

        [JsonProperty("InitialFunding")]
        public string InitialFunding { get; set; }

        [JsonProperty("ChannelID")]
        public string ChannelID { get; set; }


        [JsonProperty("Version")]
        public string Version { get; set; }


        [JsonProperty("MaxBalance")]
        public string MaxBalance { get; set; }


        [JsonProperty("TotalDebitAmountPerMonth")]
        public decimal TotalDebitAmountPerMonth { get; set; }


        [JsonProperty("TotalCreditAmountPerMonth")]
        public decimal TotalCreditAmountPerMonth { get; set; }

        [JsonProperty("MaxWithdrawal")]
        public decimal MaxWithdrawal { get; set; }

        [JsonProperty("IsDebitCard")]
        public bool IsDebitCard { get; set; }

        [JsonProperty("DebitCardID")]
        public int DebitCardID { get; set; }

        [JsonProperty("LendingParam")]
        public string LendingParam { get; set; }


        [JsonProperty("NEFTAmount")]
        public string NEFTAmount { get; set; }

        [JsonProperty("ProductBenefit")]
        public string ProductBenefit { get; set; }


        [JsonProperty("AccountNo")]
        public string AccountNo { get; set; }

        [JsonProperty("AuthTypeID")]
        public int AuthTypeID { get; set; }

        [JsonProperty("AuthTypeName")]
        public string AuthTypeName { get; set; }

        [JsonProperty("ServiceCharge")]
        public string ServiceCharge { get; set; }


        [JsonProperty("Mode")]
        public string Mode { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("appChannelid")]
        public int? AppChannelid { get; set; } = null;

        [JsonProperty("ProfileControlDetails")]
        public string ProfileControlDetails { get; set; }


    }
}
