using Newtonsoft.Json;
using System;

namespace LoginService.Application.Models
{
    public class EAgreement
    {
        [JsonProperty("MerchantName")]
        public string MerchantName { get; set; }

        [JsonProperty("DistributorName")]
        public string DistributorName { get; set; }

        [JsonProperty("CASAaddendum")]
        public int CASAaddendum { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }



    }
}
