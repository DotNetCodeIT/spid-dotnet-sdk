using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DotNetCode.Spid
{
    public class SamlSpidProvider : ISamlSpidProvider
    {
        public string IdentityProviderMetadata { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ServiceProviderMetadata { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public X509Certificate2 Cert { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CertPassword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Label { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LogoImageUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SpidProviderType ProviderType => throw new NotImplementedException();

        public string GetSamlLoginRequest()
        {
            throw new NotImplementedException();
        }

        public string GetSamlLoginRequest(ushort assertionConsumerServiceIndex)
        {
            throw new NotImplementedException();
        }

        public string GetSamlLoginRequest(ushort assertionConsumerServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            throw new NotImplementedException();
        }

        public string GetSamlLoginRequest(ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex)
        {
            throw new NotImplementedException();
        }

        public string GetSamlLoginRequest(ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            throw new NotImplementedException();
        }

        public string GetSamlLogoutRequest()
        {
            throw new NotImplementedException();
        }

        public string GetSamlLogoutRequest(SpidLogoutLevel logoutLevel)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, ushort assertionConsumerServiceIndex)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, ushort assertionConsumerServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword, ushort assertionConsumerServiceIndex)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword, ushort assertionConsumerServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLogoutRequest(X509Certificate2 cert)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLogoutRequest(X509Certificate2 cert, string certPassword)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLogoutRequest(X509Certificate2 cert, SpidLogoutLevel logoutLevel)
        {
            throw new NotImplementedException();
        }

        public string GetSignedSamlLogoutRequest(X509Certificate2 cert, string certPassword, SpidLogoutLevel logoutLevel)
        {
            throw new NotImplementedException();
        }

        public bool LoadIdentityProviderMetadata()
        {
            throw new NotImplementedException();
        }

        public bool LoadIdentityProviderMetadata(string identityProviderMetadata)
        {
            throw new NotImplementedException();
        }

        public bool LoadServiceProviderMetadata()
        {
            throw new NotImplementedException();
        }

        public bool LoadServiceProviderMetadata(string identityProviderMetadata)
        {
            throw new NotImplementedException();
        }
    }
}
