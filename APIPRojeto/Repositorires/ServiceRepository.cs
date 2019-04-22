using APIPRojeto.Models;
using APIPRojeto.Repositorires.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires
{
    public class ServiceRepository : BaseRepository
    {
        public IEnumerable<Service> Get() => Db.Service.ToList();


        public Service Find(Guid id) => Db.Service.FirstOrDefault(x => x.Id == id);


        public void Insert(Service service)
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

