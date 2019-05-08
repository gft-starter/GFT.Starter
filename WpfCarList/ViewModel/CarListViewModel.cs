using System;
using System.Collections.ObjectModel;
using WpfCarList.Model;

namespace WpfCarList.ViewModel
{
    public class CarListViewModel : ObservableCollection<Car>
    {
        public CarListViewModel()
        {
            ListarCarros();
        }

        public void ListarCarros()
        {
           
        }
    }
}
