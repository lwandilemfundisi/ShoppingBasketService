using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShoppingBasketService.Domain;
using ShoppingBasketService.Integration.MessageBus;
using ShoppingBasketService.Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasketService.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "enableCors",
                    builder =>
                    {
                        builder
                        .WithOrigins("http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
            services.AddSingleton(_ => Configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddLogging(l => l.AddConsole());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoppingBasketService.Api", Version = "v1" });
            });

            services.AddSingleton<IMessageBus, AzServiceBusMessageBus>();

            services
                .AddControllers()
                .AddNewtonsoftJson();
            services
                .ConfigureShoppingBasketServiceDomain(Configuration)
                .ConfigureShoppingBasketPersistence();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingBasketService.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("enableCors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
