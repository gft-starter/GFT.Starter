using APIPRojeto.Models;
using APIPRojeto.Repositorio.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPRojeto.Repositorio
{


    public class CarRepository : BaseRepository

    {
        private readonly LataVelhaContext Db;

        public CarRepository()
        {
            Db = new LataVelhaContext();
        }

        public IEnumerable<Car> Get() => Db
            .Cars
            .Include(c => c.Owner)
            .ToList();

        public Car Find(Guid id) => Db
            .Cars
            .Include ("Owner")
            .Where(c => c.Id == id)
            .FirstOrDefault();

        public void Add (Car car)
        {
            if (car != null)
            {
                Db.Add(car);
                Db.SaveChanges();

            }
        }




    }
}
