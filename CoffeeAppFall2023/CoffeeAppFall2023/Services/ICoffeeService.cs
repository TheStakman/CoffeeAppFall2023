using CoffeeAppFall2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppFall2023.Services
{
    public interface ICoffeeService
    {
        Task<IEnumerable<Coffee>> GetCoffeesAsync();

        Task<Coffee> AddCoffeeAsync(Coffee coffee);

        Task<Coffee> UpdateCoffeeAsync(Coffee coffee);

        Task<Coffee> DeleteCoffeeAsync(int id);

        Task<Coffee> GetCoffeeAsync(int id);
    }
}
