﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeAppFall2023.ViewModels
{
    internal class AboutViewModel : BaseViewModel
    {
        public AboutViewModel() : base(null)
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://Maui.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
