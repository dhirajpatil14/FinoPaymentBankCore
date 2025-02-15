﻿using Microsoft.AspNetCore.Mvc;
using ServiceRequest.Application.Contracts.Identity;
using ServiceRequest.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceRequestCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IProcessSSRService _processSSRService;
        public ServiceRequestController()
        {

        }

        [HttpPost("serviceRequest")]
        public async Task<IActionResult> SaveServiceRequestAsync(SaveServiceRequest saveServiceRequest)
        {
            return Ok(await _processSSRService.SaveServiceAsync(saveServiceRequest));
        }
    }
}
