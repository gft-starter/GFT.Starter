using DomainModel.ServiceOrder.Events;
using Helpers.Domain;
using Helpers.Service;

namespace DomainModel.ServiceOrder.Handlers
{
    public class ServiceOrderCreatedHandler : IHandles<ServiceOrderCreated>
    {
        private readonly IEmailService _emailService;

        public ServiceOrderCreatedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Handle(ServiceOrderCreated args)
        {
            _emailService.SendEmail(args.ServiceOrder.Car.Model, args.ServiceOrder.Car.Model);
        }
    }
}
