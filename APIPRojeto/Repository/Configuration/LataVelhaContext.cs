using APIPRojeto.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPRojeto.Repository.Configuration
{
    public class LataVelhaContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        public LataVelhaContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=tcp:latavelha.database.windows.net,1433;Initial Catalog=LataVelha;Persist Security Info=False;User ID=fdario;Password=Gft@2019@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
