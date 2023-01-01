using Common.Application.Model;
using ServiceRequest.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequest.Application.Contracts.Identity
{
    public interface ISaveServiceRequestService
    {
        Task<OutResponse> PanValidation(SaveServiceRequest saveServiceRequest);
    }
}
