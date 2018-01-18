using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using DotNetCode.Spid;

using Microsoft.Extensions.Configuration;
using DotNetCode.Spid.SAML;
using DotNetCode.Spid.Helpers;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DotNetCode.AspNetCore.Authentication.Spid
{
    public class SpidSamlHandler : RemoteAuthenticationHandler<SpidOptions>
    {
        private const string UriSchemeDelimiter = "://";

        private const string InputTagFormat = @"<input type=""hidden"" name=""{0}"" value=""{1}"" />";
        private const string HtmlFormFormat = @"<!doctype html>
<html>
<head>
    <title>Please wait while you're being redirected to the identity provider</title>
</head>
<body>
    <form name=""form"" method=""post"" action=""{0}"">
        {1}
        <noscript>Click here to finish the process: <input type=""submit"" /></noscript>
    </form>
    <script>document.form.submit();</script>
</body>
</html>";

        protected HtmlEncoder HtmlEncoder { get; }
        protected IHostingEnvironment HostingEnvironment { get; }

        public SpidSamlHandler(IOptionsMonitor<SpidOptions> options, IHostingEnvironment hostingEnvironment, ILoggerFactory logger, HtmlEncoder htmlEncoder, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            HtmlEncoder = htmlEncoder;
            HostingEnvironment = hostingEnvironment;

        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {

            // order for local RedirectUri
            // 1. challenge.Properties.RedirectUri
            // 2. CurrentUri if RedirectUri is not set)
            if (string.IsNullOrEmpty(properties.RedirectUri))
            {
                properties.RedirectUri = CurrentUri;
            }

            Dictionary<string, string> idpSettings = this.Options.IdentityProvider.Settings;

            X509Certificate2 signinCert = null;
            if (idpSettings.ContainsKey(SamlSettings.CertificateStoreName) && !string.IsNullOrWhiteSpace(idpSettings[SamlSettings.CertificateStoreName]))
            {
                signinCert = DotNetCode.Spid.Helpers.X509Helper.GetCertificateFromStoreByIssuerName(idpSettings[SamlSettings.CertificateStoreName],false);
            }
            else if (idpSettings.ContainsKey(SamlSettings.CertificateFilePath) && !string.IsNullOrWhiteSpace(idpSettings[SamlSettings.CertificateFilePath]))
            {
                string certfile = (Path.GetFullPath(idpSettings[SamlSettings.CertificateFilePath]))?? Path.Combine( HostingEnvironment.ContentRootPath, idpSettings[SamlSettings.CertificateFilePath]);
                string certpwd = (idpSettings.ContainsKey(SamlSettings.CertificateFilePassword)) ? idpSettings[SamlSettings.CertificateFilePassword] : "";

                signinCert = DotNetCode.Spid.Helpers.X509Helper.GetCertificateFromFile(certfile, certpwd);
            }

            //string returnUrl = "/";

            //if (!string.IsNullOrEmpty(HttpContext.Request.Query["redirectUrl"]))
            //{
            //    returnUrl = HttpContext.Request.Query["redirectUrl"];
            //}

            string samlRequest;
            if (signinCert != null)
            {
                samlRequest = SamlSpidHelper.GetSignedSamlLoginRequest(Guid.NewGuid().ToString(),
                    this.Options.ServiceProviderId,
                    idpSettings[SamlSettings.SingleSignOnServiceUrl],
                    signinCert,
                    new SamlSpidHelper.SamlSpidProviderLoginOptions()
                    {
                        AssertionConsumerServiceIndex = Convert.ToUInt16(idpSettings[SamlSettings.AssertionConsumerServiceIndex]),
                        AttributeConsumingServiceIndex = Convert.ToUInt16(idpSettings[SamlSettings.AttributeConsumingServiceIndex])
                    });
            }
            else
            {
                samlRequest = SamlSpidHelper.GetSamlLoginRequest(Guid.NewGuid().ToString(),
                    this.Options.ServiceProviderId,
                    idpSettings[SamlSettings.SingleSignOnServiceUrl],
                    new SamlSpidHelper.SamlSpidProviderLoginOptions()
                    {
                        AssertionConsumerServiceIndex = Convert.ToUInt16(idpSettings[SamlSettings.AssertionConsumerServiceIndex])
                        ,
                        AttributeConsumingServiceIndex = Convert.ToUInt16(idpSettings[SamlSettings.AttributeConsumingServiceIndex])
                        ,


                    });

            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("SAMLRequest", System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(samlRequest)));
            parameters.Add("RelayState", System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(properties.RedirectUri)));


            var inputs = new StringBuilder();


            foreach (var parameter in parameters)
            {
                var name = (parameter.Key);
                var value = (parameter.Value);

                var input = string.Format(CultureInfo.InvariantCulture, InputTagFormat, name, value);
                inputs.AppendLine(input);
            }



            var content = string.Format(CultureInfo.InvariantCulture, HtmlFormFormat, idpSettings[SamlSettings.SingleSignOnServiceUrl], inputs);
            var buffer = Encoding.UTF8.GetBytes(content);

            Response.ContentLength = buffer.Length;
            Response.ContentType = "text/html;charset=UTF-8";

            // Emit Cache-Control=no-cache to prevent client caching.
            Response.Headers[HeaderNames.CacheControl] = "no-cache";
            Response.Headers[HeaderNames.Pragma] = "no-cache";
            Response.Headers[HeaderNames.Expires] = "-1";

            await Response.Body.WriteAsync(buffer, 0, buffer.Length);
            return;
        }


        protected override Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
