using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Oficina.Model;

namespace WPF_Oficina.ViewModel
{
    public class ServiceOrderViewModel : ObservableCollection<ServiceOrder>
    {
        public ServiceOrderViewModel()
        {
            CriarListaServiceOrders();
        }

        private void CriarListaServiceOrders()
        {
            Add(new ServiceOrder
            {
                Id = new Guid("1e34b351-e3f6-4e77-98e5-7e5a117ac7e4"),
                CarId = new Guid("ae48e696-777f-4b96-b686-3c514f72d726"),
                ServiceId = new Guid("c1f9db65-f41a-4b02-a9fb-4b60ca02f8cb"),
                Quantity = 1
            });

            Add(new ServiceOrder
            {
                Id = new Guid("e682e6c1-1645-4792-adf2-7535c2d1a756"),
                CarId = new Guid("fc001ff0-aafa-4f9d-90c8-472aba5d8000"),
                ServiceId = new Guid("b8214b63-8c3c-4cb3-aefc-8e4a2e6e29b3"),
                Quantity = 2
            });

            Add(new ServiceOrder
            {
                Id = new Guid("7790c7a4-b558-4f89-b88c-9e54d3f9fae1"),
                CarId = new Guid("40637e95-2949-452e-ae8c-71cfbd9a2c7a"),
                ServiceId = new Guid("6e6dd616-c7fa-4271-a206-be691ffefe61"),
                Quantity = 3
            });
        }
    }
}
