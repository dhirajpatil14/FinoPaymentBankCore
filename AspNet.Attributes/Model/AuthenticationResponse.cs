using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AspNet.Attributes.Model
{
    class AuthenticationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string PrimaryAccount { get; set; }
        public bool IsShowGLSettlement { get; set; }

        public bool IsGLAccount { get; set; }

        public string PrimaryMobile { get; set; }

        public string PartnerName { get; set; }

        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }

        public string JWToken { get; set; }

        //public string XAuthTokenId { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }


        public string SessionId { get; set; }
    }
}
