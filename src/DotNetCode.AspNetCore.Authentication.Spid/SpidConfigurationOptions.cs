using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using DotNetCode.Spid;

namespace DotNetCode.AspNetCore.Authentication.Spid
{
    public class SpidConfigurationOptions
    {
        public string ServiceProviderConfigurationFile { get; set; }

        public string ServiceProviderConfigurationUrl { get; set; }
    }
}