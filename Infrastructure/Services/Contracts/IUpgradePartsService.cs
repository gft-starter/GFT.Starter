using GFT.Starter.Core.Models;

namespace GFT.Starter.Infrastructure.Services.Contracts
{
    public interface IUpgradePartsService
    {
        void ChangeTires(Car vehicle);
    }
}