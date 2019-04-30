using Helpers.Domain;

namespace DomainModel.ServiceOrder.Events
{
    public class ServiceOrderCreated : DomainEvent
    {
        public ServiceOrder ServiceOrder { get; set; }

        public override void Flatten()
        {
            Args.Add(nameof(ServiceOrder.Id), ServiceOrder.Id);
            Args.Add("OwnerName", ServiceOrder.Car.Owner.Name);
            Args.Add("VehicleName", ServiceOrder.Car.Model);
        }
    }
}
