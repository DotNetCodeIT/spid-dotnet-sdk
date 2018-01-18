using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using DotNetCode.Spid.Helpers;

namespace SPID_ASPNET_CORE_2_0_NoIdentity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string spidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            services.AddAuthentication(defaultScheme: spidScheme).AddSpid(new DotNetCode.Spid.ServiceProvider()
            {
                ServiceProviderId = "http:www.dotnetcode.it",
                IdentityProviders = new List<DotNetCode.Spid.IdentityProvider>()
                 {
                      new DotNetCode.Spid.IdentityProvider("PosteTest", DotNetCode.Spid.SpidProviderType.Saml2){
                          OrganizationName= "Poste Italiane SpA IDP DI TEST",
                          OrganizationDisplayName= "Poste Italiane SpA IDP DI TEST",
                          OrganizationUrl= "https://spidposte.test.poste.it",
                          OrganizationLogoUrl= "https://raw.githubusercontent.com/italia/spid-graphics/master/idp-logos/spid-idp-posteid.png",
                            Settings= new Dictionary<string, string>() {
                              {"AssertionConsumerServiceIndex", "1" },
                              { "AttributeConsumingServiceIndex", "1" },
                              { "CertificateFilePath", "cert/www_dotnetcode_it.pfx" },
                              { "CertificateFilePassword", "P@ssw0rd!" },
                            { "SingleSignOnServiceUrl", "https://spidposte.test.poste.it/jod-fs/ssoservicepost" },
                            { "SingleLogoutServiceUrl", "https://spidposte.test.poste.it/jod-fs/sloservicepost" }
                          }
                      }
                }
            })
            .AddCookie(spidScheme, options =>
            {
                options.LoginPath = new PathString("/account/login");
                options.AccessDeniedPath = new PathString("/error?unauth");
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //SPID
            app.UseAuthentication();
            //SPID

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
