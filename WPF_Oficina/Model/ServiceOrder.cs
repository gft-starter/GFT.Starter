using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Oficina.Model
{
    public class ServiceOrder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Guid _Id;
        private Guid _CarId;
        private Guid _ServiceId;
        private int _Quantity;

        public Guid Id
        {
            get => _Id;
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }

        public Guid CarId
        {
            get => _CarId;
            set
            {
                _CarId = value;
                OnPropertyChanged();
            }
        }

        public Guid ServiceId
        {
            get => _ServiceId;
            set
            {
                _ServiceId = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get => _Quantity;
            set
            {
                _Quantity = value;
                OnPropertyChanged();
            }
        }
    }
}
