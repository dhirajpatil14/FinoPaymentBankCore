using Newtonsoft.Json;

namespace LoginService.Application.Models
{
    public class UserRestriction
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("IPAddress")]
        public string IPAddress { get; set; }

        [JsonProperty("CellId")]
        public int? CellID { get; set; }

        [JsonProperty("DeviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("Mcc")]
        public string MCC { get; set; }

        [JsonProperty("Latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }
    }
}
