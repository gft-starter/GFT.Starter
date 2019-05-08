using Core.Models;

namespace Infrastructure.Services.Contracts
{
    public interface IServiceOrderCalcualtor
    {
        double CalculatorTotalPrice(ServiceOrder serviceOrder);
    }
}
