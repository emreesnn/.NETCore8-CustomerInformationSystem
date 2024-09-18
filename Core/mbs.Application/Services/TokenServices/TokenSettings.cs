﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Services.TokenServices
{
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
        public int TokenValidityInMinutes { get; set; }
    }
}
