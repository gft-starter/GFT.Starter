using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services
{
    public interface IServiceOrderCalculator
    {
        float CalculateTotalPrice(ServiceOrder serviceOrder);
    }
}