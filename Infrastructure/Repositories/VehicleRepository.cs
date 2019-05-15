using Core.Models;
using Infrastructure.Configuration;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class VehicleRepository : IReadOnlyRepository<Vehicle>, IWriteRepository<Vehicle>
    {
        private readonly LataNovaContext _db;

        public VehicleRepository(LataNovaContext db)
        {
            _db = db;
        }

        public IEnumerable<Vehicle> Get() => _db
            .Vehicles
            .Include(c => c.Owner)
            .ToList();

        public Vehicle Find(Guid id) => _db
            .Vehicles
            .Include(c => c.Owner)
            .FirstOrDefault(c => c.Id == id);

        public void Add(Vehicle Vehicle)
        {
            if (Vehicle != null)
            {
                _db.Add(Vehicle);
                _db.SaveChanges();
            }
        }

        public Vehicle Remove(Vehicle Vehicle)
        {
            if (Vehicle != null)
            {
                _db.Remove(Vehicle);
                _db.SaveChanges();
            }
            return Vehicle;
        }

        public Vehicle Update(Vehicle Vehicle)
        {
            if (Vehicle != null)
            {
                _db.Update(Vehicle);
                _db.SaveChanges();
            }
            return Vehicle;
        }
    }
}