using System;
using DomainModel.Service.Events;
using Helpers.Domain;

namespace DomainModel.Service
{
    public class Service : IAggregateRoot
    {
        public static Service CreateService(string name, string description, float value)
        {
            return CreateService(Guid.NewGuid(), name, description, value);
        }

        public static Service CreateService(Guid id, string name, string description, float value)
        {
            var service = new Service { Id = id, Name = name, Description = description, Value = value };

            DomainEvents.Raise(new ServiceCreated { Service = service });
            return service;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public float Value { get; private set; }
    }
}
