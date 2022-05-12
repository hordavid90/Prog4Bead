using BikeShop.Data;
using BikeShop.Endpoint.Services;
using BikeShop.Logic;
using BikeShop.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeShop.Endpoint
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
            //services.AddTransient<BikeDbContext>();
            services.AddScoped<DbContext, BikeDbContext>();

            services.AddTransient<IBikeRepository, BikeRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IFacebookGroupRepository, FacebookGroupRepository>();
            services.AddTransient<IOwnerFacebookGroupRepository, OwnerFacebookGroupRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IServiceReporitory, ServiceRepository>();

            services.AddTransient<IRepository<Bike>, BikeRepository>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();
            services.AddTransient<IRepository<FacebookGroup>, FacebookGroupRepository>();
            services.AddTransient<IRepository<OwnerFBGroup>, OwnerFacebookGroupRepository>();
            services.AddTransient<IRepository<Owner>, OwnerRepository>();
            services.AddTransient<IRepository<Service>, ServiceRepository>();

            services.AddTransient<IBikeLogic, BikeLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IFacebookGroupLogic, FacebookGroupLogic>();
            services.AddTransient<IOwnerLogic, OwnerLogic>();
            services.AddTransient<IServiceLogic, ServiceLogic>();
            services.AddTransient<IOwnerLogic, OwnerLogic>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BikeShop.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BikeShop.Endpoint v1"));
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:13099"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
