using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf.Models
{
    public class Service
    {
        private string _name;
        private string _description;
        private string _value;


        public Guid Id { get; set; }
        public string Name {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Description {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public string Value {
            get => _value;
            set
            {
                _value = value;
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
