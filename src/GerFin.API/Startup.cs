using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Repositories.Interfaces;
using GerFin.ApplicationCore.Services.Classes;
using GerFin.ApplicationCore.Services.Interfaces;
using GerFin.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GerFin.ApplicationCore.AutoMapper;
using GerFin.IoC;
using Microsoft.OpenApi.Models;

namespace GerFin.API
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

            services.AddSwaggerGen(c => c.SwaggerDoc(name: "v1", new OpenApiInfo() { Title = "GerfinAPI", Version = "v1" }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "GerfinAPI"); });

            //app.UseRouter(router =>
            //{
            //    router.MapRoute
            //})
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
