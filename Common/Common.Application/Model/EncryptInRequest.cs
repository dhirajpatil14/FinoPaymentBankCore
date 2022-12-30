using Common.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Application.Model
{
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
}
