using Application.Factories.Interfaces;
using Core.Models;
using System;

namespace Application.Factories
{
    public class ServiceFactory : IFactory<Service>
    {
        public Service Create()
        {
            return new Service();
        }

        public Service Create(string description, string name, float value)
        {
            return new Service
            {
                Id = Guid.NewGuid(),
                Description = description,
                Name = name,
                Value = value
            };
        }
    }
}
