using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid.Oauth
{
    public class OauthSettings
    {
        /// <summary>
        /// The single sign on service URL
        /// </summary>
        public const string SingleSignOnServiceUrl = "SingleSignOnServiceUrl";

        /// <summary>
        /// The single logout service URL
        /// </summary>
        public const string SingleLogoutServiceUrl = "SingleLogoutServiceUrl";

        /// <summary>
        /// Gets the default settings.
        /// </summary>
        /// <value>
        /// The default settings.
        /// </value>
        public static Dictionary<string, string> DefaultSettings
        {
            get
            {
                return new Dictionary<string, string>(){
                    { SingleSignOnServiceUrl,string.Empty },
                    { SingleLogoutServiceUrl,string.Empty }
                };
            }
        }
    }
}
