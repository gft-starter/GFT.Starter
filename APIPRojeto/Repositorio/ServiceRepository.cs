using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
{


    public class ServiceRepository
        
    {
        private readonly LataVelhaContext _db;

        public ServiceRepository()
        {
            _db = new LataVelhaContext();
        }

        public IEnumerable<Service> Get() => _db
            .Services            
            .ToList();

        public Service Find(Guid id) => _db
            .Services  
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add (Service Services)
        {
            if (Services != null)
            {
                _db.Add(Services);
                _db.SaveChanges();

            }
        }




    }
}
