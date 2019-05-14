using System;
using System.Collections.Generic;
using System.Linq;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Configuration;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class ServiceRepository : IReadOnlyRepository<Service>, IWriteRepository<Service>
    {
        private readonly LataContext _db;

        public ServiceRepository(LataContext db)
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
