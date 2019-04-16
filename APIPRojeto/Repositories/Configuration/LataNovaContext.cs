using APIPRojeto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositories.Configuration
{
    public class LataNovaContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Service> Services { get; set; }

        public LataNovaContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=BRPC003931\SQLEXPRESS150;Database=LataNova;Trusted_Connection=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
            
        }
    }
}
