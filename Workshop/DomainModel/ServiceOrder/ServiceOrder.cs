using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DomainModel.Owner;
using DomainModel.ServiceOrder.Events;
using Helpers.Domain;

namespace DomainModel.ServiceOrder
{
    public class ServiceOrder : IAggregateRoot
    {
        private List<Service> _services;
        public virtual ReadOnlyCollection<Service> Services => _services.AsReadOnly();

        public Guid Id { get; private set; }
        public Car Car { get; private set; }

        public static ServiceOrder CreateServiceOrder(Car car, List<Service> services)
        {
            return CreateServiceOrder(Guid.NewGuid(), car, services);
        }

        public static ServiceOrder CreateServiceOrder(Guid id, Car car, List<Service> services)
        {
            var serviceOrder = new ServiceOrder { Id = id, Car = car, _services = services };

            DomainEvents.Raise(new ServiceOrderCreated { ServiceOrder = serviceOrder });

            return serviceOrder;
        }

        public void AddService(Service service)
        {
            _services.Add(service);
        }

        public void UpdateService(Service service)
        {
            var serviceToUpdate = _services.First(x => x.Id == service.Id);
            serviceToUpdate = service;
        }

        public float CalculateValue()
        {
            return Services.Sum(x => x.Value);
        }
    }
}
