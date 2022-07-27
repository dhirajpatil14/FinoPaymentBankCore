namespace Common.Application.Model.Settings
{
    public class AppSettings : CommanSettings
    {
        public string Secret { get; set; }
        public string InstitutionId { get; set; }
        public string EsbURL { get; set; }
        public int Timeout { get; set; }
        public string DecryptKey { get; set; }
        public string DecryptKeygen { get; set; }

        public int SessionExpired { get; set; }
        public int LatitudeLongitude { get; set; }
        public int NoOfFinger { get; set; }
        public int Threshold { get; set; }
        public int AgreementExpiryday { get; set; }
        public int IsCacheFromDB { get; set; }
        public int IsSession { get; set; }
        public int IntByCache { get; set; }
    }
}
