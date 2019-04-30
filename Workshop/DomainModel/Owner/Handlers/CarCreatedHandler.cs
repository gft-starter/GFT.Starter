using DomainModel.Owner.Events;
using Helpers.Domain;
using Infrastructure;

namespace DomainModel.Owner.Handlers
{
    public class CarCreatedHandler : IHandles<CarCreated>
    {
        private readonly IEmailService _emailService;

        public CarCreatedHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Handle(CarCreated args)
        {
            _emailService.SendEmail(args.Car.Model, args.Car.Model);
        }
    }
}
