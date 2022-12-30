using Utility.Attributes;

namespace Common.Enums
{
    public enum PBMaster
    {
        [StringValue("MstUPIErrorCodes")]
        MSTUPIERRORCODES = 1,

        [StringValue("mstIFSCMapping")]
        MSTIFSCMAPPING = 2,

        [StringValue("mstEsbMessages")]
        ESBMessages = 3,

        [StringValue("ReasonMaster")]
        ReasonMaster = 4,

        [StringValue("mstUserType")]
        USERTYPE = 5,

        [StringValue("MasterCache")]
        MasterCache = 6,

        [StringValue("mstMobileVersion")]
        MobileVersion = 7,

        [StringValue("tblMastersStatus")]
        MasterStatus = 8,

        [StringValue("tblCacheAuditTrail")]
        CacheAuditTrail = 9,

        [StringValue("MstSSLCretificate")]
        SSLCertificate

    }
}
