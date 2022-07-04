using Common.Application.Model;

namespace LoginService.Application.Models
{
    public class AuthenticationRequest : InRequest
    {

        public int TranType { get; set; }

        public string DistributorID { get; set; }
        public string Status { get; set; }

        public string ReturnId()
        {
            if (!string.IsNullOrEmpty(this.RequestId))
            {
                return this.RequestId.Split('_')[0].ToString();
            }
            return string.Empty;
        }

    }
}
