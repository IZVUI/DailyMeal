using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeal.DataAccess
{
    public class ProductDAO
    {
        private Db Db;
        public ProductDAO(ref Db db)
        {
            Db = db;
        }
        public  Product[] GetAllProductsOfCategory(string CategoryName)
        {
            foreach(Category category in Db.Category)
            {
                if (category.name == CategoryName) return category.Product;
            }
            return null;
        }

        public  Product GetProduct(string name)
        {
            foreach(Category category in Db.Category)
            {
                foreach(Product product in category.Product)
                {
                    if (product.Name == name) return product;
                }
            }
            return null;
        }

        public Product GetProductInCategory(string CategoryName,string ProductName)
        {
            foreach (Category category in Db.Category)
            {
                if(category.name==CategoryName)
                {
                    foreach (Product product in category.Product)
                    {
                        if (product.Name == ProductName) return product;
                    }
                }
                
            }
            return null;
        }
    }
}
