using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeal.DataAccess
{
    public  class CategoryDAO
    {
        private Db Db;
        public CategoryDAO(ref Db db)
        {
            Db = db;
        }
        public  Category[] GetAllCategories()
        {
            return Db.Category;
        }

        public  Category GetCategory(string Name)
        {
            foreach(Category category in Db.Category)
            {
                if (category.name == Name) return category;
            }
            return null;
        }

    }
}
