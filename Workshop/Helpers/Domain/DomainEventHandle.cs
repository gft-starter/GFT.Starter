using Helpers.Repository;

namespace Helpers.Domain
{
    public class DomainEventHandle<TDomainEvent> : IHandles<TDomainEvent>
        where TDomainEvent : DomainEvent
    {
        readonly IDomainEventRepository _domainEventRepository;

        public DomainEventHandle(IDomainEventRepository domainEventRepository)
        {
            _domainEventRepository = domainEventRepository;
        }

        public void Handle(TDomainEvent @event)
        {
            @event.Flatten();
            _domainEventRepository.Add(@event);
        }
    }
}
