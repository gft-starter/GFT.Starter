using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Repository;
using Infrastructure.Configuration;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ServiceRepository : IRepository<Service>
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
            .Include(s => s.Id)
            .FirstOrDefault(s => s.Id == id);

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
