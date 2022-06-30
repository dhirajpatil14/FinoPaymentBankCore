namespace LoginService.Application.Models.Settings
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string InstitutionId { get; set; }
        public string EsbURL { get; set; }
        public int Timeout { get; set; }

        public string DecryptKey { get; set; }

        public string DecryptKeygen { get; set; }

        public string ESBCBSMessagesByCache { get; set; }

        public int SessionExpired { get; set; }

    }
}
