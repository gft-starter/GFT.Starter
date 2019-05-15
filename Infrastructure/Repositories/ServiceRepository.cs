using Core.Models;
using Infrastructure.Configuration;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ServiceRepository : IReadOnlyRepository<Service>, IWriteRepository<Service>
    {
        private readonly LataNovaContext _db;

        public ServiceRepository(LataNovaContext db)
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
