using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Oficina.Model
{
    public class Car : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Guid _Id;
        private string _Plate;
        private string _Brand;
        private string _Model;
        private string _Color;
        private int _Year;
        private Guid _OwnerId;

        public Guid Id
        {
            get => _Id;
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }

        public string Plate
        {
            get => _Plate;
            set
            {
                _Plate = value;
                OnPropertyChanged();
            }
        }

        public string Brand
        {
            get => _Brand;
            set
            {
                _Brand = value;
                OnPropertyChanged();
            }
        }

        public string Model
        {
            get => _Model;
            set
            {
                _Model = value;
                OnPropertyChanged();
            }
        }

        public string Color
        {
            get => _Color;
            set
            {
                _Color = value;
                OnPropertyChanged();
            }
        }

        public int Year
        {
            get => _Year;
            set
            {
                _Year = value;
                OnPropertyChanged();
            }
        }

        public Guid OwnerId
        {
            get => _OwnerId;
            set
            {
                _OwnerId = value;
                OnPropertyChanged();
            }
        }
    }
}
