using System;
using System.Collections.ObjectModel;
using Wpf.Models;

namespace Wpf.ViewModel
{ 
    class ServiceOrderViewModel : ObservableCollection<ServiceOrder>
    {
        public ServiceOrderViewModel()
        {
            createListServiceOrder();
        }

        private void createListServiceOrder()
        {
            Add(new ServiceOrder
            {
                Quantity = 1

            });

            Add(new ServiceOrder
            {
                Quantity = 2

            });
            Add(new ServiceOrder
            {
                Quantity = 2

            });
            Add(new ServiceOrder
            {
                Quantity = 5

            });
        }
    }
}
