using Utility.Attributes;

namespace Common.Enums
{
    public enum CacheEnum : int
    {
        #region session cache key

        [StringValueAttribute("XauthToken")]
        XAUTHTOKEN = 1
        #endregion
    }
}
