using APIPRojeto.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPRojeto.Repositories.Configuration
{
    public class LataVelhaContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public LataVelhaContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=BRPC003781\SQL;Database=LataVelha;Trusted_Connection=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
