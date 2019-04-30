using Helpers.Domain;

namespace DomainModel.ServiceOrder.Events
{
    public class ServiceCreated : DomainEvent
    {
        public Service Service { get; set; }

        public override void Flatten()
        {
            Args.Add(nameof(Service.Id), Service.Id);
            Args.Add(nameof(Service.Name), Service.Name);
            Args.Add(nameof(Service.Value), Service.Value);
            Args.Add(nameof(Service.Description), Service.Description);
        }
    }
}
