using Newtonsoft.Json;

namespace Common.Application.Model
{
    public partial class Aadhaar
    {
        [JsonProperty("RequestData")]
        public RequestData RequestData { get; set; }
        [JsonProperty("RequestXmlData")]
        public string RequestXmlData { get; set; }

        [JsonProperty("UID")]
        public string Uid { get; set; }

        [JsonProperty("AuthType")]
        public string AuthType { get; set; }

        [JsonProperty("UI_Ref_Number")]
        public string UiRefNumber { get; set; }
        [JsonProperty("User_Id")]
        public string UserId { get; set; }
        [JsonProperty("HW_SerNum")]
        public string HWSerNum { get; set; }


        [JsonProperty("SourceType_AppId")]
        public string SourceTypeAppId { get; set; }
        [JsonProperty("Branch_Code")]
        public string BranchCode { get; set; }
        [JsonProperty("Latitude")]
        public string Latitude { get; set; }
        [JsonProperty("Longitude")]
        public string Longitude { get; set; }

        [JsonProperty("Tran_Identifier")]
        public string TranIdentifier { get; set; }


    }

    public partial class RequestData
    {
        [JsonProperty("FPTemplate")]
        public string FPTemplate { get; set; }

        [JsonProperty("PidData")]
        public PidData PidData { get; set; }



    }

    public partial class PidData
    {
        [JsonProperty("Value")]
        public string Value { get; set; }
    }

}
