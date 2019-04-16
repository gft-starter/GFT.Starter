using APIPRojeto.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPRojeto.Repository.Configuration
{
    public class LataVelhaContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public LataVelhaContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=PCSOR455;Database=LataVelha;Trusted_Connection=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
