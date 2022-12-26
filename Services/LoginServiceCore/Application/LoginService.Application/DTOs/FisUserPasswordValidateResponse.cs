using Common.Application.Dto;
using Newtonsoft.Json;

namespace LoginService.Application.DTOs
{
    public class FisUserPasswordValidateResponse : FisResponse
    {
        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        [JsonProperty("date2")]
        public string Date2 { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("userDetails")]
        public UserDetails UserDetails { get; set; }

        [JsonProperty("succeeded_schemes")]
        public string[] SucceededSchemes { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }



        [JsonProperty("firstLoginKilled")]
        public bool FirstLoginKilled { get; set; }

        [JsonProperty("refresh_expires_in")]
        public long RefreshExpiresIn { get; set; }

        [JsonProperty("balancesList")]
        public BalancesList[] BalancesList { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("errors")]
        public object[] Errors { get; set; }

        [JsonProperty("force_change_password")]
        public bool ForceChangePassword { get; set; }

        [JsonProperty("tellerProofList")]
        public object TellerProofList { get; set; }
    }

    public partial class BalancesList
    {
        [JsonProperty("accountNo")]
        public string AccountNo { get; set; }

        [JsonProperty("ledgerBalance")]
        public double LedgerBalance { get; set; }

        [JsonProperty("availableBalance")]
        public double AvailableBalance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public partial class UserDetails
    {
        [JsonProperty("identifier")]
        public long? Identifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("userClass")]
        public UserClass UserClass { get; set; }

        [JsonProperty("branchAssociated")]
        public BranchAssociated BranchAssociated { get; set; }

        [JsonProperty("allowedToChangePostingDate")]
        public bool AllowedToChangePostingDate { get; set; }

        [JsonProperty("currencyEnvironment")]
        public long CurrencyEnvironment { get; set; }

        [JsonProperty("primaryCashLimit")]
        public double PrimaryCashLimit { get; set; }

        [JsonProperty("passwordExpired")]
        public bool PasswordExpired { get; set; }

        [JsonProperty("agencyDetails")]
        public AgencyDetails AgencyDetails { get; set; }

        [JsonProperty("fPIndex")]
        public long FPIndex { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("revoked")]
        public bool Revoked { get; set; }

        [JsonProperty("lastLoginDate")]
        public long[] LastLoginDate { get; set; }

        [JsonProperty("lastLoginTime")]
        public long[] LastLoginTime { get; set; }

        [JsonProperty("passwordExpirationDate")]
        public long[] PasswordExpirationDate { get; set; }

        [JsonProperty("merchantAccount")]
        public string MerchantAccount { get; set; }

        [JsonProperty("supervisorId")]
        public long SupervisorId { get; set; }
    }

    public partial class AgencyDetails
    {
    }

    public partial class BranchAssociated
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ifsc")]
        public string Ifsc { get; set; }

        [JsonProperty("micr")]
        public long Micr { get; set; }

        [JsonProperty("grid")]
        public long Grid { get; set; }

        [JsonProperty("defaultCostCenter")]
        public long DefaultCostCenter { get; set; }

        [JsonProperty("branchType")]
        public BranchType BranchType { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("cashOpen")]
        public bool CashOpen { get; set; }

        [JsonProperty("cts")]
        public bool Cts { get; set; }

        [JsonProperty("gridBranch")]
        public bool GridBranch { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("addressLine3")]
        public string AddressLine3 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("stateDescription")]
        public string StateDescription { get; set; }

        [JsonProperty("pinCode")]
        public long PinCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public partial class BranchType
    {
        [JsonProperty("type")]

        public long Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("subType")]

        public long SubType { get; set; }

        [JsonProperty("subtypedescription")]
        public string Subtypedescription { get; set; }
    }

    public partial class UserClass
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("maxDaysBackdatedAllowed")]
        public long MaxDaysBackdatedAllowed { get; set; }

        [JsonProperty("maxDaysFutureDatedAllowed")]
        public long MaxDaysFutureDatedAllowed { get; set; }
    }

}
