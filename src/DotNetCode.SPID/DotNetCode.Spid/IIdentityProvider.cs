using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid
{
    public interface IIdentityProvider
    {

        string IdentityProviderId { get; set; }

        string OrganizationName { get; set; }

        string OrganizationDisplayName { get; set; }

        string OrganizationUrl { get; set; }

        string OrganizationLogoUrl { get; set; }
        
        SpidProviderType IdentityProviderType { get; }

        Dictionary<string, string> Settings { get; set; }
 
    }

  
}
