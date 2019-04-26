using GFT.Starter.Core.Models;
using GFT.Starter.Infrastructure.Services.Contracts;

namespace GFT.Starter.Infrastructure.Services
{
    public class ServiceOrderCalculator : IServiceOrderCalculator
    {
        public float CalculateTotalPrice(ServiceOrder serviceOrder)
        {
            return serviceOrder.Quantity * serviceOrder.Service.Value * serviceOrder.Vehicle.PriceMultiplier;
        }
    }
}
