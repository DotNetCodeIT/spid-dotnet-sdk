using System;

namespace DotNetCode.Spid
{
    public interface ISpidProviderFactory
    {
        /// <summary>
        /// Gets the saml spid identity provider.
        /// </summary>
        /// <returns></returns>
        ISamlSpidProvider GetSamlSpidProvider();

        /// <summary>
        /// Gets the saml spid identity provider.
        /// </summary>
        /// <param name="spidProvider">The spid provider.</param>
        /// <returns></returns>
        ISamlSpidProvider GetSamlSpidProvider(ISpidProvider spidProvider);

        /// <summary>
        /// Gets the open identifier spid identity provider.
        /// </summary>
        /// <returns></returns>
                IOpenIdSpidProvider GetOpenIdSpidProvider();
        
        /// <summary>
        /// Gets the open identifier spid identity provider.
        /// </summary>
        /// <param name="spidProvider">The spid provider.</param>
        /// <returns></returns>
                IOpenIdSpidProvider GetOpenIdSpidProvider(ISpidProvider spidProvider);
        
        /// <summary>
        /// Gets the oauth spid identity provider.
        /// </summary>
        /// <returns></returns>
                IOauthSpidProvider GetOauthSpidProvider();
        
        /// <summary>
        /// Gets the oauth spid identity provider.
        /// </summary>
        /// <param name="spidProvider">The spid provider.</param>
        /// <returns></returns>
        IOauthSpidProvider GetOauthSpidProvider(ISpidProvider spidProvider);

        /// <summary>
        /// Gets the type of the provider.
        /// </summary>
        /// <value>
        /// The type of the provider.
        /// </value>
        //SpidProviderType ProviderType { get; }
    }
}
