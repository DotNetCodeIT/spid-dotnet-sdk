using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid
{
    public class OauthSpidProvider : IOauthSpidProvider
    {
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LogoImageUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SpidProviderType ProviderType => throw new NotImplementedException();
    }
}
