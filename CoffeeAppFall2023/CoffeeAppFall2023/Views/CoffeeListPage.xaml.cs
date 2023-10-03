using CoffeeAppFall2023.ViewModels;

namespace CoffeeAppFall2023.Views;

public partial class CoffeeListPage : ContentPage
{
	CoffeeListViewModel ViewModel => this.BindingContext as CoffeeListViewModel;

	public CoffeeListPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await ViewModel.OnAppearing();
		coffeeList.ItemsSource = ViewModel.Coffees;
	}
}