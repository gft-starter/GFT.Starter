using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFOwnerList.Model;

namespace WPFOwnerList.ViewModel
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
                Name = "Jonas",
                CPF = "123",
                Birthdate = DateTime.Now,
                Gender = 'M'
            });
            Add(new Owner
            {
                Name = "Lucas",
                CPF = "456",
                Birthdate = DateTime.Now,
                Gender = 'M'
            });
            Add(new Owner
            {
                Name = "Lara",
                CPF = "789",
                Birthdate = DateTime.Now,
                Gender = 'F'
            });
        }
    }
}
