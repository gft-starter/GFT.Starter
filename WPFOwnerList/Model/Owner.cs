using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFOwnerList.Model
{
    public class Owner : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        private string cpf;

        public DateTime birthdate;

        public char gender;
       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string CPF
        {
            get => cpf;
            set
            {
                cpf = value;
                OnPropertyChanged();
            }
        }
        public DateTime Birthdate
        {
            get => birthdate;
            set
            {
                birthdate = value;
                OnPropertyChanged();
            }
        }
        public char Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
    }
}
