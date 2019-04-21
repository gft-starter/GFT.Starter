using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services
{
    public interface IUpgradePartsService
    {
        void ChangeTires(Vehicle vehicle);
    }
}