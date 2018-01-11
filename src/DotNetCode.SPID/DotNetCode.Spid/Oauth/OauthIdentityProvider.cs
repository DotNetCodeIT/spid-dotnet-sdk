using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid.Oauth
{
    public class OauthIdentityProvider : IdentityProvider
    {
        public OauthIdentityProvider(string IdentityProviderId) :base(IdentityProviderId, SpidProviderType.OpenId)
        {
           
        }
    }
}
