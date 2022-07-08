using Utility.Attributes;

namespace Common.Enums
{
    public enum AuthenticatorType
    {

        [StringValue("FINOTLR")]
        FINOTLR = 1,
        [StringValue("FINOMB")]
        FINOMB = 2,
        [StringValue("FINOMER")]
        FINOMER = 3,
        [StringValue("FINOMERNP")]
        FINOMERNP = 4,
        [StringValue("FINOIPS")]
        FINOIPS = 4,
        [StringValue("FINOPDS")]
        FINOPDS = 5,
        [StringValue("FINOINGE")]
        FINOINGE = 6

    }
}
