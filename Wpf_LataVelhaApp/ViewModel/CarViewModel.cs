using System.Collections.ObjectModel;
using Wpf.Models;

namespace Wpf.ViewModel
{
    class CarViewModel : ObservableCollection<Car>
    {
        public CarViewModel()
        {
            createListCar();
        }

        private void createListCar()
        {
            Add(new Car
            {
                Plate = "XBA-1234",
                Brand = "Renault",
                Model = "Duster",
                Color = "Vermelha",
                Year = 2013
            });

            Add(new Car
            {
                Plate = "TYA-1904",
                Brand = "Fiat",
                Model = "Uno Mille",
                Color = "Preto",
                Year = 2000
            });
            Add(new Car
            {
                Plate = "REX-6446",
                Brand = "Nissan",
                Model = "350Z",
                Color = "Prata",
                Year = 2015
            });
            Add(new Car
            {
                Plate = "You-4304",
                Brand = "Reault",
                Model = "Peugeot 205 Turbo GTI",
                Color = "Branco",
                Year = 1985
            });
            Add(new Car
            {
                Plate = "TYQ-1967",
                Brand = "Fiat",
                Model = "147",
                Color = "Azul",
                Year = 1976
            });

        }
    }
}
