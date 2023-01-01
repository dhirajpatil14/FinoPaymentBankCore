using Common.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PBSecurity.Model
{
    class PBModel
    {
    }

    public class EncryptInRequest : IEncryptInRequest
    {
        [JsonPropertyName("payloadData")]
        public string payloadData { get; set; }
        [JsonPropertyName("hashValue")]
        public string hashValue { get; set; }
        [JsonPropertyName("sessionId")]
        public string sessionId { get; set; }
        [JsonPropertyName("rf")]
        public string rf { get; set; }
        [JsonPropertyName("CertificateId")]
        public string CertificateId { get; set; }
        [JsonPropertyName("AppChannelId")]
        public int? AppChannelId { get; set; }
    }

    public class AuthenticationEnRequest
    {
        public string message { get; set; }
        public Boolean isValid { get; set; }
        public String SK { get; set; }
        public String ResponseCode { get; set; }
    }
    public class Common
    {
        [JsonPropertyName("RequestId")]
        public string RequestId { get; set; }
        [JsonPropertyName("SessionId")]
        public string SessionId { get; set; }
        [JsonPropertyName("SessionExpiryTime")]
        public string SessionExpiryTime { get; set; }
    }
    public class InRequest : Common
    {
        [JsonPropertyName("MethodId")]
        public int MethodId { get; set; }
        [JsonPropertyName("TellerID")]
        public string TellerId { get; set; }
        [JsonPropertyName("TokenId")]
        public string TokenId { get; set; }
        [JsonPropertyName("IsEncrypt")]
        public bool IsEncrypt { get; set; }
        [JsonPropertyName("RequestData")]
        public string RequestData { get; set; }
        [JsonPropertyName("X_Auth_Token")]
        public string XAuthToken { get; set; }
        [JsonPropertyName("ChannelID")]
        public int ChannelID { get; set; }
        [JsonPropertyName("ProductCode")]
        public string ProductCode { get; set; }
        [JsonPropertyName("ServiceID")]
        public int ServiceID { get; set; }

        public string ReturnId()
        {
            if (!string.IsNullOrEmpty(this.RequestId))
            {
                return this.RequestId.Split('_')[0].ToString();
            }
            return string.Empty;
        }
    }
    public class PBSecurityResponse : InRequest
    {
        public string message { get; set; }
        public Boolean isValid { get; set; }
        public String SK { get; set; }
        public String ResponseCode { get; set; }
    }
}
