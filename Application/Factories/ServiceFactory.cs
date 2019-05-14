using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class ServiceFactory : IFactory<Service>
    {
        public Service Create()
        {
            var service = new Service();
            service.Name = "Lavagem";
            service.Description = "Lavagem completa";
            service.Value = 15;
            return service;
        }

        public Service Create(string name, string description, float value)
        {
            var service = new Service();
            service.Id = Guid.NewGuid();
            service.Name = name;
            service.Description = description;
            service.Value = value;
            return service;
        }
    }
}
