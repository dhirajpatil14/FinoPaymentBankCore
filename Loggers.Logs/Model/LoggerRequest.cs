using Newtonsoft.Json;
using System;

namespace Loggers.Logs.Model
{
    public class LoggerRequest
    {

        [JsonProperty("Service_ID")]
        public int ServiceId { get; set; }

        [JsonProperty("Method_ID")]
        public int MethodId { get; set; }

        [JsonProperty("Layer_ID")]
        public int LayerId { get; set; }

        [JsonProperty("Request_Flag")]
        public bool RequestFlag { get; set; }

        [JsonProperty("Response_Flag")]
        public bool ResponseFlag { get; set; }

        [JsonProperty("Corelation_Request")]
        public string CorelationRequest { get; set; }

        [JsonProperty("Corelation_Session")]
        public string CorelationSession { get; set; }
        [JsonProperty("Node_IP_Address")]
        public string NodeIPAddress { get; set; }
        [JsonProperty("RequestIn")]
        public DateTime? RequestIn { get; set; }
        [JsonProperty("RequestOut")]
        public DateTime? RequestOut { get; set; }

        [JsonProperty("Response_Message")]
        public string ResponseMessage { get; set; }

        [JsonProperty("Status_Code")]
        public int StatusCode { get; set; }
        [JsonProperty("Channel_ID")]
        public int? ChannelID { get; set; }
        [JsonProperty("CMSClientID")]
        public string CMSClientID { get; set; }


    }
}
