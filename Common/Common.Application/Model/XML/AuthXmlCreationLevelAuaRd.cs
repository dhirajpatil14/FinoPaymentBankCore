using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Common.Application.Model.XML
{
    [XmlRoot("Auth_API_2_0", Namespace = "http://tempuri.org/")]
    public class AuthXmlCreationLevelAuaRd
    {
        [DataMember]
        public string AUA_Key { get; set; }
        [DataMember]
        public string Auth_UID { get; set; }
        [DataMember]
        public string Auth_TID { get; set; }
        [DataMember]
        public string Auth_VC { get; set; }
        [DataMember]
        public string Auth_txn { get; set; }
        [DataMember]
        public string Auth_RC { get; set; }
        [DataMember]
        public string Uses_pi { get; set; }
        [DataMember]
        public string Uses_pa { get; set; }
        [DataMember]
        public string Uses_pfa { get; set; }
        [DataMember]
        public string Uses_bio { get; set; }
        [DataMember]
        public string Uses_bt { get; set; }
        [DataMember]
        public string Uses_pin { get; set; }
        [DataMember]
        public string Uses_otp { get; set; }
        [DataMember]
        public string Meta_udc { get; set; }
        [DataMember]
        public string Meta_rdsId { get; set; }
        [DataMember]
        public string Meta_rdsVer { get; set; }
        [DataMember]
        public string Meta_dpId { get; set; }
        [DataMember]
        public string Meta_dc { get; set; }
        [DataMember]
        public string Meta_mi { get; set; }
        [DataMember]
        public string Meta_mc { get; set; }
        [DataMember]
        public string Skey_ci { get; set; }
        [DataMember]
        public string Auth_Skey_value { get; set; }
        [DataMember]
        public string Data_type { get; set; }
        [DataMember]
        public string Data_PID { get; set; }
        [DataMember]
        public string Auth_Hmac { get; set; }
        [DataMember]
        public string RFU1 { get; set; }
        [DataMember]
        public string RFU2 { get; set; }

        //RN1729
        [DataMember]
        public string User_Id { get; set; }
        [DataMember]
        public string HW_SerNum { get; set; }
        [DataMember]
        public string SourceType_AppId { get; set; }
        [DataMember]
        public string Branch_Code { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string UI_Ref_Number { get; set; }
        [DataMember]
        public string Tran_Identifier { get; set; }
    }
}
