﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Infrastructure.Authentication
{
    public sealed class AuthenticationOptions
    {
        public string Audience { get; init; } = string.Empty;

        public string MetadataUrl { get; init; } = string.Empty;

        public bool RequireHttpsMetadata { get; init; }

        public string Issuer { get; init; } = string.Empty;
    }
}
