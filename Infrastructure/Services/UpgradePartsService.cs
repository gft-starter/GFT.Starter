using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services
{
    public class UpgradePartsService
    {
        public void ChangeTires(Vehicle vehicle)
        {
            vehicle.ChangeTire1();
            vehicle.ChangeTire2();
            vehicle.ChangeTire3();
            vehicle.ChangeTire4();
        }
    }
}
