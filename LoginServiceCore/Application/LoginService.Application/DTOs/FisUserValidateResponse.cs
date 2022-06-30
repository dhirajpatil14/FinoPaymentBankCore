using Newtonsoft.Json;

namespace LoginService.Application.DTOs
{
    public class FisUserValidateResponse
    {
        [JsonProperty("returnCode")]
        public int ReturnCode { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("subUserClass")]
        public long SubUserClass { get; set; }

        [JsonProperty("fpIndex")]
        public long FpIndex { get; set; }

        [JsonProperty("aadharNumber")]
        public string AadharNumber { get; set; }

        [JsonProperty("branchCode")]
        public long BranchCode { get; set; }

        [JsonProperty("policies")]
        public Policy[] Policies { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("user_roles")]
        public string[] UserRoles { get; set; }

        [JsonProperty("mobile_no")]
        public string MobileNo { get; set; }

        [JsonProperty("encryption_key")]
        public string EncryptionKey { get; set; }

        [JsonProperty("security_profile")]
        public SecurityProfile SecurityProfile { get; set; }
    }

    public partial class Policy
    {
        [JsonProperty("policy")]
        public string PolicyPolicy { get; set; }

        [JsonProperty("priority")]
        public long Priority { get; set; }

        [JsonProperty("abort_on_failure")]
        public bool AbortOnFailure { get; set; }
    }

    public partial class SecurityProfile
    {
        [JsonProperty("last_login_time")]
        public long[] LastLoginTime { get; set; }

        [JsonProperty("is_last_login_failed")]
        public bool IsLastLoginFailed { get; set; }

        [JsonProperty("is_user_locked")]
        public bool IsUserLocked { get; set; }

        [JsonProperty("last_login_date")]
        public long[] LastLoginDate { get; set; }

        [JsonProperty("failure_count")]
        public long FailureCount { get; set; }

        [JsonProperty("failure_sec_question_count")]
        public long FailureSecQuestionCount { get; set; }

        [JsonProperty("first_login_time")]
        public long[] FirstLoginTime { get; set; }

        [JsonProperty("first_login_date")]
        public long[] FirstLoginDate { get; set; }
    }

}
