using DomainModel.ServiceOrder.Events;
using Helpers.Domain;
using Helpers.Service;

namespace DomainModel.ServiceOrder.Handlers
{
    public class ServiceCreatedHandler : IHandles<ServiceCreated>
    {
        private readonly IEmailService _emailService;

        public ServiceCreatedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Handle(ServiceCreated args)
        {
            _emailService.SendEmail(args.Service.Name, args.Service.Name);
        }
    }
}
