using Newtonsoft.Json;
using System;

namespace Loggers.Logs.Model
{
    public class TableLoggerRequest
    {
        [JsonProperty("RequestID")]
        public string RequestID { get; set; }

        [JsonProperty("TokenID")]
        public string TokenID { get; set; }

        [JsonProperty("UserID")]
        public string UserID { get; set; }

        [JsonProperty("TellerID")]
        public string TellerID { get; set; }

        [JsonProperty("SessionID")]
        public string SessionID { get; set; }

        [JsonProperty("Form")]
        public string Form { get; set; }

        [JsonProperty("Module")]
        public string Module { get; set; }
        [JsonProperty("Message")]
        public string Message { get; set; }
        [JsonProperty("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("MobileNo")]
        public string MobileNo { get; set; }

        [JsonProperty("MethodId")]
        public int? MethodId { get; set; }
        [JsonProperty("ChannelID")]
        public int? ChannelID { get; set; }
    }
}
