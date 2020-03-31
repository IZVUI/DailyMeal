using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DailyMeal.DataAccess
{
    [Serializable]
    public class Db
    {
        public Db() {  }       

        [XmlElement]
        public  Category[] Category { get; set; }        

        public static Db GetData()
        {
             XmlSerializer serializer = new XmlSerializer(typeof(Db));
             using (FileStream fs = new FileStream(@"D:\универ\4  сем\OOP\Lab1\DailyMeal\Products.xml",FileMode.Open))
             {
                 return (Db)serializer.Deserialize(fs);
                 
                // Categories = (Category[])serializer.Deserialize(fs);
             }            
        }
       /*public void Test()
        {
            Category[] Categories = new Category[3];
            Category category = new Category();
            category.discription = "dc";
            category.name = "pecta";
            Product[] products = new Product[3];
            Product product1 = new Product("certttt", 3.4, 4.6, 5, 6, 7);
            Product product2 = new Product("vsafr", 5, 7, 3, 1.3, 8);
            Product product3 = new Product("zvcv", 0.1, 9.3, 4, 2, 3);
            products[0] = product1;
            products[1] = product3;
            products[2] = product2;
            category.Product = products;
            Categories[0] = category;
            Categories[1] = new Category();
            this.Category = Categories;
            XmlSerializer serializer = new XmlSerializer(typeof(Db));
            using (FileStream fs = new FileStream(@"D:\универ\4  сем\OOP\Lab1\DailyMeal\Test2.xml", FileMode.Create))
            {
                serializer.Serialize(fs, this);
            }
        }*/
    }
}
