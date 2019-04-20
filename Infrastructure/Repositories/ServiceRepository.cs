using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ServiceRepository : BaseRepository
    {
        public IEnumerable<Service> Get() => Db
            .Services
            .ToList();

        public Service Find(Guid id) => Db
            .Services
            .Include(s => s.Id)
            .Where(s => s.Id == id)
            .FirstOrDefault();

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
