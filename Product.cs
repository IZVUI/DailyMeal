using System;
using DataAccess;

namespace DailyMeal.DataAccess
{
	[Serializable]
	public class Product
	{
		public Product()
		{
		}

		public Product(string name, double gramms, double protein, double fats, double carbs, double calories)
		{
			Name = name;
			Gramms = gramms;
			Protein = protein;
			Fats = fats;
			Carbs = carbs;
			Calories = calories;
		}

		public string Name { get; set; }
		public double Gramms { get; set; }
		public double Protein { get; set; }
		public double Fats { get; set; }
		public double Carbs { get; set; }
		public double Calories { get; set; }		
	}
}

