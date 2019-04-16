using APIPRojeto.Models;
using APIPRojeto.Repositorires.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires
{
    public class ServiceRepository
    {
        private readonly LataVelhaContext _db;
        public ServiceRepository()
        {
            _db = new LataVelhaContext();

        }
        public IEnumerable<Service> Get() => _db.Service.ToList();


        public Service Find(Guid id) => _db.Service.Where(x => x.Id == id).FirstOrDefault();


        public void Insert(Service service)
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

