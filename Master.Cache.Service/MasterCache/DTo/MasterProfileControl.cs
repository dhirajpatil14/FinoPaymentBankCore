using Newtonsoft.Json;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class MasterProfileControl
    {
        [JsonProperty("TabControlID")]
        public int TabControlID { get; set; }

        [JsonProperty("TabControlID")]
        public string ControlName { get; set; }

        [JsonProperty("ControlID")]
        public string ControlID { get; set; }

        [JsonProperty("ControlDesc")]
        public string ControlDesc { get; set; }

        [JsonProperty("TabID")]
        public string TabID { get; set; }


        [JsonProperty("Displayable")]
        public char Displayable { get; set; }

        [JsonProperty("Editable")]
        public char Editable { get; set; }

        [JsonProperty("Mandatory")]
        public char Mandatory { get; set; }


        [JsonProperty("KYCMandatory")]
        public char KYCMandatory { get; set; }


        [JsonProperty("FieldType")]
        public int FieldType { get; set; }


        [JsonProperty("DataType")]
        public string DataType { get; set; }

        [JsonProperty("ekyc")]
        public bool? Ekyc { get; set; }

        [JsonProperty("FieldLength")]
        public int FieldLength { get; set; }

        [JsonProperty("FieldMinLength")]
        public int FieldMinLength { get; set; }

        [JsonProperty("FieldMaxLength")]
        public int FieldMaxLength { get; set; }


        [JsonProperty("FieldMinValue")]
        public int FieldMinValue { get; set; }

        [JsonProperty("FieldMaxValue")]
        public int FieldMaxValue { get; set; }


        [JsonProperty("RequiredMaster")]
        public string RequiredMaster { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("KYCFlag")]
        public string KYCFlag { get; set; }

        [JsonProperty("RFU1")]
        public string RFU1 { get; set; }


        [JsonProperty("RFU2")]
        public string RFU2 { get; set; }


        [JsonProperty("ProductBenefit")]
        public string ProductBenefit { get; set; }


        [JsonProperty("EditableAddOn")]
        public string EditableAddOn { get; set; }


        [JsonProperty("DisplayableADDOn")]
        public string DisplayableADDOn { get; set; }


        //Add Jsonignore
        [JsonProperty("channelID")]
        public string ChannelID { get; set; }

        //Add Jsonignore
        [JsonProperty("ProductCode")]
        public int? ProductCode { get; set; }

        [JsonProperty("appChannelid")]
        public int? AppChannelid { get; set; } = null;

    }
}
