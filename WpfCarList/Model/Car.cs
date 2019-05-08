using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfCarList.Model
{
    public class Car : INotifyPropertyChanged
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _plate;

        public string Plate
        {
            get { return _plate; }
            set
            {
                _plate = value;
                OnPropertyChanged();
            }
        }

        private string _brand;

        public string Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                OnPropertyChanged();
            }
        }

        private string _model;

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }
        private int _year;

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
