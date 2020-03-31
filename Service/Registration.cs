using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyMeal.Busines;

namespace DailyMeal.Service
{
    class Registration:ViewModel
    {
        public Registration(string name,ViewChanger root):base(name,root)
        {
            
        }

        public string Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        private RelayCommand _command;

        public object Registr
        {
            get
            {
                return _command ??
                    (_command = new RelayCommand(obj =>
                    {
                        Root.User = new User(Convert.ToInt32(Age), Convert.ToDouble(Height),Convert.ToDouble(Weight), 0);
                        string needOpen = obj as string;
                        Root.Current = Root.Such(needOpen);
                    }));
            }
        }
    }
}
