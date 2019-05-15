using Core.Models;
using System.Collections.Generic;

namespace Application.Adapters
{
    public class VehicleHistoryAdapter
    {
        public Vehicle vehicle;
        public List<Service> services = new List<Service>();
    }
}
