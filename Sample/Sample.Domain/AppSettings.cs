namespace Sample.Domain
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string InstitutionId { get; set; }
        public string EsbURL { get; set; }
        public string CDMEncryptDecryptKey { get; set; }
        public string GeoCode { get; set; }
        public string IP { get; set; }
        public string Type { get; set; }
        public string OS { get; set; }
        public int Timeout { get; set; }
        public string CorsUrl { get; set; }
    }
}
