using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyLSB;
using MyLSB.Controllers;
using MyLSB.FormBuilder.FormBuilderCustomizations;
using System.IO;
using System.Net;
using System.Net.Http;

namespace MyLSB
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;

            FormBuilderFilters.FormComponents.Add(new FormComponentsFilter());
            FormBuilderStaticMarkupConfiguration.SetGlobalRenderingConfigurations();
            FormWidgetMarkupInjection.RegisterEventHandlers();
            FormFieldMarkupInjection.RegisterEventHandlers();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<Healthchecks.OverrideHealthCheck>("override_health_check");

            // Enable desired Kentico Xperience features
            var kenticoServiceCollection = services.AddKentico(features =>
            {
                features.UsePageBuilder();
                // features.UseActivityTracking();
                // features.UseABTesting();
                // features.UseWebAnalytics();
                // features.UseEmailTracking();
                // features.UseCampaignLogger();
                // features.UseScheduler();
                features.UsePageRouting(new PageRoutingOptions
                {
                    EnableAlternativeUrls = true
                });
            });

            // By default, Xperience sends cookies using SameSite=Lax. If the administration and live site applications
            // are hosted on separate domains, this ensures cookies are set with SameSite=None and Secure. The configuration
            // only applies when communicating with the Xperience administration via preview links. Both applications also need 
            // to use a secure connection (HTTPS) to ensure cookies are not rejected by the client.
            kenticoServiceCollection.SetAdminCookiesSameSiteNone();

            if (Environment.IsDevelopment())
            {
                // By default, Xperience requires a secure connection (HTTPS) if administration and live site applications
                // are hosted on separate domains. This configuration simplifies the initial setup of the development
                // or evaluation environment without a the need for secure connection. The system ignores authentication
                // cookies and this information is taken from the URL.
                kenticoServiceCollection.DisableVirtualContextSecurityForLocalhost();
            }

            services.AddAuthentication();
            // services.AddAuthorization();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddMyLSBServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStatusCodePagesWithReExecute("/Page-Not-Found", "?code={0}");

            // standard static files
            app.UseStaticFiles();

            // custom static files mappings
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".webmanifest"] = "application/manifest+json";
            app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });

            var iisUrlRewriteXml = "IISUrlRewrite.xml";
            if (File.Exists(iisUrlRewriteXml))
            {
                using (StreamReader iisUrlRewriteStreamReader = File.OpenText(iisUrlRewriteXml))
                {
                    var options = new RewriteOptions().AddIISUrlRewrite(iisUrlRewriteStreamReader);
                    app.UseRewriter(options);
                }
            }

            app.UseKentico();

            app.UseCookiePolicy();

            app.UseCors();

            app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthcheck");

                // route to render the sitemap at /sitemap.xml in support of XmlSitemapController.cs
                endpoints.MapControllerRoute(
                    name: "XmlSitemap",
                    pattern: "sitemap.xml",
                    defaults: new { controller = "XmlSitemap", action = "Index" }
                );

                //route constraint: determines if the request matches the NodeAliasPath of a custom.PageGroup
                endpoints.MapControllerRoute(
                    name: "PageGroup",
                    pattern: "{*path}",
                    defaults: new { controller = "CustomRoutes", action = "PageGroup" },
                    new { id = new PageGroupConstraint() }
                );

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller}/{action}"
                );

                endpoints.Kentico().MapRoutes();

                // if Kentico's routing to pages misses the request, check to see if the request exists in the URLRedirection Module
                endpoints.MapControllerRoute(
                    name: "Redirect",
                    pattern: "{*path}",
                    defaults: new { controller = "CustomRoutes", action = "Redirect" },
                    new { id = new RedirectConstraint() }
                );
            });
        }
    }
}
