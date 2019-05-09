using System;
using System.Collections.ObjectModel;
using WPF_Oficina.Model;

namespace WPF_Oficina.ViewModel
{
    public class ServiceViewModel : ObservableCollection<Service>
    {
        public ServiceViewModel()
        {
            CriarListaServices();
        }

        private void CriarListaServices()
        {
            Add(new Service
            {
                Id = new Guid("c1f9db65-f41a-4b02-a9fb-4b60ca02f8cb"),
                Name = "Troca de Pneu",
                Description = "Troca de Pneu",
                Value = 100
            });

            Add(new Service
            {
                Id = new Guid("b8214b63-8c3c-4cb3-aefc-8e4a2e6e29b3"),
                Name = "Troca de Oleo",
                Description = "Troca de Oleo",
                Value = 200
            });

            Add(new Service
            {
                Id = new Guid("6e6dd616-c7fa-4271-a206-be691ffefe61"),
                Name = "Troca de Freio",
                Description = "Troca de Freio",
                Value = 300
            });
        }
    }
}
