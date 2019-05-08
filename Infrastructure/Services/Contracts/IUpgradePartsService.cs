using Core.Models;

namespace Infrastructure.Services.Contracts
{
    interface IUpgradePartsService
    {
        void ChangeTires(Car Car);
    }
}
