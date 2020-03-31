using System;
using System.Xml.Serialization;

namespace DailyMeal.DataAccess
{
	[Serializable]
	public class Category
	{
		public Category()
		{
		}

		public Category(Product[] products)
		{
			Product = products;
		}
		
		[XmlElement]
		public Product[] Product { get; set; }
		[XmlAttribute]
		public string name { get; set; }
		[XmlAttribute]
		public string discription { get; set; }		
	}

	//ProductDAO productDAO = new ProductDAO();
	/*public Product GetProduct(string name)
	{
		return productDAO.GetProduct(string name);
	}*/

}
