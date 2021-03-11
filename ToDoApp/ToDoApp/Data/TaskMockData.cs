using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    class TaskMockData
    {
        public static IList<ToDoTask> Tasks { get; private set; }
        public static IList<ToDoTask> AllTasks { get; private set; }

        static TaskMockData()
        {
            AllTasks = new List<ToDoTask>();

            AllTasks.Add(new ToDoTask
            {
                Id = 1,
                Description = "the dis 1",
                IsDone = false
            });
            AllTasks.Add(new ToDoTask
            {
                Id = 2,
                Description = "the dis 2",
                IsDone = false
            });
            AllTasks.Add(new ToDoTask
            {
                Id = 3,
                Description = "the dis 3",
                IsDone = false
            });
            AllTasks.Add(new ToDoTask
            {
                Id = 4,
                Description = "the dis 4",
                IsDone = false
            });
        }
        public static void AddTask(string description)
        {
            AllTasks.Add(new ToDoTask
            {
                Id = 4,
                Description = description,
                IsDone = false
            });
        }

        public static List<ToDoTask> LoadTasks()
        {
            Tasks = new List<ToDoTask>();
            foreach (var aTask in AllTasks)
            {
                if (aTask.IsDone == false)
                {
                    Tasks.Add(new ToDoTask
                    {
                        Id = aTask.Id,
                        Description = aTask.Description,
                        IsDone = false
                    });
                }
            }
            return (List<ToDoTask>)Tasks;
        }
        public static void TaskComplete(int Id)
        {
            //bool isFound = false;
            //Tasks = new List<ToDoTask>();
            foreach (var aTask in AllTasks)
            {
                if (aTask.Id == Id)
                {
                    //foreach (var item in AllTasks)
                    //{
                    //    if (item.Id == Id)
                    //    {
                    //        AllTasks.Remove(item);
                    //    }
                    //}
                    AllTasks.Remove(aTask);
                    break;
                }
                
            }

        }
    }
}
