using DotNetCode.AspNetCore.Authentication.Spid;
using DotNetCode.Spid;
using DotNetCode.Spid.Helpers;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SpidExtensions
    {
      

        //public static AuthenticationBuilder AddSpid(this AuthenticationBuilder builder, Action<SpidConfigurationOptions> configureConfigs){
        //    => builder.AddSpid(builder,ServiceProviderHelper.GetFromFileAsync(op);

        public static AuthenticationBuilder AddSpid(this AuthenticationBuilder builder, DotNetCode.Spid.ServiceProvider  serviceProvider)
        {
            

            foreach (var identityProvider in serviceProvider.IdentityProviders)
            {
                Action<SpidOptions> options;

                options = o => o.IdentityProvider= (identityProvider);
                switch (identityProvider.IdentityProviderType)
                {
                    case SpidProviderType.Saml2:
                        builder.AddRemoteScheme<SpidOptions, SpidSamlHandler>(SpidDefaults.AuthenticationScheme + identityProvider.IdentityProviderId, identityProvider.OrganizationDisplayName, options);
                        break;
                    default:
                        throw new NotImplementedException("Identity Provider Type Not Implemented");
                        
                }
            }
            // builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<SpidOptions>, SpidPostConfigureOptions>());
            //return builder.AddRemoteScheme<SpidOptions, SpidHandler>(authenticationScheme, displayName, configureOptions);
            return builder;
        }

    }
}