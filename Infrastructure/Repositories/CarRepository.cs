using System;
using System.Collections.Generic;
using System.Linq;
using GFT.Starter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GFT.Starter.Infrastructure.Repositories
{
    public class CarRepository : BaseRepository, IReadOnlyRepository<Car>, IWriteRepository<Car>
    {
        public IEnumerable<Car> Get() => Db
            .Vehicles.OfType<Car>()
            .Include(c => c.Owner)
            .ToList();

        public Car Find(Guid id) => Db
            .Vehicles.OfType<Car>()
            .Include(c => c.Owner)
            .FirstOrDefault(c => c.Id == id);

        public void Add(Car car)
        {
            if (car != null)
            {
                Db.Add(car);
                Db.SaveChanges();
            }
        }

        public Car Remove(Car car)
        {
            if (car != null)
            {
                Db.Remove(car);
                Db.SaveChanges();
            }
            return car;
        }

        public Car Update(Car car)
        {
            if (car != null)
            {
                Db.Update(car);
                Db.SaveChanges();
            }
            return car;
        }
    }
}