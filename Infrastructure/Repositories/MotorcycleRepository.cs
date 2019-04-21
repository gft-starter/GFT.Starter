using System;
using System.Collections.Generic;
using System.Linq;
using GFT.Starter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class MotorcycleRepository : BaseRepository, IReadOnlyRepository<Motorcycle>, IWriteRepository<Motorcycle>
    {
        public IEnumerable<Motorcycle> Get() => Db
            .Vehicles.OfType<Motorcycle>()
            .Include(c => c.Owner)
            .ToList();

        public Motorcycle Find(Guid id) => Db
            .Vehicles.OfType<Motorcycle>()
            .Include(c => c.Owner)
            .FirstOrDefault(c => c.Id == id);

        public void Add(Motorcycle motorcycle)
        {
            if (motorcycle != null)
            {
                Db.Add(motorcycle);
                Db.SaveChanges();
            }
        }

        public Motorcycle Remove(Motorcycle motorcycle)
        {
            if (motorcycle != null)
            {
                Db.Remove(motorcycle);
                Db.SaveChanges();
            }
            return motorcycle;
        }

        public Motorcycle Update(Motorcycle motorcycle)
        {
            if (motorcycle != null)
            {
                Db.Update(motorcycle);
                Db.SaveChanges();
            }
            return motorcycle;
        }
    }
}