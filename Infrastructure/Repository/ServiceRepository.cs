﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class ServiceRepository : BaseRepository
    {
        public IEnumerable<Service> Get() => Db
            .Services
            .ToList();

        public Service Find(Guid id) => Db
            .Services
            .FirstOrDefault(s => s.Id == id);

        public void Add(Service service)
        {
            if(service != null)
            {
                Db.Add(service);
                Db.SaveChanges();
            }
        }

        public Service Remove(Service service)
        {
            if(service != null)
            {
                Db.Remove(service);
                Db.SaveChanges();
            }
            return service;
        }

        public Service Update(Service service)
        {
            if(service != null)
            {
                Db.Update(service);
                Db.SaveChanges();
            }
            return service;
        }
    }
}
