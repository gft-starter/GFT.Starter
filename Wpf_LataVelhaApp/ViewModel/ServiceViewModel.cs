using System.Collections.ObjectModel;
using Wpf.Models;

namespace Wpf.ViewModel
{
    class ServiceViewModel :  ObservableCollection<Service>
    {
        public ServiceViewModel()
        {
            createListService();
        }

        private void createListService()
        {
            Add(new Service
            {
                Name = "Troca de oleo",
                Description = "Troca de oleo no motor",
                Value = "350.00"
            });
            Add(new Service
            {
                Name = "Pintura",
                Description = "Troca ou Raparo de Pintura Velha do veiculo",
                Value = "850.00"
            });
            Add(new Service
            {
                Name = "Troca do conjunto de pneus",
                Description = "kit de 4 pneus novos para troca",
                Value = "1350.00"
            });
            Add(new Service
            {
                Name = "Martelinho de Ouro",
                Description = "reparo de Lataria do veiculo",
                Value = "600.00"
            });

        }
    }
}
