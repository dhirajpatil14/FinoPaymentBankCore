﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Application.Model
{
    public class PBSecurityResponse : InRequest
    {
        public string message { get; set; }
        public Boolean isValid { get; set; }
        public String SK { get; set; }
        public String ResponseCode { get; set; }
    }
}
