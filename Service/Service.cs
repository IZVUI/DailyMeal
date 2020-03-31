using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Diagnostics;
using System.Collections.ObjectModel;
using DailyMeal.Busines;
using DailyMeal.DataAccess;

namespace DailyMeal.Service
{
    class Service : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand _command;
        protected object _current;
        protected List<ViewModel> _viewModels;
        protected User _user;
        protected DAO _dao;
        protected ObservableCollection<Activity> _activities;

        public Service()
        {
            _viewModels = new List<ViewModel>();
            DAO = new DAO();
            _user = new User();
            CreateActivityList();
        }       

        public DAO DAO
        {
            get => _dao;
            set { _dao = value; }
        }

      
        public ObservableCollection<Activity> Activities
        {
            get => _activities;
            set { }
        }
             
        public User User
        {
            get => _user;
            set { _user = value; }
        }
        public ViewModel Such(string name)
        {
            for (int i = 0; i < _viewModels.Count; i++)
            {
                if (_viewModels[i].Name == name) return _viewModels[i];
            }            
            return null;
        }

        public void CreateActivityList()
        {
            _activities = new ObservableCollection<Activity>();
            _activities.Add(Activity.Low);
            _activities.Add(Activity.Normal);
            _activities.Add(Activity.Average);
            _activities.Add(Activity.High);
        }

        public RelayCommand Exit
        {
            get
            {
                return _command ??
                    (_command = new RelayCommand(obj =>
                    {
                        System.Windows.Application.Current.Shutdown();
                    }));
            }
        }
       
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
