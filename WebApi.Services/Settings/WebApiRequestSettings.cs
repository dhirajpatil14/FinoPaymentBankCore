using System.Collections.Generic;

namespace WebApi.Services.Settings
{
    public class WebApiRequestSettings<T1> where T1 : new()
    {
        public string URL { get; set; }
        public string Parameter { get; set; }
        public T1 PostParameter { get; set; }
        public int Timeout { get; set; }
        public string CertificatePath { get; set; } = string.Empty;
        public string XAuthToken { get; set; } = string.Empty;
        public string TokenId { get; set; } = string.Empty;
        public string RequestId { get; set; } = string.Empty;

        public string RequesterId { get; set; } = string.Empty;

        public bool AcceptAllCertificatePolicy { get; set; }
        public bool KeepAlive { get; set; }
        public string ContentType { get; } = "application/json";
        public string Connection { get; } = "Keep-Alive";



        public IDictionary<string, string> QueryParameter { get; set; }



    }
}
