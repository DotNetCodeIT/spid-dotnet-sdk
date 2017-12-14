using DotNetCode.SPID.SAML.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DotNetCode.SPID.SAML
{
    public class LogoutResponse
    {
        public string Version { get; set; }

        public string Issuer { get; set; }

        public string UUID { get; set; }


        public string SPUID { get; set; }

      
        public SamlRequestStatus RequestStatus { get; set; }

     

        public LogoutResponse()
        {
          RequestStatus= SamlRequestStatus.GenericError;
        }

       

        public void Deserialize(string samlResponse)
        {
            ResponseType response = new ResponseType();
            try
            {
                using (TextReader sr = new StringReader(samlResponse))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ResponseType));
                    response = (ResponseType)serializer.Deserialize(sr);

                    this.Version = response.Version;
                    this.UUID = response.ID;
                    this.SPUID = response.InResponseTo;
                    this.Issuer = response.Issuer.Value;

                    switch (response.Status.StatusCode.Value)
                    {
                        case "urn:oasis:names:tc:SAML:2.0:status:Success":
                            this.RequestStatus = SamlRequestStatus.Success;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:Requester":
                            this.RequestStatus = SamlRequestStatus.RequesterError;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:Responder":
                            this.RequestStatus = SamlRequestStatus.ResponderError;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:VersionMismatch":
                            this.RequestStatus = SamlRequestStatus.VersionMismatchError;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:AuthnFailed":
                            this.RequestStatus = SamlRequestStatus.AuthnFailed;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:InvalidAttrNameOrValue":
                            this.RequestStatus = SamlRequestStatus.InvalidAttrNameOrValue;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:InvalidNameIDPolicy":
                            this.RequestStatus = SamlRequestStatus.InvalidNameIDPolicy;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:NoAuthnContext":
                            this.RequestStatus = SamlRequestStatus.NoAuthnContext;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:NoAvailableIDP":
                            this.RequestStatus = SamlRequestStatus.NoAvailableIDP;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:NoPassive":
                            this.RequestStatus = SamlRequestStatus.NoPassive;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:NoSupportedIDP":
                            this.RequestStatus = SamlRequestStatus.NoSupportedIDP;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:PartialLogout":
                            this.RequestStatus = SamlRequestStatus.PartialLogout;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:ProxyCountExceeded":
                            this.RequestStatus = SamlRequestStatus.ProxyCountExceeded;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:RequestDenied":
                            this.RequestStatus = SamlRequestStatus.RequestDenied;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:RequestUnsupported":
                            this.RequestStatus = SamlRequestStatus.RequestUnsupported;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:RequestVersionDeprecated":
                            this.RequestStatus = SamlRequestStatus.RequestVersionDeprecated;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:RequestVersionTooHigh":
                            this.RequestStatus = SamlRequestStatus.RequestVersionTooHigh;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:RequestVersionTooLow":
                            this.RequestStatus = SamlRequestStatus.RequestVersionTooLow;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:ResourceNotRecognized":
                            this.RequestStatus = SamlRequestStatus.ResourceNotRecognized;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:TooManyResponses":
                            this.RequestStatus = SamlRequestStatus.TooManyResponses;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:UnknownAttrProfile":
                            this.RequestStatus = SamlRequestStatus.UnknownAttrProfile;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:UnknownPrincipal":
                            this.RequestStatus = SamlRequestStatus.UnknownPrincipal;
                            break;
                        case "urn:oasis:names:tc:SAML:2.0:status:UnsupportedBinding":
                            this.RequestStatus = SamlRequestStatus.UnsupportedBinding;
                            break;

                        default:
                            this.RequestStatus = SamlRequestStatus.GenericError;
                            break;

                    }

                 
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        
    }
}
