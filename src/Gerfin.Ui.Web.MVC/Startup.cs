using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFin.ApplicationCore.AutoMapper;
using GerFin.ApplicationCore.Entity;
using GerFin.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gerfin.Ui.Web.MVC
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
            services.AddDbContext<GerFinContext>(cfg => cfg.UseSqlServer(Configuration.GetConnectionString("GerFinConn")));

            ContainerIoC.Registrar(services);

            services.AddSingleton(AutoMapperHelper.CreateMapper());

            services.AddRazorPages()
                .AddViewOptions(opt =>
                {
                    opt.HtmlHelperOptions.ClientValidationEnabled = true;
                });

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
            app.UseStaticFiles(); //Allow show to the user static files, usually located at wwwroot folder

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
