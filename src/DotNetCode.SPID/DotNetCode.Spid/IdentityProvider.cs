using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid
{
    public class IdentityProvider : IIdentityProvider
    {

        /// <summary>
        /// Gets or sets the identity provider identifier.
        /// </summary>
        /// <value>
        /// The identity provider identifier.
        /// </value>
        public string IdentityProviderId { get; set; }

        /// <summary>
        /// Gets or sets the name of the organization.
        /// </summary>
        /// <value>
        /// The name of the organization.
        /// </value>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Gets or sets the display name of the organization.
        /// </summary>
        /// <value>
        /// The display name of the organization.
        /// </value>
        public string OrganizationDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the organization URL.
        /// </summary>
        /// <value>
        /// The organization URL.
        /// </value>
        public string OrganizationUrl { get; set; }

        /// <summary>
        /// Gets or sets the organization logo URL.
        /// </summary>
        /// <value>
        /// The organization logo URL.
        /// </value>
        public string OrganizationLogoUrl { get; set; }

        //
        /// <summary>
        /// Gets the type of the identity provider.
        /// </summary>
        /// <value>
        /// The type of the identity provider.
        /// </value>
        public SpidProviderType IdentityProviderType { get; private set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public Dictionary<string, string> Settings { get; set; }
        //

        public IdentityProvider(string identityProviderId, SpidProviderType identityProviderType)
        {
            IdentityProviderId = identityProviderId;
            IdentityProviderType = identityProviderType;
            Settings = new Dictionary<string, string>();
        }
    }
}
