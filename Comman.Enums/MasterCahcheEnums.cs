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
        [StringValueAttribute("RESETMASTERBYCATEGORY")]
        RESETMASTERBYCATEGORY = 5,
        [StringValueAttribute("RESETMASTERBYCATEGORYWITHOUTINC")]
        RESETMASTERBYCATEGORYWITHOUTINC = 6,
        [StringValueAttribute("RESETMASTERBYCATEGORYMOBILE")]
        RESETMASTERBYCATEGORYMOBILE = 7,
        [StringValueAttribute("RESETMASTERBYCATEGORYMOBILEWITHOUTINC")]
        RESETMASTERBYCATEGORYMOBILEWITHOUTINC = 8,
        [StringValueAttribute("RESETMASTER")]
        RESETMASTER = 9,
        [StringValueAttribute("RESETMASTERWITHOUTINC")]
        RESETMASTERWITHOUTINC = 10,
        [StringValueAttribute("RESETINDIVIDUALMASTER")]
        RESETINDIVIDUALMASTER = 11,
        #endregion
    }
}
