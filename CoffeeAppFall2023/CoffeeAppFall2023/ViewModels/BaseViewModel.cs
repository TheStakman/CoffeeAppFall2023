using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using CoffeeAppFall2023.Services;
using CoffeeAppFall2023.Models;

namespace CoffeeAppFall2023.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        private readonly IDataStore<Item> _dataStore;

        //todo add dependency injection in mauiprogram.cs for IDataStore<Item>
        public BaseViewModel(IDataStore<Item> dataStore)
        {
            _dataStore = dataStore;
        }

        public BaseViewModel()
        {
            
        }

        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
            }
        }

        string title = string.Empty;

        public string Title { get { return title; } set {  SetProperty(ref title, value); } }

        protected bool SetProperty<T>(ref T backingStore, T value,
                         [CallerMemberName] string propertyName = "",
                                    Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        private string _title = string.Empty;




        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion      
    }
}
