using APIPRojeto.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPRojeto.Repository.Configuration
{
    public sealed class LataVelhaContext : DbContext
    {
        public LataVelhaContext() { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=BRPC003891\SQLEXPRESS;Database=LataVelha;Trusted_Connection=True";
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
