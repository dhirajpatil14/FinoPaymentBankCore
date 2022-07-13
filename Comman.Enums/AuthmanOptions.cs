using Utility.Attributes;

namespace Common.Enums
{
    public enum AuthmanOptions
    {
        [StringValue("GenerateOTP")]
        GenerateOTP = 1,
        [StringValue("VerifyOTP")]
        VerifyOTP = 2,
    }
}
