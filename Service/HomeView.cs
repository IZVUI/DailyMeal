using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyMeal.DataAccess;
using DailyMeal.Busines;
using System.Text.RegularExpressions;

namespace DailyMeal.Service
{
    class HomeView:ViewModel
    {
        public HomeView(string name,ViewChanger root):base(name,root)
        {
            _activityIndex = 0;
        }

        private ObservableCollection<Category> _categories;
        private int _activityIndex;
        private int _mealsIndex;
        private int _categoryIndex;
        private int _productIndex, _mealProductIndex;
        private int _gramsValue;

        private void Fill()
        {
            _categories = new ObservableCollection<Category>();
            foreach (Category category in Root.DAO.CategoryDAO.GetAllCategories())
            {
                _categories.Add(category);
            }
        }

        public ObservableCollection<Meal> Meals
        {
            get => Root.User.Meals;
            set
            {
                Root.User.Meals = value;
                OnPropertyChanged("Meals");
            }
        }

        public int GramsValue
        {
            get => _gramsValue;
            set
            {
                if (Regex.IsMatch(value.ToString(), "\\D"))
                {
                    value = 100;
                }
                _gramsValue = value;
                OnPropertyChanged("GramsValue");
            }
            }

        public int MealsIndex
        {
            get => _mealsIndex;
            set
            {
                _mealsIndex = value;
                OnPropertyChanged("MealsIndex");
                OnPropertyChanged("MealProducts");
            }
        }
        public int CategoryIndex
        {
            get => _categoryIndex;
            set
            {
                _categoryIndex = value;
                OnPropertyChanged("CategoryIndex");
                OnPropertyChanged("Products");
            }
        }

        public int ProductIndex
        {
            get => _productIndex;
            set
            {
                _productIndex = value;
                OnPropertyChanged("ProductIndex");
            }
        }

        public int MealProductIndex
        {
            get => _mealProductIndex;
            set
            {
                _mealProductIndex = value;
                OnPropertyChanged("MealProductIndex");
            }
        }

        public List<Product> Products
        {
            get => new List<Product>(Categories[CategoryIndex].Product);
            set {
                Categories[CategoryIndex].Product = value.ToArray();
                OnPropertyChanged("Products");
            }
        }

        public ObservableCollection<Product> MealProducts
        {
            get
            {
                if(MealsIndex>=0&&MealsIndex<Meals.Count)
                return new ObservableCollection<Product>(Meals[MealsIndex].Products);
                return null;
            }
            set { //Meals[MealsIndex].Products = value;
                OnPropertyChanged("MealProducts");
                OnPropertyChanged("Meals");
            }
        }


        public List<Product> MProducts
        {
            get => Meals[MealsIndex].Products;
            set { Meals[MealsIndex].Products = value;
                OnPropertyChanged("MProducts");
                OnPropertyChanged("Meals");
            }
        }

        public string Age
        {
            get
            {
                if (Root.User==null) return "0";
                return Root.User.Age.ToString();
            }
            set { Root.User.Age = Convert.ToInt32(value);
                OnPropertyChanged("Age");
                OnPropertyChanged("DCR");
            }
        }

        public string Height
        {
            get
            {
                if (Root.User == null) return "0";
                return Root.User.Height.ToString();
            }
            set { Root.User.Height = Convert.ToDouble(value);
                OnPropertyChanged("Height");
                OnPropertyChanged("DCR");
            }
        }

        public string Weight
        {
            get
            {
                if (Root.User == null) return "0";
                return Root.User.Weight.ToString();
            }
            set { Root.User.Weight = Convert.ToDouble(value);
                OnPropertyChanged("Weight");
                OnPropertyChanged("DCR");
            }
        }

        /*public int ActivityIndex
        {
            get { return _activityIndex; }
            set { _activityIndex = value;
                OnPropertyChanged("ActivityIndex");
                OnPropertyChanged("Activity");
            }
        }*/

        public Busines.Activity Activity
        {
            get => Root.User.Activity;
            set { Root.User.Activity = value;
                OnPropertyChanged("Activity");
                OnPropertyChanged("DCR");
            }
        }

        public ObservableCollection<Busines.Activity> Activities
        {
            get => Root.Activities;
            set { }
        }

        public string DCR
        {
            get => Root.User.DCR.ToString();           
            set { Root.User.CalculateDCR(); }
        }
        public ObservableCollection<Category> Categories
        {
            get { if (_categories == null)
                {
                    Fill();
                }
                return _categories; }
            set { _categories = value; }
        }

        public bool AddMealTextBoxFocus
        {
            get;set;
        }

        public string AddMealTextBoxVisibility
        {
            get
            {
                if (AddMealTextBoxFocus) return "Visible";
                return "Hidden";
            }
            set { }
        }

        public string AddMealTextBoxText
        {
            get;set;
        }


        public RelayCommand Command
        {
            get
            {
                return Root._command ??
                    (Root._command = new RelayCommand(obj =>
                    {
                        switch(obj as string)
                        {
                            case "AddProduct":
                                if (!Meals[MealsIndex].Products.Contains(Categories[CategoryIndex].Product[ProductIndex]))
                                    Meals[MealsIndex].Products.Add(Categories[CategoryIndex].Product[ProductIndex]);
                                OnPropertyChanged("MealProducts");
                                OnPropertyChanged("Meals");
                                break;
                            case "RemoveProduct":
                                if (Meals[MealsIndex].Products.Count != 0)
                                {
                                    Meals[MealsIndex].Products.RemoveAt(MealProductIndex);
                                    if (MealProductIndex <= 0) MealProductIndex = 1;
                                    else MealProductIndex--;
                                }
                                OnPropertyChanged("MealProducts");
                                OnPropertyChanged("Meals");
                                break;
                            case "RemoveMeal":
                                if(Meals.Count!=0)
                                Meals.RemoveAt(MealsIndex);
                                if (MealsIndex < 0) MealsIndex = 0;
                                OnPropertyChanged("MealsIndex");
                                OnPropertyChanged("MealProducts");
                                OnPropertyChanged("Meals");
                                break;
                            case "AddMeal":
                                if (!AddMealTextBoxFocus)
                                {
                                    AddMealTextBoxFocus = true;
                                    OnPropertyChanged("AddMealTextBoxFocus");
                                    OnPropertyChanged("AddMealTextBoxVisibility");
                                    }
                                else
                                {
                                if (AddMealTextBoxText!=null&&AddMealTextBoxText!=""&&AddMealTextBoxText!=" ")
                                    {
                                        Meals.Add(new Meal(AddMealTextBoxText));
                                        OnPropertyChanged("Meals");
                                    }                                    
                                    AddMealTextBoxFocus = false;
                                    AddMealTextBoxText = "";
                                    OnPropertyChanged("AddMealTextBoxText");
                                    OnPropertyChanged("AddMealTextBoxFocus");
                                    OnPropertyChanged("AddMealTextBoxVisibility");
                                }
                                break;
                        }
                        
                    }));
            }
        }
       

        


    }
}
