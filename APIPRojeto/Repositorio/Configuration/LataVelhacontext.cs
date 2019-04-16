using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorio.Configuration
{
    public class LataVelhaContext : Dbcontext
    {
        public LataVelhaContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=BRPC003897; Database=LataVelha; Trusted_Connection=True";
                optionsBuilder.UseSqlServer(connectionString);

            }
        }
         
    }
}
