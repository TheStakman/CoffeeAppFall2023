using CoffeeAppFall2023.Models;
using CoffeeAppFall2023.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppFall2023.ViewModels
{
    public class AddCoffeeViewModel : AddBeverageViewModel<Coffee>
    {
        private ICoffeeService _coffeeService;

        public Coffee coffee => Model as Coffee;

        public string Name
        {
            get => coffee.Name;
            set { coffee.Name = value; }
        }

        //characteristic
        public string Characteristic
        {
            get => coffee.Characteristic;
            set => coffee.Characteristic = value;
        }

        //strength
        public string Strength
        {
            get => coffee.Strength;
            set => coffee.Strength = value;
        }

        public decimal Cost
        {
            get => coffee.Cost;
            set => coffee.Cost = value;
        }

        //imageURL
        public string ImageURL
        {
            get => coffee.ImageURL;
            set => coffee.ImageURL = value;
        }

        public Command SaveCommand { get; }

        public Command CancelCommand { get; }

        public AddCoffeeViewModel(ICoffeeService coffeeService) : base(new Coffee())
        {
            _coffeeService = coffeeService;
            AddAction = "Add Coffee";
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        private async void OnCancel(object obj)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave(object obj)
        {
            var newCoffee = await AddBeverage(this.coffee);

            if (newCoffee != null) 
            {

                //await App.Current.MainPage.DisplayAlet("Success", "Coffee Added", "OK");
                SessionInfo.Instance.Coffees = null;

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Coffee Not ADded", "OK");
            }
        }

        public override async Task<Coffee> AddBeverage(Coffee obj)
        {
            obj.Id = Guid.NewGuid();

            return await _coffeeService.AddCoffeeAsync(obj);
        }
    }
}
