using CoffeeAppFall2023.Models;
using CoffeeAppFall2023.Services;
using CoffeeAppFall2023.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppFall2023.ViewModels
{
    public class ItemsViewModel: BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }

        public Command LoadItemsCommand { get; }

        public Command AddItemCommand { get; }

        public Command<Item> ItemTapped { get; }

        public IDataStore<Item> DataStore { get; set; }


        public ItemsViewModel()
        {
            Title = "Browse";
            DataStore = new MockDataStore();
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Item>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
        }

        private async void OnItemSelected(Item item)
        {
            if (item == null) return;

            
            Items.Add(item);

            await Shell.Current.GoToAsync($"{ nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in Items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private async void OnAddItem(object ojb)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }
}
