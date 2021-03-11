using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ToDoApp.Data;
using ToDoApp.Models;
using Xamarin.Forms;

namespace ToDoApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public HomeViewModel()
        {
            Tasks = TaskMockData.LoadTasks();
            OnPropertyChanged("Tasks");
        }
        public Command<int> tTaskCompleteCommand { get; }
        public List<ToDoTask> Tasks { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public string NewDescription { get; set; }

        public ICommand AddTaskCommand => new Command(() =>
        {
            TaskMockData.AddTask(NewDescription);
            Tasks = TaskMockData.LoadTasks();
            OnPropertyChanged("Tasks");
            ClearNewTask();
        });

        public ICommand TaskCompleteCommand => new Command(() =>
        {
            TaskMockData.TaskComplete(Id);
            Tasks = TaskMockData.LoadTasks();
            OnPropertyChanged("Tasks");
        });

        public void TaskComplete(int Id)
        {
            TaskMockData.TaskComplete(Id);
            Tasks = TaskMockData.LoadTasks();
            OnPropertyChanged("Tasks");
        }

        public void ClearNewTask()
        {
            NewDescription = "";
            OnPropertyChanged("NewDescription");
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
