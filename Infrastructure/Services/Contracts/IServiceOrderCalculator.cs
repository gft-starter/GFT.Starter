using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services.Contracts
{
    public interface IServiceOrderCalculator
    {
        float CalculateTotalPrice(ServiceOrder serviceOrder);
    }
}