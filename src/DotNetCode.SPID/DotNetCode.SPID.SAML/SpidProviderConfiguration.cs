using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.SPID.SAML
{
    public class SpidProviderConfiguration
    {
      
        //Identity Provider Config
        public string IdentityProviderId { get; set; }

        public string IdentityProviderName { get; set; }

        public string IdentityProviderLoginPostUrl { get; set; }

        public string IdentityProviderLogoutPostUrl { get; set; }


        //Service Provider Config
        public string ServiceProviderId { get; set; }

        public string ServiceProviderCertPath { get; set; }

        public string ServiceProviderCertPassword { get; set; }

        public string ServiceProviderPrivatekey { get; set; }


        //Login Config
        public ushort LoginAssertionConsumerServiceIndex { get; set; }

        public ushort LoginAttributeConsumingServiceIndex { get; set; }

        public SPIDLevel LoginSPIDLevel { get; set; } = SPIDLevel.SPIDL1;
    }

  
}

