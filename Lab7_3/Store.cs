using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab7_3
{
    public class Store : INotifyPropertyChanged
    {
        public ObservableCollection<Article> articles = new ObservableCollection<Article>();
        private int __index;
        public int Index
        {
            get
            {
                return __index;
            }
            set
            {
                __index = value;
                OnPropertyChanged("Index");
            }
        }

        public ObservableCollection<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                OnPropertyChanged("Articles");
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}