using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services
{
    public class UpgradePartsService : IUpgradePartsService
    {
        public void ChangeTires(Vehicle vehicle)
        {
            vehicle.ChangeTires();
        }
    }
}
