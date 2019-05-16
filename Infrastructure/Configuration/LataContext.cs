using GFT.Starter.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GFT.Starter.Infrastructure.Configuration
{
    public sealed class LataContext : DbContext
    {
        public LataContext(DbContextOptions<LataContext> options) : base(options) { }

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
