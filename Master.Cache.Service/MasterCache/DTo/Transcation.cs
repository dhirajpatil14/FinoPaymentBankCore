using System.Text.Json.Serialization;

namespace Master.Cache.Service.MasterCache.DTo
{
    public class Transcation
    {

        [JsonPropertyName("TID")]
        public int Tid { get; set; }

        [JsonPropertyName("Ty")]
        public string Ty { get; set; }

        [JsonPropertyName("Nm")]
        public string Nm { get; set; }

        [JsonPropertyName("FI")]
        public string Fi { get; set; }

        [JsonIgnore]
        public string ProductTypeId { get; set; }

    }


}
