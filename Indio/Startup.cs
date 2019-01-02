using Indio.DataAccess;
using Indio.DataAccess.Contracts;
using Indio.Models;
using Indio.Models._2FactAuth;
using Indio.Services;
using Indio.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Indio
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
            services.AddOptions();
            services.AddCors();
            services.AddTransient<IndioContext, IndioContext>();
            services.AddTransient<IAccountsServices, AccountsServices>();
            services.AddTransient<ICustomersServices, CustomersServices>();
            services.AddTransient<IUsersServices, UsersServices>();
            services.AddTransient<IAccountsDataAccess, AccountsDataAccess>();
            services.AddTransient<ICustomersDataAccess, CustomersDataAccess>();
            services.AddTransient<IUsersDataAccess, UsersDataAccess>();
            services.AddTransient<ISmsService, SmsService>();

            var section = _configuration.GetSection("SMSOptions");


            services.Configure<SMSOptions>(section);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => {
                options.Cookie.Name = "IndioCookie";
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
               builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin()
               .AllowCredentials()
               );

            app.UseCors("AllowAll");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}
