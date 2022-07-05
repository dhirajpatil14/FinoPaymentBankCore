using System.Xml.Serialization;

namespace Common.Application.Model.EKYC
{
    public sealed class KycResponseRd
    {
        [XmlAttribute("Resp")]
        public string PidData { get; set; }

        [XmlAttribute("DeviceInfo")]
        public string DeviceInfo { get; set; }

        [XmlAttribute("Skey")]
        public string Skey { get; set; }

        [XmlAttribute("Hmac")]
        public string Hmac { get; set; }

        [XmlAttribute("Data")]
        public string PID { get; set; }

        [XmlAttribute("ISFIR")]
        public string ISFIR { get; set; }

        public string errCode { get; set; }

        public string errInfo { get; set; }

        public string fCount { get; set; }

        public string fType { get; set; }

        public string iCount { get; set; }

        public string pCount { get; set; }

        public string nmPoints { get; set; }

        public string dpId { get; set; }

        public string rdsId { get; set; }

        public string rdsVer { get; set; }

        public string dc { get; set; }

        public string mi { get; set; }

        public string mc { get; set; }

        public string ci { get; set; }

        public string type { get; set; }

    }
}
