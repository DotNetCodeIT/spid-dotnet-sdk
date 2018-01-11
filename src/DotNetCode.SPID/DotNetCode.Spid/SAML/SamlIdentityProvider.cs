using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid.SAML
{
    public class SamlIdentityProvider:IdentityProvider
    {
        public SamlIdentityProvider(string IdentityProviderId) :base(IdentityProviderId, SpidProviderType.Saml2)
        {
           
        }
    }
}
