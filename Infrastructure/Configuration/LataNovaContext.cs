using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public sealed class LataNovaContext : DbContext
    {
        public LataNovaContext(DbContextOptions<LataNovaContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var connectionString = @"Server=BRPC003931\SQLEXPRESS150;Database=LataNova;Trusted_Connection=True";
                var connectionString = @"Server=tcp:latanova150.database.windows.net,1433;Initial Catalog=LataNova;Persist Security Info=False;User ID=arielzao150;Password=P@$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("API"));
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Owner>();
            builder.Entity<Vehicle>();
            builder.Entity<Service>();
            builder.Entity<ServiceOrder>();
        }
    }
}
