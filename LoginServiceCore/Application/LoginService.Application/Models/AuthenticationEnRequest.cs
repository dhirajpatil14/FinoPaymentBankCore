﻿using Common.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginService.Application.Models
{
    public class AuthenticationEnRequest : EncryptInRequest
    {
        public string message { get; set; }
        public Boolean isValid { get; set; }
        public String SK { get; set; }
        public String ResponseCode { get; set; }
    }
}
