using CoffeeAppFall2023.Services;
using CoffeeAppFall2023.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppFall2023.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            this.LoginCommand = new Command(OnLoginClicked);
        }

		private async void OnLoginClicked(object obj)
		{
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
		}
	}
}
