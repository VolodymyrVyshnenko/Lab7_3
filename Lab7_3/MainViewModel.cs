using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;


namespace lab7_3
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Store myStore = new Store();
        private Article selectArt = new Article();
        private string __productName;

        public string ProductName
        {
            get { return __productName; }
            set
            {
                __productName = value;
                OnPropertyChanged("ProductName");
            }
        }


        public Article Select
        {
            get { return selectArt; }

            set
            {
                selectArt = value;
                OnPropertyChanged("Select");
            }

        }
        public Store MyStore
        {
            get
            {
                return myStore;
            }
            set
            {
                myStore = value;
                OnPropertyChanged("MyStore");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj =>
                       {
                           myStore.articles.Add(new Article
                           {
                               Price = Select.Price,
                               productName = Select.productName,
                               ShopName = Select.ShopName
                           });
                           Debug.Write(myStore.articles.Count);


                       }));
            }
        }

        private RelayCommand SearchIndex;
        public RelayCommand SearchByIndex
        {
            get
            {
                return SearchIndex ??
                       (SearchIndex = new RelayCommand(obj =>
                       {
                           Search(MyStore.Index);


                       }));
            }

            set => throw new System.NotImplementedException();
        }
        private RelayCommand SearchName;
        public RelayCommand SearchByName
        {
            get
            {
                return SearchName ??
                       (SearchName = new RelayCommand(obj =>
                       {
                           Search(MyStore.Index);


                       }));
            }

            set => throw new System.NotImplementedException();
        }

        private void SearchByProductName(string n)
        {
            bool result = false;
            for (int k = 0; k < myStore.Articles.Count; k++)
            {
                if (myStore.Articles[k].productName == n)
                {
                    Select = myStore.Articles[k];
                    result = true;
                }
            }

            if (result == false)
            {
                MessageBox.Show("Не найдено товаров с таким именем");
            }
        }
        private void Search(int index)
        {
            if (index >= 0 & index < myStore.articles.Count)
            {
                Select = myStore.articles[index];
            }
            else
            {
                MessageBox.Show("отсутствует товар с таким индексом");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}