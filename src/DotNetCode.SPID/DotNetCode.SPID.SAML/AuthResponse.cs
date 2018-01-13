using DotNetCode.SPID.SAML.Schema;
using System;
using System.Collections.Generic;
using System.IO;


using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DotNetCode.SPID.SAML
{
    public class AuthResponse
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the issuer.
        /// </summary>
        /// <value>
        /// The issuer.
        /// </value>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the UUID.
        /// </summary>
        /// <value>
        /// The UUID.
        /// </value>
        public string UUID { get; set; }


        /// <summary>
        /// Gets or sets the spuid.
        /// </summary>
        /// <value>
        /// The spuid.
        /// </value>
        public string SPUID { get; set; }

        /// <summary>
        /// Gets or sets the subject name identifier.
        /// </summary>
        /// <value>
        /// The subject name identifier.
        /// </value>
        public string SubjectNameId { get; set; }

        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the session identifier expire date.
        /// </summary>
        /// <value>
        /// The session identifier expire date.
        /// </value>
        public DateTime SessionIdExpireDate { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public SpidUserData User { get; set; }

        /// <summary>
        /// Gets or sets the request status.
        /// </summary>
        /// <value>
        /// The request status.
        /// </value>
        public SamlRequestStatus RequestStatus { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="AuthResponse"/> class.
        /// </summary>
        public AuthResponse()
        {
            User = new SpidUserData();
            RequestStatus= SamlRequestStatus.GenericError;
        }

        /// <summary>
        /// Gets the claims.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetClaims()
        {
            Dictionary<string, string> claims = new Dictionary<string, string>();


            claims.Add("SpidCode", this.User.SpidCode ?? "");

            claims.Add("Name", this.User.Name ?? "");
            claims.Add("FamilyName", this.User.FamilyName ?? "");

            claims.Add("PlaceOfBirth", this.User.PlaceOfBirth ?? "");
            claims.Add("CountyOfBirth", this.User.CountyOfBirth ?? "");
            claims.Add("DateOfBirth", this.User.DateOfBirth ?? "");

            claims.Add("Gender", this.User.Gender ?? "");

            claims.Add("CompanyName", this.User.CompanyName ?? "");
            claims.Add("RegisteredOffice", this.User.RegisteredOffice ?? "");
            claims.Add("FiscalNumber", this.User.FiscalNumber ?? "");
            claims.Add("IvaCode", this.User.IvaCode ?? "");

            claims.Add("IdCard", this.User.IdCard ?? "");
            claims.Add("ExpirationDate", this.User.ExpirationDate ?? "");

            claims.Add("Email", this.User.Email ?? "");
            claims.Add("Address", this.User.Address ?? "");
            claims.Add("DigitalAddress", this.User.DigitalAddress ?? "");
            claims.Add("MobilePhone", this.User.MobilePhone ?? "");

            claims.Add("SessionId", this.SessionId ?? "");
            claims.Add("SessionIdExpireDate", this.SessionIdExpireDate.ToString());
            claims.Add("SubjectNameId", this.SubjectNameId ?? "");

            return claims;

        }


        /// <summary>
        /// Deserializes the specified saml response.
        /// </summary>
        /// <param name="samlResponse">The saml response.</param>
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

                    if (this.RequestStatus == SamlRequestStatus.Success) {

                        foreach (var item in response.Items)
                        {
                            if (item.GetType()==typeof(AssertionType)) {
                                AssertionType ass = (AssertionType)item;
                                this.SessionIdExpireDate = (ass.Conditions.NotOnOrAfter != null) ? ass.Conditions.NotOnOrAfter : DateTime.Now.AddMinutes(20);

                                foreach (var subitem in ass.Subject.Items)
                                {
                                    if (subitem.GetType() == typeof(NameIDType))
                                    {
                                        NameIDType nameId = (NameIDType)subitem;
                                        this.SubjectNameId = nameId.Value; //.Replace("SPID-","");
                                    }
                                }

                                foreach (var assItem in ass.Items)
                                {
                                    if (assItem.GetType() == typeof(AuthnStatementType))
                                    {
                                        AuthnStatementType authnStatement = (AuthnStatementType)assItem;
                                        this.SessionId = authnStatement.SessionIndex;
                                        this.SessionIdExpireDate = (authnStatement.SessionNotOnOrAfterSpecified) ? authnStatement.SessionNotOnOrAfter : this.SessionIdExpireDate;
                                    }

                                    if (assItem.GetType() == typeof(AttributeStatementType))
                                    {
                                        AttributeStatementType statement = (AttributeStatementType)assItem;
                                        
                                        foreach (AttributeType attribute in statement.Items)
                                        {
                                            switch (attribute.Name)
                                            {
                                                case "spidCode":
                                                    this.User.SpidCode = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "name":
                                                    this.User.Name = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "familyName":
                                                    this.User.FamilyName = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "gender":
                                                    this.User.Gender  = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "ivaCode":
                                                    this.User.IvaCode = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "companyName":
                                                    this.User.CompanyName = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "mobilePhone":
                                                    this.User.MobilePhone = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "address":
                                                    this.User.Address = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "fiscalNumber":
                                                    this.User.FiscalNumber = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "dateOfBirth":
                                                    this.User.DateOfBirth = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "placeOfBirth":
                                                    this.User.PlaceOfBirth = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "countyOfBirth":
                                                    this.User.CountyOfBirth = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "idCard":
                                                    this.User.IdCard = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "registeredOffice":
                                                    this.User.RegisteredOffice = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "email":
                                                    this.User.Email = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "expirationDate":
                                                    this.User.ExpirationDate = attribute.AttributeValue[0].ToString();
                                                    break;
                                                case "digitalAddress":
                                                    this.User.DigitalAddress = attribute.AttributeValue[0].ToString();
                                                    break;
                                             
                                                default:
                                                    break;
                                            }
                                        }

                                    }
                                }
                            }
                        }
                      

                    }

                }

            }
            catch (Exception ex)
            {
                //TODO Log
                throw ex;
            }
        }


       
    }
}
