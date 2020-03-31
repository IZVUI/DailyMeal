using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DailyMeal.Service
{           
        class ViewModel : INotifyPropertyChanged
        {
            //Тут общий функционал каждой VM. То есть свойство GoTo, Имя VM, ссылка на корень и конструктор
            public event PropertyChangedEventHandler PropertyChanged;
            private RelayCommand _command;
            public string Name { set; get; }
            public ViewChanger Root { set; get; }            

            public ViewModel(string name, ViewChanger root)
            {
                Name = name;
                Root = root;
            }


        public object GoTo
        {
            get
            {
                return _command ??
                    (_command = new RelayCommand(obj =>
                    {
                        string needOpen = obj as string;
                        Root.Current = Root.Such(needOpen);
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
