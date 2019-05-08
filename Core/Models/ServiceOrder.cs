using System;

namespace GFT.Starter.Core.Models
{
    public class ServiceOrder
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Guid ServiceId { get; set; }
        public int Quantity { get; set; }
        public virtual Service Service { get; set; }
        public virtual Car Car { get; set; }
    }
}
