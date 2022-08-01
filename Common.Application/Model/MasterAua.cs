using System.Text.Json.Serialization;

namespace Common.Application.Model
{
    public class MasterAua
    {
        [JsonPropertyName("ID")]
        public int? Id { get; set; } = null;

        [JsonPropertyName("AUA_Key")]
        public string AuaKey { get; set; }

        [JsonPropertyName("VendorCode")]
        public string VendorCode { get; set; }

        [JsonPropertyName("AUA_ExpiryDate")]
        public string AuaExpiryDate { get; set; }

        [JsonPropertyName("UDC")]
        public string Udc { get; set; }

        [JsonPropertyName("Status")]
        public bool? Status { get; set; } = null;




    }
}
