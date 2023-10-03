using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppFall2023.ViewModels
{
	public class ViewModelLocator
	{

        public ViewModelLocator()
        {

        }

        public LoginPageViewModel LoginVM
		{
			get
			{
				return ServiceLocator.Current.GetInstance<LoginPageViewModel>();
			}
		}

		public CoffeeListViewModel CoffeeVM
		{
			get
			{
				return ServiceLocator.Current.GetService<CoffeeListViewModel>();
			}
		}

		//add coffee view model
	}
}
