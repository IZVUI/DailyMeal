using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeal.Service
{
    class ViewChanger:Service
    {
        

        public ViewChanger()
        {            
            
            _viewModels.Add(new HomeView("HomeView", this));
           
            Current = _viewModels[0];
        }        
        
        public object Current
        {
            get => _current;
            set { _current = value;
                OnPropertyChanged("Current");
            }
        }
               
    }
}
