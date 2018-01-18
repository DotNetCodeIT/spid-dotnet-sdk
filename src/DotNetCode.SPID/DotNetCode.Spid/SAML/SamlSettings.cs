using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCode.Spid.SAML
{
    public class SamlSettings
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
        /// The assertion consumer service index
        /// </summary>
        public const string AssertionConsumerServiceIndex = "AssertionConsumerServiceIndex";

        /// <summary>
        /// The attribute consuming service index
        /// </summary>
        public const string AttributeConsumingServiceIndex = "AttributeConsumingServiceIndex";

        /// <summary>
        /// The certificate store name
        /// </summary>
        public const string CertificateStoreName = "CertificateStoreName";

        /// <summary>
        /// The certificate file name
        /// </summary>
        public const string CertificateFilePath = "CertificateFilePath";

        /// <summary>
        /// The certificate file password
        /// </summary>
        public const string CertificateFilePassword = "CertificateFilePassword";


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
                    { SingleLogoutServiceUrl,string.Empty },
                    { CertificateStoreName,string.Empty },
                    { CertificateFilePath,string.Empty },
                    { CertificateFilePassword,string.Empty },
                    { AssertionConsumerServiceIndex,"0" },
                    { AttributeConsumingServiceIndex,"0" }
                };
            }
        }

    }
}
