using Newtonsoft.Json;

namespace Common.Application.Model.EKYC
{
    public class EkycAuaAadharRd
    {
        [JsonProperty("Uses_pa")]
        public string UsesPa { get; set; }

        [JsonProperty("Uses_pfa")]
        public string UsesPfa { get; set; }

        [JsonProperty("Uses_bio")]
        public string UsesBio { get; set; }

        [JsonProperty("Uses_bt")]
        public string UsesBt { get; set; }

        [JsonProperty("Uses_pin")]
        public string UsesPin { get; set; }

        [JsonProperty("Uses_otp")]
        public string UsesOtp { get; set; }

        [JsonProperty("Uses_pi")]
        public string UsesPi { get; set; }

        [JsonProperty("EKYC_ra")]
        public string EkycRa { get; set; }

        [JsonProperty("EKYC_rc")]
        public string EkycRc { get; set; }


        [JsonProperty("EKYC_lr")]
        public string EkycLr { get; set; }

        [JsonProperty("EKYC_de")]
        public string Ekycde { get; set; }

        [JsonProperty("AUA_Key")]
        public string AuaKey { get; set; }

        [JsonProperty("AUA_SA")]
        public string AuaSa { get; set; }


        [JsonProperty("Auth_tid")]
        public string AuthTid { get; set; }

        [JsonProperty("Meta_UDC")]
        public string MetaUdc { get; set; }

        [JsonProperty("Auth_RC")]
        public string AuthRc { get; set; }

        [JsonProperty("Ekyc_pfr")]
        public string EkycPfr { get; set; }

        [JsonProperty("EKYC_Wadh")]
        public string EkycWadh { get; set; }

        [JsonProperty("RFU1")]
        public string Rfu1 { get; set; }

        [JsonProperty("RFU2")]
        public string Rfu2 { get; set; }


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

        [JsonProperty("UI_Ref_Number")]
        public string UIRefNumber { get; set; }

        [JsonProperty("Tran_Identifier")]
        public string TranIdentifier { get; set; }


    }
}
