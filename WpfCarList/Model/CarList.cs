using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfCarList.Model
{
    public class CarList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _model;
        private string _brand;
        private string _plate;
        private string _color;
        private int _year;


        public string Modelo
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
         }

        public string Marca
        {
            get => _brand;
            set
            {
                _brand = value;
                OnPropertyChanged();
            }
        }

        public string Placa
        {
            get => _plate;
            set
            {
                _plate = value;
                OnPropertyChanged();
            }
        }

        public string Cor
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }

        public int Ano
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }

    }


    
}

