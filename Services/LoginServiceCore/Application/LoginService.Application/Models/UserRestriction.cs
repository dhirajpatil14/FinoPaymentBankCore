using Newtonsoft.Json;
using System;

namespace LoginService.Application.Models
{
    public class UserRestriction
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("IPAddress")]
        public string IPAddress { get; set; }

        [JsonProperty("CellId")]
        public string CellID { get; set; }

        [JsonProperty("DeviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("Mcc")]
        public string MCC { get; set; }

        [JsonProperty("Latitude")]
        public string Latitude { get; set; }

        [JsonProperty("Longitude")]
        public string Longitude { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }

        [JsonProperty("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }


    }
}
