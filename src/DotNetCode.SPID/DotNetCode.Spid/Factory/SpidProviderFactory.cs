using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid.Factory
{
    public class SpidProviderFactory : ISpidProviderFactory
    {
        //public SpidProviderType ProviderType => throw new NotImplementedException();

      

        public IOauthSpidProvider GetOauthSpidProvider()
        {
            return new OauthSpidProvider();
        }

        public IOauthSpidProvider GetOauthSpidProvider(ISpidProvider spidProvider)
        {
            return new OauthSpidProvider()
            {
                Id = spidProvider.Id,
                Label = spidProvider.Label,
                LogoImageUrl = spidProvider.LogoImageUrl,
                Name = spidProvider.Name
            };
        }

        public IOpenIdSpidProvider GetOpenIdSpidProvider()
        {
            return new OpenIdSpidProvider();
        }

        public IOpenIdSpidProvider GetOpenIdSpidProvider(ISpidProvider spidProvider)
        {
            return new OpenIdSpidProvider()
            {
                Id = spidProvider.Id,
                Label = spidProvider.Label,
                LogoImageUrl = spidProvider.LogoImageUrl,
                Name = spidProvider.Name
            };
        }

        public ISamlSpidProvider GetSamlSpidProvider()
        {
            return new SamlSpidProvider();
        }

        public ISamlSpidProvider GetSamlSpidProvider(ISpidProvider spidProvider)
        {
            return new SamlSpidProvider()
            {
                Id = spidProvider.Id,
                Label = spidProvider.Label,
                LogoImageUrl = spidProvider.LogoImageUrl,
                Name = spidProvider.Name
            };
        }
    }
}
