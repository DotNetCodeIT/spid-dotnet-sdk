using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPID_ASPNET_CORE_2_0_Identity.Data;
using SPID_ASPNET_CORE_2_0_Identity.Models;
using SPID_ASPNET_CORE_2_0_Identity.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace SPID_ASPNET_CORE_2_0_Identity
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            string spidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            services.AddAuthentication(defaultScheme: spidScheme).AddSpid(new DotNetCode.Spid.ServiceProvider()
            {
                //ServiceProviderId = "https://spidtest.developers.italia.it",
                //ServiceProviderId = "https://www.dotnetcode.it",
                ServiceProviderId = "https://spid.dotnetcode.it",
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
                               {   "CertificateStoreName","dotnetcode"},
                               // {   "CertificateStoreName","DevelopersItalia"},
                              //{ "CertificateFilePath", "cert/certificate.pfx" },
                              //{ "CertificateFilePassword", "P@ssw0rd!" },
                            { "SingleSignOnServiceUrl", "https://spidposte.test.poste.it/jod-fs/ssoservicepost" },
                            { "SingleLogoutServiceUrl", "https://spidposte.test.poste.it/jod-fs/sloservicepost" }
                          }
                      },
                       new DotNetCode.Spid.IdentityProvider("LocalTest", DotNetCode.Spid.SpidProviderType.Saml2){
                          OrganizationName= "Local IDP DI TEST",
                          OrganizationDisplayName= "Local IDP DI TEST",
                          OrganizationUrl= "https://spid-testenv-identityserver",
                          OrganizationLogoUrl= "https://raw.githubusercontent.com/italia/spid-graphics/master/idp-logos/spid-idp-posteid.png",
                            Settings= new Dictionary<string, string>() {
                              {"AssertionConsumerServiceIndex", "1" },
                              { "AttributeConsumingServiceIndex", "1" },
                               {   "CertificateStoreName","DotNetCode"},
                               // {   "CertificateStoreName","DevelopersItalia"},
                              //{ "CertificateFilePath", "cert/certificate.pfx" },
                              //{ "CertificateFilePassword", "P@ssw0rd!" },
                            { "SingleSignOnServiceUrl", "https://spid-testenv-identityserver:9443/samlsso" },
                            { "SingleLogoutServiceUrl", "https://spid-testenv-identityserver:9443/samlsso" }
                          }
                      }
                }
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
