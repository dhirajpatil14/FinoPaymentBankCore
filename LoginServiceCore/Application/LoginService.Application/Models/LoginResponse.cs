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
        public string EAgreementChanged { get; set; }

        [JsonProperty("CASAaddendum")]
        public string CASAaddendum { get; set; }

        [JsonProperty("FilebaseCasa")]
        public string FilebaseCasa { get; set; }

        [JsonProperty("eSurvey")]
        public string ESurvey { get; set; }

        [JsonProperty("zeroizationDateTime")]
        public string ZeroizationDateTime { get; set; }

        [JsonProperty("channelID")]
        public string ChannelID { get; set; }

        [JsonProperty("CurrentDateTime")]
        private string CurrentDateTime { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

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
