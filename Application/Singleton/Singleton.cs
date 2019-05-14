﻿using GFT.Starter.Application.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Starter.Application.Singleton
{
    public sealed class Singleton
    {
        private static CarFactory carFactory = null;
        private static OwnerFactory ownerFactory = null;
        private static ServiceFactory serviceFactory = null;
        private static ServiceOrderFactory serviceOrderFactory = null;
        private static readonly object padlock = new object();


        Singleton()
        {

        }

        public static CarFactory CarFactory
        {
            get
            {
                if (carFactory == null)
                {
                    lock (padlock)
                    {
                        if (carFactory == null)
                        {
                            carFactory = new CarFactory();
                        }
                    }
                }
                return carFactory;
            }
        }

        public static OwnerFactory OwnerFactory
        {
            get
            {
                if (ownerFactory == null)
                {
                    lock (padlock)
                    {
                        if (ownerFactory == null)
                        {
                            ownerFactory = new OwnerFactory();
                        }
                    }
                }
                return ownerFactory;
            }
        }

        public static ServiceFactory ServiceFactory
        {
            get
            {
                if (serviceFactory == null)
                {
                    lock (padlock)
                    {
                        if (serviceFactory == null)
                        {
                            serviceFactory = new ServiceFactory();
                        }
                    }
                }
                return serviceFactory;
            }
        }

        public static ServiceOrderFactory ServiceOrderFactory
        {
            get
            {
                if (serviceOrderFactory == null)
                {
                    lock (padlock)
                    {
                        if (serviceOrderFactory == null)
                        {
                            serviceOrderFactory = new ServiceOrderFactory();
                        }
                    }
                }
                return serviceOrderFactory;
            }
        }

    }
}
