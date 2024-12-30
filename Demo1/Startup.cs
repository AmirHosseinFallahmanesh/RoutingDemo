using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "r1",
                    pattern: "/priv",
                    defaults: new { controller = "home", action = "privacy" }
                    );

                endpoints.MapControllerRoute(
                 name: "r2",
                 pattern: "/login",
                 defaults: new { controller = "account", action = "index" }
                 );

                endpoints.MapControllerRoute(
             name: "r3",
             pattern: "/blogs/{year}/{month}/{day}",
             defaults: new { controller = "blog", action = "index" },
             constraints:new {year=@"^\d{4}$",month=@"^[a-z]{3}$",day=@"^\d{2}$"}
             );

                endpoints.MapControllerRoute(
               name: "r3",
               pattern: "/user/info/{id}",
               defaults: new { controller = "account", action = "getuserinfo" }
               );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
//middleware