using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Repository.Contracts;
using Infrastructure.Configuration;

namespace Infrastructure.Repository
{
    public class ServiceRepository : IReadOnlyRepository<Service>, IWriteRepository<Service>
    {
        private readonly LataVelhaContext _db;

        public ServiceRepository(LataVelhaContext db)
        {
            _db = db;
        }

        public IEnumerable<Service> Get() => _db
            .Services
            .ToList();

        public Service Find(Guid id) => _db
            .Services
            .FirstOrDefault(s => s.Id == id);

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
