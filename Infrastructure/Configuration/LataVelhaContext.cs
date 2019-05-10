using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public sealed class LataVelhaContext : DbContext
    {
        public LataVelhaContext(DbContextOptions<LataVelhaContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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
