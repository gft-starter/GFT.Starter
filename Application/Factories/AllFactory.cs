using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Factories
{
    public class AllFactory
    {
        public dynamic Create(string factoryName)
        {
            switch (factoryName)
            {
                case "owner":
                    return new OwnersFactory();
                case "car":
                    return new CarsFactory();
                case "service":
                    return new ServicesFactory();
                case "serviceOrder":
                    return new ServiceOrdersFactory();
                default:
                    return null;
            }
        }
    }
}
