using System;
using System.Collections.ObjectModel;
using WPF_Oficina.Model;

namespace WPF_Oficina.ViewModel
{
    public class OwnerViewModel : ObservableCollection<Owner>
    {
        public OwnerViewModel()
        {
            CriarListaOwners();
        }

        private void CriarListaOwners()
        {
            Add(new Owner
            {
                Id = new Guid("535fdc3c-369c-4580-a2f5-b6c2d890639a"),
                Name = "Vinicius",
                CPF = "12345678941",
                BirthDate = new DateTime(),
                Gender = 'M'
            });

            Add(new Owner
            {
                Id = new Guid("90999f3a-0218-4902-956a-2979eec5318b"),
                Name = "Maria",
                CPF = "74185296352",
                BirthDate = new DateTime(),
                Gender = 'F'
            });

            Add(new Owner
            {
                Id = new Guid("fb79e887-da9e-43df-8e72-a94af709a777"),
                Name = "Paulo",
                CPF = "96385274187",
                BirthDate = new DateTime(),
                Gender = 'M'
            });
        }
    }
}
