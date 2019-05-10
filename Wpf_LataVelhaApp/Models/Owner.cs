using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf.Models
{
    public class Owner
    {
        private string _name;
        private string _cpf;
        private DateTime _birthdate;
        private char _gender;


        public Guid Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string CPF
        {
            get => _cpf;
            set
            {
                _cpf = value;
                OnPropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get => _birthdate;
            set
            {
                _birthdate = value;
                OnPropertyChanged();
            }
        }
        public char Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
