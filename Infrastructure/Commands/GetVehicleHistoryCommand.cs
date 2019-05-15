using API.Commands.Contracts;
using Application.Adapters;
using Infrastructure.Repositories.Contracts;
using System;

namespace Infrastructure.Commands
{
    public class GetVehicleHistoryCommand : ICommand
    {
        public Guid id;
        public VehicleHistoryAdapter vehicleHistory;

        public GetVehicleHistoryCommand(Guid id)
        {
            this.id = id;
        }

        public bool Execute()
        {
            throw new NotImplementedException();
        }

        public void GetHistory(IReadOnlyRepository<VehicleHistoryAdapter> readRepository)
        {
            vehicleHistory = readRepository.Find(id);
        }
    }
}
