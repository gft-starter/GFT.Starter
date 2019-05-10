using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf.Models
{
    public class ServiceOrder 
    {
        private int _quantity;


        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid ServiceId { get; set; }

        public int Quantity {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public virtual Car Car { get; set; }
        public virtual Service Service { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
