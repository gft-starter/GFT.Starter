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

        private void ListarCarros()
        {
            Add(new Car
            {
                Id = Guid.NewGuid(),
                Brand = "Chevrolet",
                Color = "Black",
                Model = "Celta",
                Plate = "HDJ-2407",
                Year = 2009
            });

            Add(new Car
            {
                Id = Guid.NewGuid(),
                Brand = "Ford",
                Color = "Blue",
                Model = "Focus",
                Plate = "DTY-5567",
                Year = 2013
            });

            Add(new Car
            {
                Id = Guid.NewGuid(),
                Brand = "Fiat",
                Color = "Green",
                Model = "Uno",
                Plate = "FKY-7489",
                Year = 1998
            });

            Add(new Car
            {
                Id = Guid.NewGuid(),
                Brand = "Volkswagen",
                Color = "Blue",
                Model = "Fusca",
                Plate = "FMI-1458",
                Year = 1969
            });
        }
    }
}
