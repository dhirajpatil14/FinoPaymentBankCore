using System;
using System.Collections.Generic;
using System.Text;

namespace PBSecurity.Model
{
    public class MstSSLCertificate
    {
        public int Id { get; set; }
        public string CertificateName { get; set; }
        public string CertificateId { get; set; }
        public string CertificatePath { get; set; }
        public string CertificatePassword { get; set; }
        public string KeyExpiryDate { get; set; }
    }
}
