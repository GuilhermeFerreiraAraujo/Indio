﻿using Indio.DataAccess;
using Indio.DataAccess.Contracts;
using Indio.Models;
using Indio.Services;
using Indio.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Indio
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddTransient<IndioContext, IndioContext>();
            services.AddTransient<IAccountsServices, AccountsServices>();
            services.AddTransient<ICustomersServices, CustomersServices>();
            services.AddTransient<IUsersServices, UsersServices>();
            services.AddTransient<IAccountsDataAccess, AccountsDataAccess>();
            services.AddTransient<ICustomersDataAccess, CustomersDataAccess>();
            services.AddTransient<IUsersDataAccess, UsersDataAccess>();

            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => {
                options.Cookie.Name = "IndioCookie";
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
