using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeAppFall2023.Models
{
    public class Coffee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Characteristic { get; set; }

        public string Strength { get; set; }

        public double Cost { get; set; }

        public string ImageURL { get; set; }

        public string CostString => $"Cost: ${Cost}";

        public Coffee()
        {
            List<Coffee> coffees = new List<Coffee>();
        }
    }
}
