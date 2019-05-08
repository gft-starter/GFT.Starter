using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf.Models
{
    public class Car : INotifyPropertyChanged
    {
        private string _plate;
        private string _brand;
        private string _model;
        private string _color;
        private int _year;
        public Guid Id { get; set; }

        public string Plate
        {
            get => _plate;
            set
            {
                _plate = value;
                OnPropertyChanged();
            }
        }

        public string Brand
        {
            get => _brand;
            set
            {
                _brand = value;
                OnPropertyChanged();
            }
        }

        public string Model
        {
            get=> _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public string Color
        {
            get =>_color;
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
