using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeal.DataAccess
{
    class DAO
    {
        public CategoryDAO CategoryDAO { get; set; } 
        public ProductDAO ProductDAO { get; set; }
        private Db Db;
        public DAO()
        {
            Db = new Db();
            Db=Db.GetData();
            CategoryDAO = new CategoryDAO(ref Db);
            ProductDAO = new ProductDAO(ref Db);
        }
    }
}
