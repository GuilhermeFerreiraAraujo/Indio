﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Indio.Models.Requests
{
    public class SignUpRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
