using LawyerWebSite.Business.Concretes;
using LawyerWebSite.Business.CustomLogger;
using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Repositories;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.WebUI.ConfigureServicesCollection;
using LawyerWebSite.WebUI.EmailService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace LawyerWebSite.WebUI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScopedConfiguration();
            services.AddIdentityConfiguration();
            services.AddCookieConfiguration();
            services.AddEmailServiceConfiguration(_configuration);

            services.AddTransient<ICustomLogger, NLogLogger>();

            services.AddDbContext<DataContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeddData(userManager, roleManager).Wait();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area}/{Controller=Home}/{Action=Index}/{id?}"
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}"
                    );
            });
        }
    }
}
