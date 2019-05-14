using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Factories
{
    public class AllFactory
    {
        public dynamic Create(string factoryName)
        {
            switch(factoryName)
            {
                case "owner":
                    return new OwnerFactory();
                case "car":
                    return new CarFactory();
                default:
                    return null;
            }
        }
    }
}
