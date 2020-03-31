using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeal.Busines
{
    class User
    {
        public User(int age,double height,double weight,int activity)
        {
            Age = age;
            Height = height;
            Weight = weight;
            Activity = (Activity)activity;
            CalculateDCR();
            Meals = new ObservableCollection<Meal>();
            Meals.Add(new Meal("Dinner"));
            Meals.Add(new Meal("Breakfest"));
            Meals.Add(new Meal("XZtime"));
        }

        public User()
        {
            Age = 0;
            Height = 0;
            Weight = 0;
            Activity = Activity.Unknown;
            DCR = 0;
            Meals = new ObservableCollection<Meal>();
            Meals.Add(new Meal("Dinner"));
            Meals.Add(new Meal("Breakfest"));
            Meals.Add(new Meal("XZtime"));
        }
        private double _weight, _height, _dcr;
        private int _age;
        private ObservableCollection<Meal> _meals;
        private Activity _activity;
        public double Weight
        {
            get => _weight;
            set
            {
                if (value >= 0) _weight = value;
                else { _weight = 0; }
                CalculateDCR();
            }
        }
        public double Height
        {
            get => _height;
            set
            {
                if (value >= 0) _height = value;
                else _height = 0;
                CalculateDCR();
            }
        }
        public int Age
        {
            get => _age;
            set { if (value > 0) _age = value;
                else _age = 1;
                CalculateDCR();
            }
        }

        public double DCR
        {
            get => _dcr;
            set { _dcr = value; }
        }

        public ObservableCollection<Meal> Meals
        {
            get => _meals;
            set { _meals = value; }
        }

        public void CalculateDCR()
        {
            double dcr;
            switch(Activity)
            {
                case Activity.Low:
                    dcr = 1.2f;
                    break;
                case Activity.Normal:
                    dcr = 1.375f;
                    break;
                case Activity.Average:
                    dcr = 1.55f;
                    break;
                case Activity.High:
                    dcr = 1.725f;
                    break;
                default:
                    dcr = 0;
                    break;
            }
            dcr += (447.593 + (9.247 * Weight) + (3.098 * Height) - (4.330 * Age));
            DCR = dcr;
        }

        public Activity Activity
        {
            get => _activity;
            set { if ((int)value > 4 || (int)value < 1) _activity = 0;
                else _activity = value;
                CalculateDCR();
            }
        }
    }
    public enum Activity
    {
        Unknown,
        Low=1,
        Normal,
        Average,
        High
    }
}
