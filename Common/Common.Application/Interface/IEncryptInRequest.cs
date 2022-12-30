using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Application.Interface
{
    public interface IEncryptInRequest
    {
        public string payloadData { get; set; }
        public string hashValue { get; set; }
        public string sessionId { get; set; }
        public string rf { get; set; }
        public string CertificateId { get; set; }
        public int? AppChannelId { get; set; }
    }
}
