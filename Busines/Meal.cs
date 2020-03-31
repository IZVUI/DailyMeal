using DailyMeal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeal.Busines
{
    class Meal
    {
        public Meal(string Name)
        {
            this.Name = Name;
            Products = new List<Product>();
        }
        private List<Product> _products;
        public string Name { get; set; }
        public List<Product> Products
        {
            get => _products;
            set { _products = value; }
        }
    }
}
