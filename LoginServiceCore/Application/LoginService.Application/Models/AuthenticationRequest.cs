using Common.Application.Model;

namespace LoginService.Application.Models
{
    public class AuthenticationRequest : InRequest
    {

        public int TranType { get; set; }

        public string DistributorID { get; set; }
        public string Status { get; set; }
    }
}
