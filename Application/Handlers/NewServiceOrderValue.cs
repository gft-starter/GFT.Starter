using Application.Interfaces;
using System;
using Core.Models;

namespace Core.Models
{
    public class NewServiceOrderValue : IServiceOrder
    {
        private ServiceOrder serviceOrder = new ServiceOrder();

        public void CalculatorValue(int quantity, double value)
        {

            double TotalPay = 0.00;
            TotalPay = this.serviceOrder.Service.Value * 0.05;
        }
    }
}
