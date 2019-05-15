using Application.Adapters;
using Infrastructure.Configuration;
using Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class VehicleHistoryRepository : IReadOnlyRepository<VehicleHistoryAdapter>
    {
        private readonly LataNovaContext _db;

        public VehicleHistoryRepository(LataNovaContext db)
        {
            _db = db;
        }

        public VehicleHistoryAdapter Find(Guid id)
        {
            var history = new VehicleHistoryAdapter();
            history.vehicle = _db.Vehicles.Include(c => c.Owner).FirstOrDefault(c => c.Id == id);

            var serviceOrders = _db.ServiceOrders.Where(so => so.VehicleId == id).Select(so => so.Id).ToList();
            history.services = _db.Services.Where(s => serviceOrders.Contains(s.Id)).ToList();

            return history;
        }

        public IEnumerable<VehicleHistoryAdapter> Get()
        {
            throw new NotImplementedException();
        }
    }
}
