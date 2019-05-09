using System;
using System.Collections.ObjectModel;
using WPF_Oficina.Model;

namespace WPF_Oficina.ViewModel
{
    public class CarViewModel : ObservableCollection<Car>
    {
        public CarViewModel()
        {
            CriarListaCars();
        }

        private void CriarListaCars()
        {
            Add(new Car
            {
                Id = new Guid("ae48e696-777f-4b96-b686-3c514f72d726"),
                Plate = "ABC1010",
                Brand = "Fiat",
                Model = "Uno",
                Color = "White",
                Year = 2000,
                OwnerId = new Guid("535fdc3c-369c-4580-a2f5-b6c2d890639a")
            });

            Add(new Car
            {
                Id = new Guid("fc001ff0-aafa-4f9d-90c8-472aba5d8000"),
                Plate = "ERF5435",
                Brand = "Honda",
                Model = "Fit",
                Color = "Silver",
                Year = 2001,
                OwnerId = new Guid("90999f3a-0218-4902-956a-2979eec5318b")
            });

            Add(new Car
            {
                Id = new Guid("40637e95-2949-452e-ae8c-71cfbd9a2c7a"),
                Plate = "INJ2364",
                Brand = "Ford",
                Model = "Fiesta",
                Color = "Black",
                Year = 2002,
                OwnerId = new Guid("fb79e887-da9e-43df-8e72-a94af709a777")
            });
        }
    }
}
