﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppFall2023.ViewModels
{
	public class BasePageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

        public BasePageViewModel()
        {
            
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
