using System;
using System.Collections.Generic;
using Application.Owner.DTOs;
using Application.Service.DTOs;

namespace Application.ServiceOrder.DTOs
{
    public class ServiceOrderDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public int Quantity { get; set; }
        public virtual CarDto Car { get; set; }
        public virtual List<ServiceDto> Services { get; set; }
    }
}
