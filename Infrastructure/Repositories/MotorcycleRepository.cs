using System;
using System.Collections.Generic;
using System.Linq;
using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class MotorcycleRepository : IReadOnlyRepository<Motorcycle>, IWriteRepository<Motorcycle>
    {
        private readonly LataVelhaContext _db;

        public MotorcycleRepository(LataVelhaContext db)
        {
            _db = db;
        }

        public IEnumerable<Motorcycle> Get() => _db
            .Vehicles.OfType<Motorcycle>()
            .Include(c => c.Owner)
            .ToList();

        public Motorcycle Find(Guid id) => _db
            .Vehicles.OfType<Motorcycle>()
            .Include(c => c.Owner)
            .FirstOrDefault(c => c.Id == id);

        public void Add(Motorcycle motorcycle)
        {
            if (motorcycle != null)
            {
                _db.Add(motorcycle);
                _db.SaveChanges();
            }
        }

        public Motorcycle Remove(Motorcycle motorcycle)
        {
            if (motorcycle != null)
            {
                _db.Remove(motorcycle);
                _db.SaveChanges();
            }
            return motorcycle;
        }

        public Motorcycle Update(Motorcycle motorcycle)
        {
            if (motorcycle != null)
            {
                _db.Update(motorcycle);
                _db.SaveChanges();
            }
            return motorcycle;
        }
    }
}