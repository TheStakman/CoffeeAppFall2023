using CoffeeAppFall2023.Models;
using CoffeeAppFall2023.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeAppFall2023.ViewModels
{
	public class LoginPageViewModel: BasePageViewModel
	{
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool LoggedIn => SessionInfo.Instance.LoggedIn;

        public ICommand LoginCommand { get; set; }

        public ICommand CoffeeCommand { get; set; }

        private ICoffeeService _coffeeService { get; set; }

        public LoginPageViewModel(ICoffeeService coffeeService)
        {
            this._coffeeService = coffeeService;
            this.UserName = GetUserName().Result;
        }

		private static Task<string> GetUserName()
		{
            try
            {
                var nameTask = SecureStorage.GetAsync("username");

                if (string.IsNullOrEmpty(nameTask.Result)) 
                {
                    return Task.FromResult(string.Empty);
                }

                return nameTask;
            }
            catch(Exception ex) 
            {
                Debug.WriteLine($"Exception on getusername {ex.Message}");
                return Task.FromResult("Exception on getUserName");
            }

		}
	}
}
