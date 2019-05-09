using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Oficina.Model
{
    public class Owner : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Guid _Id;
        private string _Name;
        private string _CPF;
        private DateTime _BirthDate;
        private char _Gender;

        public Guid Id
        {
            get => _Id;
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        public string CPF
        {
            get => _CPF;
            set
            {
                _CPF = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get => _BirthDate;
            set
            {
                _BirthDate = value;
                OnPropertyChanged();
            }
        }

        public char Gender
        {
            get => _Gender;
            set
            {
                _Gender = value;
                OnPropertyChanged();
            }
        }
    }
}
