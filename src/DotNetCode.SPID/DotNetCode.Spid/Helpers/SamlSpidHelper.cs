using DotNetCode.SPID.SAML;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DotNetCode.Spid.Helpers
{

    public static class SamlSpidHelper
    {
        #region "Not Signed Login Request"

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <returns></returns>
        public static string GetSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl)
        {
            return GetSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, new SamlSpidProviderLoginOptions());
        }

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <returns></returns>
        public static string GetSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, ushort assertionConsumerServiceIndex)
        {
            return GetSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, new SamlSpidProviderLoginOptions() { AssertionConsumerServiceIndex = assertionConsumerServiceIndex });
        }

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        public static string GetSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, ushort assertionConsumerServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            return GetSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, new SamlSpidProviderLoginOptions() { AssertionConsumerServiceIndex = assertionConsumerServiceIndex, SpidLevel = spidAuthLevel });
        }

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <returns></returns>
        public static string GetSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex)
        {
            return GetSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, new SamlSpidProviderLoginOptions() { AssertionConsumerServiceIndex = assertionConsumerServiceIndex, AttributeConsumingServiceIndex = attributeConsumingServiceIndex });
        }

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        public static string GetSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            return GetSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, new SamlSpidProviderLoginOptions() { AssertionConsumerServiceIndex = assertionConsumerServiceIndex, AttributeConsumingServiceIndex = attributeConsumingServiceIndex, SpidLevel = spidAuthLevel });
        }

        /// <summary>
        /// Gets the saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static string GetSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, SamlSpidProviderLoginOptions options)
        {
            AuthRequestOptions authRequestOptions = new AuthRequestOptions()
            {
                AssertionConsumerServiceIndex = options.AssertionConsumerServiceIndex,
                AttributeConsumingServiceIndex = options.AttributeConsumingServiceIndex,
                NotBefore = options.NotBefore,
                NotOnOrAfter = options.NotOnOrAfter,
                Version = options.Version
            };
            AuthRequest authRequest = new AuthRequest(requestId, serviceProviderId, identityProviderRequestUrl, (SPIDLevel)options.SpidLevel, authRequestOptions);
            return authRequest.GetAuthRequest();
        }

        #endregion

        #region "Not Signed Logout Request"

        /// <summary>
        /// Gets the saml logout request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="subjectNameId">The subject name identifier.</param>
        /// <returns></returns>
        public static string GetSamlLogoutRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, string sessionId, string subjectNameId)
        {
            return GetSamlLogoutRequest(requestId, serviceProviderId, identityProviderRequestUrl, sessionId, subjectNameId, new SamlSpidProviderLogoutOptions());
        }

        /// <summary>
        /// Gets the saml logout request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="subjectNameId">The subject name identifier.</param>
        /// <param name="logoutLevel">The logout level.</param>
        /// <returns></returns>
        public static string GetSamlLogoutRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, string sessionId, string subjectNameId, SpidLogoutLevel logoutLevel)
        {
            return GetSamlLogoutRequest(requestId, serviceProviderId, identityProviderRequestUrl, sessionId, subjectNameId, new SamlSpidProviderLogoutOptions() { LogoutLevel = logoutLevel });
        }

        /// <summary>
        /// Gets the saml logout request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="subjectNameId">The subject name identifier.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static string GetSamlLogoutRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, string sessionId, string subjectNameId, SamlSpidProviderLogoutOptions options)
        {
            LogoutRequestOptions logoutRequestOptions = new LogoutRequestOptions()
            {
                LogoutLevel = (LogoutLevel)options.LogoutLevel,
                NotOnOrAfter = options.NotOnOrAfter,
                Version = options.Version
            };
            LogoutRequest logoutRequest = new LogoutRequest(requestId, serviceProviderId, identityProviderRequestUrl, sessionId, subjectNameId, logoutRequestOptions);
            return logoutRequest.GetLogoutRequest();

        }
        #endregion



        #region "Signed Login Request"

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="certificate">The certificate.</param>
        /// <returns></returns>
        public static string GetSignedSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, X509Certificate2 certificate)
        {
            return GetSignedSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, certificate, new SamlSpidProviderLoginOptions());
        }

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <returns></returns>
        public static string GetSignedSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, X509Certificate2 certificate, ushort assertionConsumerServiceIndex)
        {
            return GetSignedSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, certificate, new SamlSpidProviderLoginOptions() { AssertionConsumerServiceIndex = assertionConsumerServiceIndex });
        }

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        public static string GetSignedSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, X509Certificate2 certificate, ushort assertionConsumerServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            return GetSignedSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, certificate, new SamlSpidProviderLoginOptions() { AssertionConsumerServiceIndex = assertionConsumerServiceIndex, SpidLevel = spidAuthLevel });
        }

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <returns></returns>
        public static string GetSignedSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, X509Certificate2 certificate, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex)
        {
            return GetSignedSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, certificate, new SamlSpidProviderLoginOptions() { AssertionConsumerServiceIndex = assertionConsumerServiceIndex, AttributeConsumingServiceIndex = attributeConsumingServiceIndex });
        }

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="assertionConsumerServiceIndex">Index of the assertion consumer service.</param>
        /// <param name="attributeConsumingServiceIndex">Index of the attribute consuming service.</param>
        /// <param name="spidAuthLevel">The spid authentication level.</param>
        /// <returns></returns>
        public static string GetSignedSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, X509Certificate2 certificate, ushort assertionConsumerServiceIndex, ushort attributeConsumingServiceIndex, SpidAuthLevel spidAuthLevel)
        {
            return GetSignedSamlLoginRequest(requestId, serviceProviderId, identityProviderRequestUrl, certificate, new SamlSpidProviderLoginOptions() { AssertionConsumerServiceIndex = assertionConsumerServiceIndex, AttributeConsumingServiceIndex = attributeConsumingServiceIndex, SpidLevel = spidAuthLevel });
        }

        /// <summary>
        /// Gets the signed saml login request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static string GetSignedSamlLoginRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, X509Certificate2 certificate, SamlSpidProviderLoginOptions options)
        {
            AuthRequestOptions authRequestOptions = new AuthRequestOptions()
            {
                AssertionConsumerServiceIndex = options.AssertionConsumerServiceIndex,
                AttributeConsumingServiceIndex = options.AttributeConsumingServiceIndex,
                NotBefore = options.NotBefore,
                NotOnOrAfter = options.NotOnOrAfter,
                Version = options.Version
            };
            AuthRequest authRequest = new AuthRequest(requestId, serviceProviderId, identityProviderRequestUrl, (SPIDLevel)options.SpidLevel, authRequestOptions);
            return authRequest.GetSignedAuthRequest(certificate);
        }

        #endregion




        #region "Signed Logout Request"

        /// <summary>
        /// Gets the signed saml logout request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="subjectNameId">The subject name identifier.</param>
        /// <param name="certificate">The certificate.</param>
        /// <returns></returns>
        public static string GetSignedSamlLogoutRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, string sessionId, string subjectNameId, X509Certificate2 certificate)
        {
            return GetSignedSamlLogoutRequest(requestId, serviceProviderId, identityProviderRequestUrl, sessionId, subjectNameId, certificate, new SamlSpidProviderLogoutOptions());
        }

        /// <summary>
        /// Gets the signed saml logout request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="subjectNameId">The subject name identifier.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="logoutLevel">The logout level.</param>
        /// <returns></returns>
        public static string GetSignedSamlLogoutRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, string sessionId, string subjectNameId, X509Certificate2 certificate, SpidLogoutLevel logoutLevel)
        {
            return GetSignedSamlLogoutRequest(requestId, serviceProviderId, identityProviderRequestUrl, sessionId, subjectNameId, certificate, new SamlSpidProviderLogoutOptions() { LogoutLevel = logoutLevel });
        }

        /// <summary>
        /// Gets the signed saml logout request.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="serviceProviderId">The service provider identifier.</param>
        /// <param name="identityProviderRequestUrl">The identity provider request URL.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="subjectNameId">The subject name identifier.</param>
        /// <param name="certificate">The certificate.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static string GetSignedSamlLogoutRequest(string requestId, string serviceProviderId, string identityProviderRequestUrl, string sessionId, string subjectNameId, X509Certificate2 certificate, SamlSpidProviderLogoutOptions options)
        {
            LogoutRequestOptions logoutRequestOptions = new LogoutRequestOptions()
            {
                LogoutLevel = (LogoutLevel)options.LogoutLevel,
                NotOnOrAfter = options.NotOnOrAfter,
                Version = options.Version
            };
            LogoutRequest logoutRequest = new LogoutRequest(requestId, serviceProviderId, identityProviderRequestUrl, sessionId, subjectNameId, logoutRequestOptions);
            return logoutRequest.GetSignedLogoutRequest(certificate);

        }
        #endregion

        public class SamlSpidProviderLoginOptions
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="SamlSpidProviderLoginOptions"/> class.
            /// </summary>
            public SamlSpidProviderLoginOptions()
            {
                //SAML Protocol Default Version
                this.Version = "2.0";

                //Default SPID Level
                this.SpidLevel = SpidAuthLevel.Level1;

                this.NotBefore = new TimeSpan(0, -2, 0);

                this.NotOnOrAfter = new TimeSpan(0, 5, 0);

            }

            /// <summary>
            /// Gets or sets the version.
            /// </summary>
            /// <value>
            /// The version.
            /// </value>
            public string Version { get; set; }


            /// <summary>
            /// Gets or sets the spid level.
            /// </summary>
            /// <value>
            /// The spid level.
            /// </value>
            public SpidAuthLevel SpidLevel { get; set; }

            /// <summary>
            /// Gets or sets the index of the assertion consumer service.
            /// Refer to Service Provider Metadata Index Value On AssertionConsumerService
            /// </summary>
            /// <value>
            /// The index of the assertion consumer service.
            /// </value>
            public ushort AssertionConsumerServiceIndex { get; set; }

            /// <summary>
            /// Gets or sets the index of the attribute consuming service.
            /// </summary>
            /// <value>
            /// The index of the attribute consuming service.
            /// </value>
            public ushort AttributeConsumingServiceIndex { get; set; }

            /// <summary>
            /// Gets or sets the not before.
            /// </summary>
            /// <value>
            /// The not before.
            /// </value>
            public TimeSpan NotBefore { get; set; }

            /// <summary>
            /// Gets or sets the not on or after.
            /// </summary>
            /// <value>
            /// The not on or after.
            /// </value>
            public TimeSpan NotOnOrAfter { get; set; }
        }




        public class SamlSpidProviderLogoutOptions
        {


            public SamlSpidProviderLogoutOptions()
            {
                //SAML Protocol Default Version
                this.Version = "2.0";

                //Default SPID Level
                this.LogoutLevel = SpidLogoutLevel.User;


                this.NotOnOrAfter = new TimeSpan(0, 5, 0);

            }


            /// <summary>
            /// Gets or sets the version.
            /// </summary>
            /// <value>
            /// The version.
            /// </value>
            public string Version { get; set; }


            /// <summary>
            /// Gets or sets the spid level.
            /// </summary>
            /// <value>
            /// The spid level.
            /// </value>
            public SpidLogoutLevel LogoutLevel { get; set; }


            /// <summary>
            /// Gets or sets the not on or after.
            /// </summary>
            /// <value>
            /// The not on or after.
            /// </value>
            public TimeSpan NotOnOrAfter { get; set; }



        }
    }




}
