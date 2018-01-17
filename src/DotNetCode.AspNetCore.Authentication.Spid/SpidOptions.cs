using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using DotNetCode.Spid;

namespace DotNetCode.AspNetCore.Authentication.Spid
{
    public class SpidOptions : RemoteAuthenticationOptions
    {
        private const string DefaultStateCookieName = "__SpidState";

        private CookieBuilder _stateCookieBuilder;


        public SpidOptions()
        {
            CallbackPath = new PathString("/signin-spid");
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            //Events = new TwitterEvents();

            //  ClaimActions.MapJsonKey(ClaimTypes.Email, "email", ClaimValueTypes.Email);

            _stateCookieBuilder = new SpidCookieBuilder(this)
            {
                Name = DefaultStateCookieName,
                SecurePolicy = CookieSecurePolicy.SameAsRequest,
                HttpOnly = true,
                SameSite = SameSiteMode.Lax,
            };
        }

        /// <summary>
        /// Gets or sets the service provider identifier.
        /// </summary>
        /// <value>
        /// The service provider identifier.
        /// </value>
        public string ServiceProviderId{ get; set; }

        /// <summary>
        /// Gets or sets the identity provider.
        /// </summary>
        /// <value>
        /// The identity provider.
        /// </value>
        public IIdentityProvider IdentityProvider { get; set; }


        /// <summary>
        /// Determines the settings used to create the state cookie before the
        /// cookie gets added to the response.
        /// </summary>
        public CookieBuilder StateCookie
        {
            get => _stateCookieBuilder;
            set => _stateCookieBuilder = value ?? throw new ArgumentNullException(nameof(value));
        }

        private class SpidCookieBuilder : CookieBuilder
        {
            private readonly SpidOptions _spidOptions;

            public SpidCookieBuilder(SpidOptions spidOptions)
            {
                _spidOptions = spidOptions;
            }

            public override CookieOptions Build(HttpContext context, DateTimeOffset expiresFrom)
            {
                var options = base.Build(context, expiresFrom);
                if (!Expiration.HasValue)
                {
                    options.Expires = expiresFrom.Add(_spidOptions.RemoteAuthenticationTimeout);
                }
                return options;
            }
        }
    }
}