using System.Text.Json.Serialization;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class RoleMenu
    {
        [JsonPropertyName("MenuID")]
        public string MenuId { get; set; }

        [JsonPropertyName("MenuDescription")]
        public string MenuDescription { get; set; }

        [JsonPropertyName("MenuParent")]
        public string MenuParent { get; set; }

        [JsonPropertyName("MenuUrl")]
        public string MenuUrl { get; set; }

        [JsonPropertyName("MenuPosition")]
        public string MenuPosition { get; set; }

        [JsonPropertyName("OnClickFunction")]
        public string OnClickFunction { get; set; }

        [JsonPropertyName("Menu_cssClass")]
        public string MenuCssClass { get; set; }

        [JsonPropertyName("Menu_cssIconClass")]
        public string MenuCssIconClass { get; set; }

        [JsonPropertyName("FormID")]
        public string FormId { get; set; }

        [JsonPropertyName("MenuIdKey")]
        public string MenuIdKey { get; set; }



        [JsonPropertyName("status")]
        public bool? Status { get; set; } = null;




    }
}
