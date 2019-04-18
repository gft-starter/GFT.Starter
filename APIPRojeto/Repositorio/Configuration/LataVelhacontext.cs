using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using APIPRojeto.Models;

namespace APIPRojeto.Repositorio.Configuration
{
    public class LataVelhaContext : DbContext
    {
        public DbSet <Car> Cars { get; set; }

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
                var connectionString = @"Server=BRPC003897\SQLEXPRESS; Database=LataVelha; Trusted_Connection=True";
                optionsBuilder.UseSqlServer(connectionString);

            }
           }
 
         
    }
}
