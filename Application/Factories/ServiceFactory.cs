using System;
using System.Collections.Generic;
using System.Text;
using GFT.Starter.Application.Factories.Interfaces;
using GFT.Starter.Core.Models;

namespace GFT.Starter.Application.Factories
{
    public class ServiceFactory : IFactory<Service>
    {
        public Service Create()
        {
            var service = new Service();
            service.Description = "Lavagem completa";
            service.Name = "LavCompl";
            service.Value = 50;

            return service;
        }
    }
}
