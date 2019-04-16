using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires.Configuration
{
    public class LataVelhaContext : DbContext 
    {
        public LataVelhaContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"localhost\\SQLEXPRESS;Database=LataVelha;Trusted_Connection=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
