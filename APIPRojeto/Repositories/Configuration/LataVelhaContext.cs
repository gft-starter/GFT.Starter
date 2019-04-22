using APIPRojeto.Models;
using Microsoft.EntityFrameworkCore;


namespace APIPRojeto.Repositories.Configuration
{
    public class LataVelhaContext : DbContext 
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceOrder> ServiceOrder { get; set; }
        public LataVelhaContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=BRPC003781\SQL;Database=LataVelha;trusted_connection=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
