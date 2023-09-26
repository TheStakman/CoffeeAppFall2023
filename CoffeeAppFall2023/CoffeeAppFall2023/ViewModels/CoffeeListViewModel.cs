using CoffeeAppFall2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeAppFall2023.ViewModels
{
    internal class CoffeeListViewModel: BaseViewModel
    {
        //private ICoffeeService _coffeeService;

        public ICommand AddItemCommand { get; }

        public List<Coffee> Coffees => SessionInfo.Instance.Coffees?.ToList();

        public CoffeeListViewModel() 
        {
            Title = "Coffee LIst";
        }
    }
}
