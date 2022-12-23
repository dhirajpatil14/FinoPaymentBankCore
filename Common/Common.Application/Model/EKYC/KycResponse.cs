using System.Xml.Serialization;

namespace Common.Application.Model.EKYC
{
    public sealed class KycResponse
    {
        [XmlAttribute("ret")]
        public string Ret { get; set; }

        [XmlAttribute("Mapper_ID")]
        public string MapperId { get; set; }

        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("txn")]
        public string Txn { get; set; }

        [XmlAttribute("err")]
        public string Err { get; set; }

        [XmlAttribute("info")]
        public string Info { get; set; }

        [XmlAttribute("ts")]
        public string Ts { get; set; }

        [XmlAttribute("RarData")]
        public string RarData { get; set; }

        [XmlElement("Poi")]
        public Poi Poi { get; set; }


        [XmlElement("Poa")]
        public Poa Poa { get; set; }

        [XmlElement("UidData")]
        public UidData UidData { get; set; }

        [XmlElement("Pht")]
        public Pht Pht { get; set; }


        [XmlElement("RRN")]



        public string name { get; set; }


        [XmlElement("dob")]

        public string Dob { get; set; }

        [XmlElement("gender")]

        public string Gender { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string co { get; set; }

        public string street { get; set; }

        public string house { get; set; }

        public string lm { get; set; }

        public string loc { get; set; }

        public string vtc { get; set; }

        public string subdist { get; set; }

        public string dist { get; set; }

        public string state { get; set; }

        public string pc { get; set; }

        public string po { get; set; }

        public string Phto { get; set; }

        public string uid { get; set; }

        public string RRN { get; set; }




        public string LData_name { get; set; }

        public string LData_co { get; set; }

        public string LData_street { get; set; }

        public string LData_house { get; set; }

        public string LData_lm { get; set; }

        public string LData_loc { get; set; }

        public string LData_vtc { get; set; }

        public string LData_subdist { get; set; }

        public string LData_dist { get; set; }

        public string LData_state { get; set; }

        public string LData_pc { get; set; }

        public string LData_po { get; set; }

        public string BFD_Val { get; set; }

        public string BFD_Name { get; set; }


    }
    #region "Poi"
    public class Poi
    {
        [XmlAttribute("dob")]
        public string Dob { get; set; }

        [XmlAttribute("email")]
        public string Email { get; set; }

        [XmlAttribute("gender")]
        public string Gender { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("phone")]
        public string Phone { get; set; }
    }
    #endregion

    #region "Class Poa"
    public class Poa
    {
        [XmlAttribute("co")]
        public string Co { get; set; }

        [XmlAttribute("house")]
        public string House { get; set; }

        [XmlAttribute("street")]
        public string Street { get; set; }

        [XmlAttribute("lm")]
        public string Lm { get; set; }

        [XmlAttribute("loc")]
        public string Loc { get; set; }

        [XmlAttribute("vtc")]
        public string Vtc { get; set; }

        [XmlAttribute("dist")]
        public string Dist { get; set; }

        [XmlAttribute("subdist")]
        public string Subdist { get; set; }

        [XmlAttribute("pc")]
        public string Pc { get; set; }

        [XmlAttribute("po")]
        public string Po { get; set; }

        [XmlAttribute("state")]
        public string State { get; set; }
    }
    #endregion

    #region "UidData"
    public class UidData
    {
        [XmlAttribute("uid")]
        public string Uid { get; set; }
    }
    #endregion

    #region "Class Pht"
    public class Pht
    {
        [XmlElement("Phto")]
        public string Phto { get; set; }
    }
    #endregion
}
