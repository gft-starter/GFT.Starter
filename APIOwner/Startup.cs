﻿using System;
using System.IO;
using Core.Models;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Infrastructure.Repository.Contracts;
using Infrastructure.Services;
using Infrastructure.Services.Contracts;
using Infrastructure.SeviceBus;
using Infrastructure.SeviceBus.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace APIOwner
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IReadOnlyRepository<Owner>, OwnerRepository>();
            services.AddScoped<IWriteRepository<Owner>, OwnerRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddDbContext<LataVelhaContext>(options => options.UseSqlServer(Configuration["App:Database:ConnectionString"]));
            services.ConfigureServiceBus(new ServiceBusSettings(
                Configuration["ServiceBus:DefaultConnection"], Configuration["ServiceBus:QueueName"],
                Configuration["ServiceBus:TopicName"], Configuration["ServiceBus:SubscriptionName"]));

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            services.AddOptions();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "AERA Lata Velha API", Version = "V1" });
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            throw new NotImplementedException();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AERA Owner LataVelha v1");
            });

        }
        
    }
}
