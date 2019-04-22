using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
{


    public class ServiceRepository : BaseRepository

    {
        private readonly LataVelhaContext Db;

        

        public IEnumerable<Service> Get() => Db
            .Services            
            .ToList();

        public Service Find(Guid id) => Db
            .Services  
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add (Service Services)
        {
            if (Services != null)
            {
                Db.Add(Services);
                Db.SaveChanges();

            }
        }




    }
}
