using Common.Application.Model;
using Newtonsoft.Json;

namespace LoginService.Application.DTOs
{
    public class FisUserPasswordValidateRequest
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("systemInfo")]
        public SystemInfo SystemInfo { get; set; }

        [JsonProperty("geoLocation")]
        public GeoLocation GeoLocation { get; set; }

        [JsonProperty("deviceId")]
        public object DeviceId { get; set; }

        [JsonProperty("xauthToken")]
        public object XauthToken { get; set; }

        [JsonProperty("biometric_fp")]
        public string BiometricFp { get; set; }

        [JsonProperty("otp")]
        public string Otp { get; set; }

        [JsonProperty("Aadhaar")]
        public Aadhaar Aadhaar { get; set; }

        [JsonProperty("ECBBlockEncryption")]
        public bool EcbBlockEncryption { get; set; }

        [JsonProperty("EncType")]
        public string EncType { get; set; }
    }




    public partial class GeoLocation
    {
        [JsonProperty("Lattitude")]
        public double Lattitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }
    }
    public partial class SystemInfo
    {
        [JsonProperty("Channel")]
        public long Channel { get; set; }

        [JsonProperty("IP")]
        public string Ip { get; set; }

        [JsonProperty("ISP")]
        public string Isp { get; set; }

        [JsonProperty("browser")]
        public string Browser { get; set; }

        [JsonProperty("Lattitude")]
        public double Lattitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("MAC_DeviceID")]

        public long MacDeviceId { get; set; }

        [JsonProperty("CellID")]

        public long CellId { get; set; }

        [JsonProperty("DeviceModel")]
        public string DeviceModel { get; set; }

        [JsonProperty("DeviceOS")]
        public string DeviceOs { get; set; }

        [JsonProperty("MCC")]
        public string Mcc { get; set; }

        [JsonProperty("MNC")]
        public string Mnc { get; set; }

        [JsonProperty("LanguageSupported")]
        public string LanguageSupported { get; set; }
    }
}
