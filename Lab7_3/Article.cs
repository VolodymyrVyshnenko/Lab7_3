using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace lab7_3
{
    public class Article : INotifyPropertyChanged, IDataErrorInfo
    {
        private string __productName;
        private double __price;
        private string __shopName;
        private int __index;

        public int Index
        {
            get { return __index; }
            set
            {
                __index = value;
                OnPropertyChanged("Index");
            }
        }

        public string productName
        {
            get { return __productName; }
            set
            {
                __productName = value;

                OnPropertyChanged("name");
            }
        }
        public double Price
        {
            get { return __price; }
            set
            {
                __price = value;

                OnPropertyChanged("Price");
            }
        }
        public string ShopName
        {
            get { return __shopName; }
            set
            {
                __shopName = value;

                OnPropertyChanged("ShopName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Price":
                        if (Price < 0)
                        {
                            error = "Цена не может быть меньше нуля";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}