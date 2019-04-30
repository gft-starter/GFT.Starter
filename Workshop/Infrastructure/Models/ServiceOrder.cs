using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class ServiceOrder
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }
        public virtual List<Service> Service { get; set; }
    }
}
