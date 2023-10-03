using CoffeeAppFall2023.Models;
using CoffeeAppFall2023.Services;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeAppFall2023.ViewModels
{
    public class CoffeeListViewModel: BaseViewModel
    {
        private ICoffeeService _coffeeService;

        public ICommand AddItemCommand { get; }

        public List<Coffee> Coffees => SessionInfo.Instance.Coffees?.ToList();

        public CoffeeListViewModel() 
        {
            Title = "Coffee List";
        }

        public CoffeeListViewModel(ICoffeeService coffeeService)
        {
            Title = "Coffee List";
            AddItemCommand = new Command(OnAddItem);
            _coffeeService = coffeeService;
        }

        private async void OnAddItem(object obj)
        {
            //add view for newitempage, then uncomment this
            //await AppShell.Current.GoToAsync(nameof(NewItemPage));
        }

        public async Task OnAppearing()
        {
            if(Coffees == null || Coffees.Count == 0)
            {
                var coffees = await _coffeeService.GetCoffeesAsync();
                SessionInfo.Instance.Coffees = coffees.ToList();
                OnPropertyChanged(nameof(coffees));
            }
        }
    }
}
