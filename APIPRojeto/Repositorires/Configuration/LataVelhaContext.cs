using APIPRojeto.Models;
using Microsoft.EntityFrameworkCore;


namespace APIPRojeto.Repositorires.Configuration
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
                var connectionString = @"Server=tcp:ldbs.database.windows.net,1433;Initial Catalog=LataVelha;Persist Security Info=False;User ID=ldbs;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
