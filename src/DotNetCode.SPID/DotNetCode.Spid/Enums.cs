using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid
{
    /// <summary>
    /// Spid Identity Provider Type
    /// </summary>
    public enum SpidProviderType
    {
        /// <summary>
        /// The saml2
        /// </summary>
        Saml2 = 1,

        /// <summary>
        /// The open identifier
        /// </summary>
        OpenId = 2,

        /// <summary>
        /// The oauth
        /// </summary>
        Oauth = 3
    }
    public enum SpidAuthLevel
    {
        /// <summary>
        /// The level1
        /// </summary>
        Level1 = 1,

        /// <summary>
        /// The level2
        /// </summary>
        Level2 = 2,

        /// <summary>
        /// The level3
        /// </summary>
        Level3 = 3
    }

    /// <summary>
    /// Spid Logout Level
    /// </summary>
    public enum SpidLogoutLevel
    {
        /// <summary>
        /// The admin
        /// </summary>
        Admin = 1,

        /// <summary>
        /// The user
        /// </summary>
        User = 2
    }
}
