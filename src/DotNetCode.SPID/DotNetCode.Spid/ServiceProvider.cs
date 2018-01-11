using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid
{
    public class ServiceProvider
    {
        public  string ServiceProviderId { get; set; }
        public  string OrganizationName { get; set; }
        public  string OrganizationDisplayName { get; set; }
        public  string OrganizationUrl { get; set; }

        public  List<IdentityProvider> IdentityProviders{ get; set; }

    }
}
