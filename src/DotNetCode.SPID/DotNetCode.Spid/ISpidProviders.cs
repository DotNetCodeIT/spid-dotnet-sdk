using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DotNetCode.Spid
{
    /// <summary>
    /// ISpidIdentityProvider Interface
    /// </summary>
    public interface ISpidProvider
    {
        string Id { get; set; }
        string Name { get; set; }
        string Label { get; set; }
        string LogoImageUrl { get; set; }
        SpidProviderType ProviderType { get; }
    }

    /// <summary>
    /// ISamlSpidIdentityProvider Interface
    /// </summary>
    /// <seealso cref="Authentication.Spid.ISpidProvider" />
    public interface ISamlSpidProvider : ISpidProvider
    {

        /// <summary>
        /// Gets or sets the identity provider metadata.
        /// </summary>
        /// <value>
        /// The identity provider metadata.
        /// </value>
        string IdentityProviderMetadata { get; set; }

        /// <summary>
        /// Gets or sets the service provider metadata.
        /// </summary>
        /// <value>
        /// The service provider metadata.
        /// </value>
        string ServiceProviderMetadata { get; set; }


        /// <summary>
        /// Gets or sets the cert.
        /// </summary>
        /// <value>
        /// The cert.
        /// </value>
        X509Certificate2 Cert { get; set; }

        /// <summary>
        /// Gets or sets the cert password.
        /// </summary>
        /// <value>
        /// The cert password.
        /// </value>
        string CertPassword { get; set; }


        /// <summary>
        /// Loads the identity provider metadata.
        /// </summary>
        /// <returns></returns>
        bool LoadIdentityProviderMetadata();


        /// <summary>
        /// Loads the identity provider metadata.
        /// </summary>
        /// <param name="identityProviderMetadata">The identity provider metadata.</param>
        /// <returns></returns>
        bool LoadIdentityProviderMetadata(string identityProviderMetadata);


        /// <summary>
        /// Loads the service provider metadata.
        /// </summary>
        /// <returns></returns>
        bool LoadServiceProviderMetadata();


        /// <summary>
        /// Loads the service provider metadata.
        /// </summary>
        /// <param name="identityProviderMetadata">The identity provider metadata.</param>
        /// <returns></returns>
        bool LoadServiceProviderMetadata(string identityProviderMetadata);


        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <returns></returns>
        string GetSamlLoginRequest();

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <returns></returns>
        string GetSamlLoginRequest(ushort assertionConsumerServiceIndex);

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        string GetSamlLoginRequest(ushort assertionConsumerServiceIndex, SpidAuthLevel spidAuthLevel);

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <returns></returns>
        string GetSamlLoginRequest(ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex);

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        string GetSamlLoginRequest(ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex, SpidAuthLevel spidAuthLevel);


        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert);

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, ushort assertionConsumerServiceIndex);

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, ushort assertionConsumerServiceIndex, SpidAuthLevel spidAuthLevel);

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex);

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex, SpidAuthLevel spidAuthLevel);


        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="certPassword">The cert password.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword);

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="certPassword">The cert password.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword, ushort assertionConsumerServiceIndex);

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="certPassword">The cert password.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword, ushort assertionConsumerServiceIndex, SpidAuthLevel spidAuthLevel);

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="certPassword">The cert password.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex);

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="certPassword">The cert password.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        string GetSignedSamlLoginRequest(X509Certificate2 cert, string certPassword, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex, SpidAuthLevel spidAuthLevel);


        /// <summary>
        /// Gets the saml logout request.
        /// </summary>
        /// <returns></returns>
        string GetSamlLogoutRequest();

        /// <summary>
        /// Gets the saml logout request.
        /// </summary>
        /// <param name="logoutLevel">The logout level.</param>
        /// <returns></returns>
        string GetSamlLogoutRequest(SpidLogoutLevel logoutLevel);


        /// <summary>
        /// Gets the signed saml logout request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <returns></returns>
        string GetSignedSamlLogoutRequest(X509Certificate2 cert);

        /// <summary>
        /// Gets the signed saml logout request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="certPassword">The cert password.</param>
        /// <returns></returns>
        string GetSignedSamlLogoutRequest(X509Certificate2 cert, string certPassword);

        /// <summary>
        /// Gets the signed saml logout request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="logoutLevel">The logout level.</param>
        /// <returns></returns>
        string GetSignedSamlLogoutRequest(X509Certificate2 cert, SpidLogoutLevel logoutLevel);

        /// <summary>
        /// Gets the signed saml logout request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="certPassword">The cert password.</param>
        /// <param name="logoutLevel">The logout level.</param>
        /// <returns></returns>
        string GetSignedSamlLogoutRequest(X509Certificate2 cert, string certPassword, SpidLogoutLevel logoutLevel);

    }


    public interface IOpenIdSpidProvider : ISpidProvider
    {
        //Next Features
    }


    public interface IOauthSpidProvider : ISpidProvider
    {
        //Next Features
    }

}
