using Core.Models;
using Infrastructure.Services;
using Infrastructure.Repository.Contracts;
using Infrastructure.Services.Contracts;
using Infrastructure.Configuration;
using Infrastructure.SeviceBus;
using Infrastructure.SeviceBus.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repository;

namespace APICar
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
            services.AddScoped<IReadOnlyRepository<Car>, CarRepository>();
            services.AddScoped<IWriteRepository<Car>, CarRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddDbContext<LataVelhaContext>(options => options.UseSqlServer(Configuration["App:Database:ConnectionString"]));
            services.ConfigureServiceBus(new ServiceBusSettings(
                Configuration["ServiceBus:DefaultConnection"], Configuration["ServiceBus:QueueName"],
                Configuration["ServiceBus:TopicName"], Configuration["ServiceBus:SubscriptionName"]));
            
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

           
        }

    }
}