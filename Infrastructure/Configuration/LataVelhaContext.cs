using GFT.Starter.Core.Models;
using GFT.Starter.Core.Settings;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Configuration
{
    public sealed class LataVelhaContext : DbContext
    {
        private readonly AppSettings _settings;

        public LataVelhaContext(AppSettings settings)
        {
            _settings = settings;
        }
        public LataVelhaContext() { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _settings.Database.ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>();
            builder.Entity<Owner>();
            builder.Entity<Service>();
            builder.Entity<ServiceOrder>();
        }
    }
}
