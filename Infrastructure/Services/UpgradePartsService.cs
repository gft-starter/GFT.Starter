using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services
{
    public class UpgradePartsService
    {
        public void ChangeTires(Vehicle vehicle)
        {
            vehicle.ChangeFourTires();
        }
    }
}
