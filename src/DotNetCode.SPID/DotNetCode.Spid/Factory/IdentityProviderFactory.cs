using DotNetCode.Spid.SAML;
using DotNetCode.Spid.OpenId;
using DotNetCode.Spid.Oauth;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid.Factory
{
    public static class IdentityProviderFactory
    {
     

        public static IdentityProvider GetIdentityProvider(string IdentityProviderId, SpidProviderType providerType)
        {

            switch (providerType)
            {
                case SpidProviderType.Saml2:
                    return new SamlIdentityProvider(IdentityProviderId) { Settings = SamlSettings.DefaultSettings };

                case SpidProviderType.OpenId:
                    return new OpenIdIdentityProvider(IdentityProviderId) { Settings = OpenIdSettings.DefaultSettings };

                case SpidProviderType.Oauth:
                    return new OauthIdentityProvider(IdentityProviderId) { Settings = OauthSettings.DefaultSettings };
                
                default:
                    throw new ArgumentException("providerType");
            }
        }

    }
}
