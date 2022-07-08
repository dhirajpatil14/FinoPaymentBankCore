using Newtonsoft.Json;
using System;

namespace LoginService.Application.Models
{
    public class GeoUserLocation
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Lattitude")]
        public string Lattitude { get; set; }

        [JsonProperty("Longitude")]
        public string Longitude { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("IP_Address")]
        public string IPAddress { get; set; }

        [JsonProperty("TimeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("MAC_DeviceID")]
        public string MacDeviceId { get; set; }

        [JsonProperty("CellID")]
        public string CellId { get; set; }

        [JsonProperty("ChannelID")]
        public string Channel { get; set; }

        [JsonProperty("ServiceProvider")]
        public string ServiceProvider { get; set; }

        [JsonProperty("DeviceModel")]
        public string DeviceModel { get; set; }

        [JsonProperty("DeviceOS")]
        public string DeviceOS { get; set; }

        [JsonProperty("MCC")]
        public string Mcc { get; set; }

        [JsonProperty("MNC")]
        public string Mnc { get; set; }

        [JsonProperty("LanguageSupported")]
        public string LanguageSupported { get; set; }

        [JsonProperty("AuthenticationType")]
        public string AuthenticationType { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("BrowserInfo")]
        public string BrowserInfo { get; set; }

        [JsonProperty("UniqueRequestID")]
        public string UniqueRequestID { get; set; }

        [JsonProperty("FPTemplate")]
        public string FPTemplate { get; set; }

        [JsonProperty("UserTypeName")]
        public string UserTypeName { get; set; }

        [JsonProperty("AppDescName")]
        public string AppDescName { get; set; }

        [JsonProperty("GLAccount")]
        public string GLAccount { get; set; }
    }
}
