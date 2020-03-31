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

namespace DailyMeal.Service
{
    class Service : INotifyPropertyChanged
    {
        //Тут общий функционал каждой VM. То есть свойство GoTo, Имя VM, ссылка на корень и конструктор
        public event PropertyChangedEventHandler PropertyChanged;
        private RelayCommand _command;

        private Processes _processes;
        private int _checkedIndex;
        public Service()
        {
            _processes = new Processes();
            // Update();
        }

        public Processes Processes
        {
            get => _processes;
            set
            {
                _processes = value;
                OnPropertyChanged("Processes");
            }
        }

        public int CheckedIndex
        {
            get { return _checkedIndex; }
            set
            {
                if (value >= 0)
                {
                    _checkedIndex = value;
                }
                OnPropertyChanged("CheckedIndex");
                OnPropertyChanged("GetThreadsOfSelected");
            }
        }

        public List<string> GetThreadsOfSelected
        {
            get { return _processes.Procs[CheckedIndex].GetThreads; }
        }

        public ObservableCollection<MyProc> GetProcesses
        {
            get { return _processes.Procs; }
            set
            {
                Processes.Procs = value;
                OnPropertyChanged("GetProcesses");
            }
        }

        public string ProcsAmount
        {
            get { return "Amount of processes: " + Processes.Procs.Count.ToString(); }
        }

        private async void UpdatE()
        {
            while (true)
            {
                await Task.Delay(10000);
                Processes = new Processes();
                OnPropertyChanged("GetProcesses");
            }
        }

        public RelayCommand Update
        {
            get
            {
                return _command ??
                    (_command = new RelayCommand(obj =>
                    {
                        Processes = new Processes();
                        OnPropertyChanged("GetProcesses");
                        OnPropertyChanged("ProcsAmount");
                    }));
            }
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
