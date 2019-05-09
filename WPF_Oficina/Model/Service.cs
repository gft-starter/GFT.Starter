using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Oficina.Model
{
    public class Service : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Guid _Id;
        private string _Name;
        private string _Description;
        private float _Value;

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

        public string Description
        {
            get => _Description;
            set
            {
                _Description = value;
                OnPropertyChanged();
            }
        }

        public float Value
        {
            get => _Value;
            set
            {
                _Value = value;
                OnPropertyChanged();
            }
        }
    }
}
