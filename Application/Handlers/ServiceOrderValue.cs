using Application.Interfaces;
using System;

namespace Core.Models
{
    public class ServiceOrderValue : IServiceOrder
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid ServiceId { get; set; }
        public int Quantity { get; set; }
        public virtual Car Car { get; set; }
        public virtual Service Service { get; set; }

        public void CalculatorValue(int quantity, double value)
        {
            double TotalPay = 0.00;

            TotalPay =  Service.Value * 0.10; 
        }
    }
}
