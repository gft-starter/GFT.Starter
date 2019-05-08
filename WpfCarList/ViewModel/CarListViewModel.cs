using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCarList.Model;

namespace WpfCarList.ViewModel
{
    class CarListViewModel : ObservableCollection<CarList>
    {
        public CarListViewModel()
        {
            AddCarList();
        }

        private void AddCarList()
        {
            Add(new CarList
            {
                Modelo = "Fiesta",
                Marca = "Ford",
                Placa = "CRW-3166",
                Cor = "Verde",
                Ano = 1997            
               });

            Add(new CarList
            {
                Modelo = "Palio",
                Marca = "Fiat",
                Placa = "ABC-1233",
                Cor = "Preto",
                Ano = 2008
            });


            Add(new CarList
            {
                Modelo = "Spyder",
                Marca = "Maserati",
                Placa = "AXE-4923",
                Cor = "Fuscia",
                Ano = 2005
            });

            Add(new CarList
            {
                Modelo = "LR4",
                Marca = "Land Rover",
                Placa = "HBR-3992",
                Cor = "Teal",
                Ano = 2012
            });
        }
    }
}
