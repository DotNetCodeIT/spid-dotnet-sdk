using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid.OpenId
{
    public class OpenIdIdentityProvider:IdentityProvider
    {
        public OpenIdIdentityProvider(string IdentityProviderId) :base(IdentityProviderId, SpidProviderType.OpenId)
        {
           
        }
    }
}
