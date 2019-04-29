using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPRojeto.Models
{
    public class ServiceOrder
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid ServiceId { get; set; }
        public int Quantity { get; set; }
        public virtual Car Car { get; set; }
        public virtual Service Service { get; set; }

    }
}
