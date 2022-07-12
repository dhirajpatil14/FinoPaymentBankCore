using Newtonsoft.Json;
using System;

namespace LoginService.Application.Models
{
    public class LoginResponse : LoginDataResponse
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }
        [JsonProperty("LastLogin")]
        private string LastLogin { get; set; } = DateTime.Now.ToString();

        [JsonProperty("CertificateExpiryDate")]
        public string CertificateExpiryDate { get; set; }

        [JsonProperty("usertypeID")]
        public string UserTypeId { get; set; }

        [JsonProperty("userRole")]
        public string UserRole { get; set; }

        [JsonProperty("eAgreement")]
        public string EAgreement { get; set; }

        [JsonProperty("CASAeAgreement")]
        public string CASAeAgreement { get; set; }

        [JsonProperty("RewardPoints")]
        public string RewardPoints { get; set; }

        [JsonProperty("EAgreementChanged")]
        public int EAgreementChanged { get; set; }

        [JsonProperty("CASAaddendum")]
        public int CASAaddendum { get; set; }

        [JsonProperty("FilebaseCasa")]
        public int FilebaseCasa { get; set; }

        [JsonProperty("eSurvey")]
        public int ESurvey { get; set; }

        [JsonProperty("zeroizationDateTime")]
        public string ZeroizationDateTime { get; set; }

        [JsonProperty("channelID")]
        public string ChannelID { get; set; }

        [JsonProperty("CurrentDateTime")]
        public string CurrentDateTime { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        [JsonProperty("StrConsent")]
        public string StrConsent { get; set; }

        [JsonProperty("StrOffer")]
        public string StrOffer { get; set; }


        [JsonProperty("LastDownloadDate")]
        public string LastDownloadDate { get; set; }

        [JsonProperty("category_code")]
        public string CategoryCode { get; set; }

    }
}
