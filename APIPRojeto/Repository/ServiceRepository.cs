using APIPRojeto.Models;
using APIPRojeto.Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repository
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
            .Include(s => s.Id)
            .ToList();

        public Service Find(Guid id) => _db
            .Services
            .Include(s => s.Id)
            .Where(s => s.Id == id)
            .FirstOrDefault();

        public void Add(Service service)
        {
            if(service != null)
            {
                _db.Add(service);
                _db.SaveChanges();
            }
        }

        public Service Remove(Service service)
        {
            if(service != null)
            {
                _db.Remove(service);
                _db.SaveChanges();
            }
            return service;
        }

        public Service Update(Service service)
        {
            if(service != null)
            {
                _db.Update(service);
                _db.SaveChanges();
            }
            return service;
        }
    }
}
