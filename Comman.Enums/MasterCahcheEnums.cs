using Utility.Attributes;

namespace Common.Enums
{
    public enum MasterCahcheEnums
    {
        #region Master cache key
        [StringValueAttribute("MasterCacheCategory")]
        MASTERCACHECATEGORY = 1,
        [StringValueAttribute("MasterCacheMobileCategory")]
        MASTERCACHEMOBILECATEGORY = 2,
        [StringValueAttribute("MasterCache")]
        MASTERCACHE = 3,
        [StringValueAttribute("MasterCacheZip")]
        MASTERCACHEZIP = 4,
        #endregion
    }
}
