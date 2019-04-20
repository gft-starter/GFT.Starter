using Core.Models;
using Core.Settings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Configuration
{
    public sealed class LataVelhaContext : DbContext
    {
        private readonly AppSettings _settings;

        public LataVelhaContext(AppSettings settings)
        {
            _settings = settings;
        }
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
    }
}
