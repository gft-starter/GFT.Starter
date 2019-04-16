using APIPRojeto.Models;
using APIPRojeto.Repositorires.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Repositorires
{
    
    public class CarRepository
    {
        private readonly LataVelhaContext _db;
        public CarRepository()
        {
            _db = new LataVelhaContext();

        }
        public IEnumerable<Car> Get() => _db.Cars.ToList();
    }
}
