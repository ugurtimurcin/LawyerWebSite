using LawyerWebSite.Business.Concretes;
using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Context;
using LawyerWebSite.DataAccess.Concretes.EntityFrameworkCore.Repositories;
using LawyerWebSite.DataAccess.Interfaces;
using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.Entities.Concretes.Entities;
using LawyerWebSite.WebUI.CustomValidator;
using LawyerWebSite.WebUI.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.ConfigureServicesCollection
{
    public static class ScopeExtension
    {
        public static void AddScopedConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IWorkAreaService, WorkAreaManager>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IArticleDal, EfArticleRepository>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<IWorkAreaDal, EfWorkAreaRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
        }

        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
            }).AddErrorDescriber<PasswordValidationToTurkish>().AddEntityFrameworkStores<DataContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
        }

        public static void AddCookieConfiguration(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "Web.Security.Cookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(15);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Dashboard/Index";
                opt.AccessDeniedPath = "/Home/Index";
            });
        }

        public static void AddEmailServiceConfiguration(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddScoped<IEmailReceiver, SmtpEmailReceiver>(a =>
            new SmtpEmailReceiver(
                    _configuration["EmailReceiver:Host"],
                    _configuration.GetValue<int>("EmailReceiver:Port"),
                    _configuration.GetValue<bool>("EmailReceiver:EnableSSL"),
                    _configuration["EmailReceiver:To"],
                    _configuration["EmailReceiver:Password"]));

            services.AddScoped<IEmailSender, SmtpEmailSender>(a =>
           new SmtpEmailSender(
                   _configuration["EmailSender:Host"],
                   _configuration.GetValue<int>("EmailSender:Port"),
                   _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                   _configuration["EmailSender:From"],
                   _configuration["EmailSender:Password"]));
        }
    }
}
