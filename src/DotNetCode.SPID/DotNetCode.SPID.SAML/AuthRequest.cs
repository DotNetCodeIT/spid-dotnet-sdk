using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace DotNetCode.Spid.SAML
{
    
    /// <summary>
    /// Auth Request Options
    /// </summary>
    public class AuthRequestOptions
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRequestOptions"/> class.
        /// </summary>
        public AuthRequestOptions()
        {
            //SAML Protocol Default Version
            this.Version = "2.0";
            
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
        /// Gets or sets the not before timespan.
        /// </summary>
        /// <value>
        /// The not before.
        /// </value>
        public TimeSpan NotBefore { get; set; }

        /// <summary>
        /// Gets or sets the not on or after timespan.
        /// </summary>
        /// <value>
        /// The not on or after.
        /// </value>
        public TimeSpan NotOnOrAfter { get; set; }



    }
    /// <summary>
    /// Authorization Request
    /// Refer to spid-regole_tecniche_v1.pdf
    /// 1.2.2.1. AUTHNREQUEST
    /// </summary>
    public class AuthRequest
    {
       
        /// <summary>
        /// Gets or sets the Unique Request ID (GUID).
        /// </summary>
        /// <value>
        /// The UUID.
        /// </value>
        public string UUID { get; set; }

        /// <summary>
        /// Gets or sets the Service Provider Unique ID.
        /// </summary>
        /// <value>
        /// The spuid.
        /// </value>
        public string SPUID { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the spid level.
        /// </summary>
        /// <value>
        /// The spid level.
        /// </value>
        public SPIDLevel SPIDLevel { get; set; }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public AuthRequestOptions Options { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRequest"/> class.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <param name="spuid">The spuid.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="spidLevel">The spid level.</param>
        public AuthRequest(string uuid, string spuid, string destination, SPIDLevel spidLevel)
        {
            this.UUID = uuid;
            this.SPUID = spuid;
            this.Destination = destination;
            this.SPIDLevel = spidLevel;
            this.Options = new AuthRequestOptions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRequest"/> class.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <param name="spuid">The spuid.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="spidLevel">The spid level.</param>
        /// <param name="options">The options.</param>
        public AuthRequest(string uuid, string spuid, string destination, SPIDLevel spidLevel, AuthRequestOptions options)
        {
            this.UUID = uuid;
            this.SPUID = spuid;
            this.Destination = destination;
            this.SPIDLevel = spidLevel;
            this.Options = options;
        }

        /// <summary>
        /// Gets the authentication request.
        /// </summary>
        /// <returns></returns>
        public string GetAuthRequest()
        {
            //Check SSO Destination URL
            if (string.IsNullOrEmpty(this.Destination)) throw new ArgumentNullException("Destination", "Destination cannot be null or empty");

            string result = "";

            DateTime requestDatTime = DateTime.UtcNow;

            //New AuthnRequestType
            AuthnRequestType request = new AuthnRequestType
            {

                //Unique UUID
                ID = "_" + this.UUID,

                //SAML VERSION Default 2.0
                Version = Options.Version,

                //Request DateTime
                IssueInstant = requestDatTime
            };

            //Request Force Authn
            if ((int)SPIDLevel > 1)
            {
                request.ForceAuthn = true;
                request.ForceAuthnSpecified = true;
            }
            else
            {
                request.ForceAuthn = false;
                request.ForceAuthnSpecified = true;
            }

            //SSO (Single Sign On) Destination URI
            request.Destination = this.Destination;

            //Service Provider Assertion Consumer Service Index
            request.AssertionConsumerServiceIndex = this.Options.AssertionConsumerServiceIndex;
            request.AssertionConsumerServiceIndexSpecified = true;

            //Service Provider Attribute Consumer Service Index
            request.AttributeConsumingServiceIndex = this.Options.AttributeConsumingServiceIndex;
            request.AttributeConsumingServiceIndexSpecified = true;

            //Issuer Data
            request.Issuer = new NameIDType()
            {
                Format = "urn:oasis:names:tc:SAML:2.0:nameid-format:entity",
                Value = this.SPUID,
                NameQualifier = this.SPUID
            };

            //NameId Policy
            request.NameIDPolicy = new NameIDPolicyType()
            {
                Format = "urn:oasis:names:tc:SAML:2.0:nameid-format:transient",
                AllowCreate = true
            };

            //NotRequired
            request.Conditions = new ConditionsType()
            {
                NotBefore = requestDatTime.Add(this.Options.NotBefore),
                NotBeforeSpecified = true,
                NotOnOrAfter = requestDatTime.Add(this.Options.NotOnOrAfter),
                NotOnOrAfterSpecified = true
            };

            //Request Authn Context
            request.RequestedAuthnContext = new RequestedAuthnContextType
            {
                Comparison = AuthnContextComparisonType.minimum,
                ComparisonSpecified = true,
                ItemsElementName = new ItemsChoiceType7[] { ItemsChoiceType7.AuthnContextClassRef },
                Items = new string[] { "https://www.spid.gov.it/SpidL" + ((int)this.SPIDLevel).ToString() }
            };

            string samlRequest = "";
            try
            {
                XmlSerializer serializer = new XmlSerializer(request.GetType());

                using (StringWriter stringWriter = new StringWriter())
                {
                    XmlWriterSettings settings = new XmlWriterSettings()
                    {
                        OmitXmlDeclaration = true,
                        Indent = true,
                        Encoding = Encoding.UTF8
                    };

                    using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
                    {
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("saml2p", "urn:oasis:names:tc:SAML:2.0:protocol");

                        serializer.Serialize(writer, request, namespaces);

                        samlRequest = stringWriter.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO log
                throw ex;
            }

            result = samlRequest;


            return result;

        }

        /// <summary>
        /// Gets the signed authentication request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <returns></returns>
        public string GetSignedAuthRequest(X509Certificate2 cert)
        {
            var xmlPrivateKey = "";

#if NETFULL
           xmlPrivateKey = cert.PrivateKey.ToXmlString(true);
#endif

#if NETSTANDARD2_0
            xmlPrivateKey = RSAKeyExtensions.ToXmlString((RSA)cert.PrivateKey, true);
#endif
            return GetSignedAuthRequest(cert, xmlPrivateKey);
        }


        /// <summary>
        /// Gets the signed authentication request.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <param name="privateKey">The private key.</param>
        /// <returns></returns>
        public string GetSignedAuthRequest(X509Certificate2 cert, string xmlPrivateKey)
        {

            string result = GetAuthRequest();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);

            XmlElement signature = SignHelper.SignXmlDocument(doc, cert, xmlPrivateKey);

            doc.DocumentElement.InsertAfter(signature, doc.DocumentElement.ChildNodes[0]);

            result = doc.OuterXml;


            return result;
        }


        /// <summary>
        /// Signs the authentication request.
        /// </summary>
        /// <param name="authrequest">The authrequest.</param>
        /// <param name="cert">The cert.</param>
        /// <returns></returns>
        public string SignAuthRequest(string authrequest, X509Certificate2 cert)
        {
            var xmlPrivateKey = "";
#if NETFULL
           xmlPrivateKey = cert.PrivateKey.ToXmlString(true);
#endif

#if NETSTANDARD2_0
            xmlPrivateKey = RSAKeyExtensions.ToXmlString((RSA)cert.PrivateKey, true);
#endif

            return SignAuthRequest(authrequest, cert, xmlPrivateKey);
        }


        /// <summary>
        /// Signs the authentication request.
        /// </summary>
        /// <param name="authrequest">The authrequest.</param>
        /// <param name="cert">The cert.</param>
        /// <param name="xmlPrivateKey">The XML private key.</param>
        /// <returns></returns>
        public string SignAuthRequest(string authrequest, X509Certificate2 cert, string xmlPrivateKey)
        {

            string result = authrequest;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);

            XmlElement signature = SignHelper.SignXmlDocument(doc, cert, xmlPrivateKey);

            doc.DocumentElement.InsertAfter(signature, doc.DocumentElement.ChildNodes[0]);

            string responseStr = doc.OuterXml;


            return result;
        }



    }
}
