using DomainModel.Owner.Events;
using Helpers.Domain;
using Infrastructure;

namespace DomainModel.Owner.Handlers
{
    public class OwnerCreatedHandler : IHandles<OwnerCreated>
    {
        private readonly IEmailService _emailService;

        public OwnerCreatedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Handle(OwnerCreated args)
        {
            _emailService.SendEmail(args.Owner.Name, args.Owner.Name);
        }
    }
}
