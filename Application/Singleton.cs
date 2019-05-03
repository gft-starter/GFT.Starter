using GFT.Starter.Application.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application
{
    public sealed class Singleton
    {
        private static OwnerFactory ownerFactory = null;

        private static CarFactory carFactory = null;

        private static ServiceFactory serviceFactory = null;

        private static ServiceOrderFactory serviceOrderFactory;

        public static ServiceOrderFactory ServiceOrderFactory
        {
            get
            {
                if (serviceOrderFactory == null)
                {
                    serviceOrderFactory = new ServiceOrderFactory();
                }
                return serviceOrderFactory;
            }
        }


        public static ServiceFactory ServiceFactory
        {
            get
            {
                if (serviceFactory == null)
                {
                    serviceFactory = new ServiceFactory();
                }
                return serviceFactory;
            }
        }


        public static CarFactory CarFactory
        {
            get
            {
                if (carFactory == null)
                {
                    carFactory = new CarFactory();
                }
                return carFactory;
            }
        }


        public static OwnerFactory OwnerFactory
        {
            get
            {
                if (ownerFactory == null)
                    ownerFactory = new OwnerFactory();
                return ownerFactory;
            }
        }


        private Singleton()
        {
        }


    }
}
