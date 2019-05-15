namespace Application.Factories
{
    public sealed class Factories
    {
        private static OwnerFactory ownerFactory = null;
        private static VehicleFactory vehicleFactory = null;
        private static ServiceFactory serviceFactory = null;
        private static ServiceOrderFactory serviceOrderFactory = null;
        private static readonly object padlock = new object();

        Factories()
        {
        }

        public static OwnerFactory Owner
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

        public static VehicleFactory Vehicle
        {
            get
            {
                if (vehicleFactory == null)
                {
                    lock (padlock)
                    {
                        if (vehicleFactory == null)
                        {
                            vehicleFactory = new VehicleFactory();
                        }
                    }
                }
                return vehicleFactory;
            }
        }

        public static ServiceFactory Service
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

        public static ServiceOrderFactory ServiceOrder
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
