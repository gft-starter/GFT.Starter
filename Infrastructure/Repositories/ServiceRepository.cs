using System;
using System.Collections.Generic;
using System.Linq;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class ServiceRepository : BaseRepository, IReadOnlyRepository<Service>, IWriteRepository<Service>
    {
        public IEnumerable<Service> Get() => Db
            .Services
            .ToList();

        public Service Find(Guid id) => Db
            .Services
            .Include(s => s.Id)
            .FirstOrDefault(s => s.Id == id);

        public void Add(Service service)
        {
            if (service != null)
            {
                Db.Add(service);
                Db.SaveChanges();
            }
        }

        public Service Remove(Service service)
        {
            if (service != null)
            {
                Db.Remove(service);
                Db.SaveChanges();
            }
            return service;
        }

        public Service Update(Service service)
        {
            if (service != null)
            {
                Db.Update(service);
                Db.SaveChanges();
            }
            return service;
        }
    }
}
