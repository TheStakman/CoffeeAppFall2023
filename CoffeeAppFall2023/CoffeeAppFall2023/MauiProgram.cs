using CoffeeAppFall2023.Models;
using CoffeeAppFall2023.Services;
using CoffeeAppFall2023.ViewModels;
using CoffeeAppFall2023.Views;
using Microsoft.Extensions.Logging;

namespace CoffeeAppFall2023
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            //builder.Services.AddSingleton<ICoffeeService, CoffeeService>();
            builder.Services.AddSingleton<ICoffeeService, CoffeeService>();
            builder.Services.AddSingleton<SessionInfo>();
            builder.Services.AddSingleton<LoginPageViewModel>();
			builder.Services.AddSingleton<CoffeeListViewModel>();
			//builder.Services.AddSingleton<AddCoffeeViewModel>();



#if DEBUG
			builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}