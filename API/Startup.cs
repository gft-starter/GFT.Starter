using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Configuration;
using GFT.Starter.Infrastructure.Repositories;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using GFT.Starter.Infrastructure.ServiceBus;
using GFT.Starter.Infrastructure.ServiceBus.IoC;
using GFT.Starter.Infrastructure.Services;
using GFT.Starter.Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace GFT.Starter.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IReadOnlyRepository<Car>, CarRepository>();
            services.AddScoped<IWriteRepository<Car>, CarRepository>();
            services.AddScoped<IReadOnlyRepository<Motorcycle>, MotorcycleRepository>();
            services.AddScoped<IWriteRepository<Motorcycle>, MotorcycleRepository>();
            services.AddScoped<IReadOnlyRepository<Owner>, OwnerRepository>();
            services.AddScoped<IWriteRepository<Owner>, OwnerRepository>();
            services.AddScoped<IReadOnlyRepository<Service>, ServiceRepository>();
            services.AddScoped<IWriteRepository<Service>, ServiceRepository>();
            services.AddScoped<IReadOnlyRepository<ServiceOrder>, ServiceOrderRepository>();
            services.AddScoped<IWriteRepository<ServiceOrder>, ServiceOrderRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IServiceOrderCalculator, ServiceOrderCalculator>();
            services.AddScoped<IUpgradePartsService, UpgradePartsService>();
            services.AddDbContext<LataVelhaContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.ConfigureServiceBus(new ServiceBusSettings(
                Configuration["ServiceBus:DefaultConnection"], Configuration["ServiceBus:QueueName"],
                Configuration["ServiceBus:TopicName"], Configuration["ServiceBus:SubscriptionName"]));
            ConfigureSwagger(services);
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

            ConfigureSwaggerUi(app);
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "GFT Starter Workshop", Version = "v1" });
            });
        }

        private static void ConfigureSwaggerUi(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GFT Starter Workshop V1");
            });
        }
    }
}
