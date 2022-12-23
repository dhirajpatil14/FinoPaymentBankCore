using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class MobileRoleMenu
    {
        [JsonPropertyName("menuPositionDesc")]
        public string MenuPositionDesc { get; set; }

        [JsonPropertyName("listmobMenu")]
        public IEnumerable<RoleMenu> MobileMenu { get; set; }
    }
}
