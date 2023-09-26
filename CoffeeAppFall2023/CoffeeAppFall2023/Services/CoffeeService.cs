using CoffeeAppFall2023.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppFall2023.Services
{
    public class CoffeeService : ICoffeeService
    {
        //base URL is going to be ngrok.io url that we use in order to connect to our api locally.
        const string baseURL = "";

        public CoffeeService()
        {
            
        }

        public async Task<Coffee> AddCoffeeAsync(Coffee coffee)
        {
            string sCoffee = JsonConvert.SerializeObject(coffee);

            using (var httpClient = new HttpClient(new HttpClientHandler())) 
            {
                var content = new StringContent(sCoffee, Encoding.UTF8, "application/json");
                var msg = await httpClient.PostAsync(baseURL + "/api/coffee", content);
                if (msg.IsSuccessStatusCode)
                {
                    var json = await msg.Content.ReadAsStringAsync();
                    var newCoffee = JsonConvert.DeserializeObject<Coffee>(json);
                    return newCoffee;
                }
                else { return new Coffee(); }
            }
        }

        public Task<Coffee> DeleteCoffeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Coffee> GetCoffeeAsync(int id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Coffee>> GetCoffeesAsync()
        {
            using (var httpClient = new HttpClient()) 
            {
                var json = await httpClient.GetStringAsync(baseURL + "/api/coffee");
                var coffees = JsonConvert.DeserializeObject<IEnumerable<Coffee>>(json);
                return coffees; 
            }
        }

        public Task<Coffee> UpdateCoffeeAsync(Coffee coffee)
        {
            throw new NotImplementedException();
        }
    }
}
