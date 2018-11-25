using Indio.Models;
using Indio.Services;
using Indio.Services.Contracts;
using Microsoft.AspNetCore.Builder;
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
            var connection = @"Data Source=DESKTOP-7H9S4CS\\SQLEXPRESS;Initial Catalog=Indio;Integrated Security=True";
            services.AddDbContext<IndioContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IAccountsServices, AccountsServices>();
            services.AddTransient<ICustomersServices, CustomersServices>();
            services.AddTransient<IUsersServices, UsersServices>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
