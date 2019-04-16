using APIPRojeto.Models;
using APIPRojeto.Repositories.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositories
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
            .Where(s => s.Id == id)
            .FirstOrDefault();

        public void Add(Service service)
        {
            if (service != null)
            {
                _db.Add(service);
                _db.SaveChanges();
            }
        }

        public Service Remove(Service service)
        {
            if (service != null)
            {
                _db.Remove(service);
                _db.SaveChanges();
            }

            return service;
        }

        public Service Update(Service service)
        {
            if (service != null)
            {
                _db.Update(service);
                _db.SaveChanges();
            }

            return service;
        }
    }
}
