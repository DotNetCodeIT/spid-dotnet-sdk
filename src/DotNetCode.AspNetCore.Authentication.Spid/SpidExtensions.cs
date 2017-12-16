using DotNetCode.AspNetCore.Authentication.Spid;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SpidExtensions
    {
        public static AuthenticationBuilder AddSpid(this AuthenticationBuilder builder)
           => builder.AddSpid(SpidDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddSpid(this AuthenticationBuilder builder, Action<SpidOptions> configureOptions)
            => builder.AddSpid(SpidDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddSpid(this AuthenticationBuilder builder, string authenticationScheme, Action<SpidOptions> configureOptions)
            => builder.AddSpid(authenticationScheme, SpidDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddSpid(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<SpidOptions> configureOptions)
        {
           
            // builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<SpidOptions>, SpidPostConfigureOptions>());
            return builder.AddRemoteScheme<SpidOptions, SpidHandler>(authenticationScheme, displayName, configureOptions);
        }

    }
}