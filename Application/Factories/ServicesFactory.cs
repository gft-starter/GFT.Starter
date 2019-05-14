using Application.Interfaces;
using Core.Models;
using System;

namespace Application.Factories
{
    public class ServicesFactory : IFactory<Service>
    {
        public Service Create()
        {
            var service = new Service();
            service.Name = "Martelinho de ouro";
            service.Description = "Reparo de lataria";
            service.Value = "1000.00";

            return new Service();

        }

        public Service Create(Guid id, string name, string description, string value)
        {
            var service = new Service();
            service.Id = Guid.NewGuid();
            service.Name = name;
            service.Description = description;
            service.Value = value;

            return new Service();
        }
    }
}
