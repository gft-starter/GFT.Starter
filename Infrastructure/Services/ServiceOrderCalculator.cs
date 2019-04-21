using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services
{
    public class ServiceOrderCalculator
    {
        public float CalculateTotalPrice(ServiceOrder serviceOrder)
        {
            return serviceOrder.Quantity * serviceOrder.Service.Value * serviceOrder.Vehicle.PriceMultiplier;
        }
    }
}
