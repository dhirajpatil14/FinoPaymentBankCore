using Common.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRequest.Application.Models
{
    public class SaveServiceRequest : InRequest
    {
        public int TranType { get; set; }
        public string DistributorID { get; set; }
        public string Status { get; set; }

    }
}
