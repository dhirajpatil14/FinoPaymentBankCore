using Newtonsoft.Json;

namespace Common.Application.Model
{
    public class EsbUrl
    {
        [JsonProperty("ESBURLID")]
        public int? ESBUrlId { get; set; } = null;

        [JsonProperty("ESBURL")]
        public string ESBUrl { get; set; }

        [JsonProperty("ESBURLDescreption")]
        public string ESBUrlDescreption { get; set; }

        [JsonProperty("ServiceUrlId")]
        public string ServiceUrlId { get; set; }

        [JsonProperty("ServiceName")]
        public string ServiceName { get; set; }

        [JsonProperty("isESBUrl")]
        public int? IsESBUrl { get; set; } = null;
    }
}
