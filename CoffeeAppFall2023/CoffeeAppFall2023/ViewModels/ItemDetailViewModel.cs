using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeAppFall2023.Models;
using CoffeeAppFall2023.Services;

namespace CoffeeAppFall2023.ViewModels
{
    public class ItemDetailViewModel: BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;

        public IDataStore<Item> DataStore { get; set; }

        public string Id
        {
            get => itemId;
            set => SetProperty(ref itemId, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get { return itemId; }
            set { itemId = value;
                LoadItemId(value);
            }
        }

        public ItemDetailViewModel()
        {
            Title = "Item Detail";
            DataStore = new MockDataStore();
        }

        private async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load item");
                throw;
            }
        }
    }
}
