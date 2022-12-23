using Newtonsoft.Json;

namespace Common.Application.Dto
{
    public class FisResponse
    {
        [JsonProperty("returnCode")]
        public int ReturnCode { get; set; } = -1;


        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }
    }
}
