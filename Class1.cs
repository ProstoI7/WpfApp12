using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private string _manufacturer;
        private double _price;
        private string _stockQuantity;
        private string _image;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                OnPropertyChanged(nameof(Manufacturer));
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string StockQuantity
        {
            get => _stockQuantity;
            set
            {
                _stockQuantity = value;
                OnPropertyChanged(nameof(StockQuantity));
            }
        }
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
