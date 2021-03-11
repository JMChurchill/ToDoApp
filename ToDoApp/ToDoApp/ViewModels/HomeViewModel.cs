using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            RefreshCommand = new Command(ExecuteRefreshCommand);
            TaskCompleteCommand = new Command<ToDoTask>(TaskCompleted);
            OnPropertyChanged("Tasks");
        }
        public List<TaskGroup> Tasks { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public string NewDescription { get; set; }
        public ICommand RefreshCommand { get; }
        public Command<ToDoTask> TaskCompleteCommand { get; }
        public ICommand AddTaskCommand => new Command(() =>
        {
            TaskMockData.AddTask(NewDescription);
            Tasks = TaskMockData.LoadTasks();
            OnPropertyChanged("Tasks");
            ClearNewTask();
        });


        ToDoTask selectedTask;
        public ToDoTask SelectedTask
        {
            get => selectedTask;
            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Description,"Ok");
                    value = null;
                }
                selectedTask = value;
                OnPropertyChanged();
            }
        }

        async void TaskCompleted(ToDoTask task)
        {
            if (task == null)
            {
                return;
            }
            TaskMockData.TaskComplete(task.Id);
            Tasks = TaskMockData.LoadTasks();
            OnPropertyChanged("Tasks");
            //await Application.Current.MainPage.DisplayAlert("Selected", "Done", "Ok");
        }

        public void ClearNewTask()
        {
            NewDescription = "";
            OnPropertyChanged("NewDescription");
        }
        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        void ExecuteRefreshCommand()
        {
            Tasks = TaskMockData.LoadTasks();
            OnPropertyChanged("Tasks");

            // Stop refreshing
            IsRefreshing = false;
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
