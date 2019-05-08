using System;
using System.Collections.ObjectModel;
using Wpf.Models;

namespace Wpf.ViewModel
{
    class OwnerViewModel : ObservableCollection<Owner>
    {
        public OwnerViewModel()
        {
            createListOwner();
        }

        private void createListOwner()
        {
            Add(new Owner
            {
                Name = "Carlos Miguel",
                CPF = "12345678955",
                BirthDate = DateTime.MinValue,
                Gender = 'M',
            });
            Add(new Owner
            {
                Name = "Carla Almeida",
                CPF = "222456987822",
                BirthDate = DateTime.Now,
                Gender = 'F',
            });
         
        }
    }
}
