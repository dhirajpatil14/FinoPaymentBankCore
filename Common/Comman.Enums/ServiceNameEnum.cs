using Utility.Attributes;

namespace Common.Enums
{
    public enum ServiceName
    {
        [IntValueAttribute(26)]
        UPISERVICE = 26,

        [IntValueAttribute(1)]
        LOGINSERVICE = 1,

        [IntValueAttribute(2)]
        TRANSACTIONSERVICE = 2,

        [IntValueAttribute(16)]
        UTILITYSERVICE = 16,

        [IntValueAttribute(2)]
        Service = 2,

        [IntValueAttribute(111)]
        PARTNERSERVICE = 111,

        [IntValueAttribute(112)]
        OTPSERVICE = 112,

        [IntValueAttribute(113)]
        MERCHANTSERVICE = 113


    }
}
