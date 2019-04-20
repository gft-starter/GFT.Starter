using System;
using System.Collections.Generic;
using System.Linq;
using GFT.Starter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class TruckRepository : BaseRepository
    {
        public IEnumerable<Truck> Get() => Db
            .Vehicles.OfType<Truck>()
            .Include(c => c.Owner)
            .ToList();

        public Truck Find(Guid id) => Db
            .Vehicles.OfType<Truck>()
            .Include(c => c.Owner)
            .FirstOrDefault(c => c.Id == id);

        public void Add(Truck truck)
        {
            if (truck != null)
            {
                Db.Add(truck);
                Db.SaveChanges();
            }
        }

        public Truck Remove(Truck truck)
        {
            if (truck != null)
            {
                Db.Remove(truck);
                Db.SaveChanges();
            }
            return truck;
        }

        public Truck Update(Truck truck)
        {
            if (truck != null)
            {
                Db.Update(truck);
                Db.SaveChanges();
            }
            return truck;
        }
    }
}