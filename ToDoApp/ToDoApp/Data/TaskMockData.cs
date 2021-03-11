using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    class TaskMockData
    {
        public static List<ToDoTask> TempTasks { get; private set; }
        public static List<ToDoTask> TaskData { get; private set; }
        
        public static List<ToDoTask> RemainingTasks { get; private set; }
        public static List<ToDoTask> CompletedTasks { get; private set; }
        public static List<List<ToDoTask>> AllTasks { get; private set; }

        public static List<TaskGroup> Tasks { get; private set; }


        static TaskMockData()
        {
            TaskData = new List<ToDoTask>();

            TaskData.Add(new ToDoTask
            {
                Id = 1,
                Description = "the dis 1",
                IsDone = false
            });
            TaskData.Add(new ToDoTask
            {
                Id = 2,
                Description = "the dis 2",
                IsDone = false
            });
            TaskData.Add(new ToDoTask
            {
                Id = 3,
                Description = "the dis 3",
                IsDone = false
            });
            TaskData.Add(new ToDoTask
            {
                Id = 4,
                Description = "the dis 4",
                IsDone = false
            });
        }
        public static void AddTask(string description)
        {
            TaskData.Add(new ToDoTask
            {
                Id = 4,
                Description = description,
                IsDone = false
            });
        }

        public static List<TaskGroup> LoadTasks()
        {
            RemainingTasks = new List<ToDoTask>();
            CompletedTasks = new List<ToDoTask>();
            Tasks = new List<TaskGroup>();
            foreach (var aTask in TaskData)
            {
                if (aTask.IsDone == false)
                {
                    RemainingTasks.Add(new ToDoTask
                    {
                        Id = aTask.Id,
                        Description = aTask.Description,
                        IsDone = false
                    });
                }
                if (aTask.IsDone == true)
                {
                    CompletedTasks.Add(new ToDoTask
                    {
                        Id = aTask.Id,
                        Description = aTask.Description,
                        IsDone = true
                    });
                }
            }
            //AllTasks.Add(RemainingTasks);
            //AllTasks.Add(CompletedTasks);
            if (RemainingTasks.Count > 0)
            {
                Tasks.Add(new TaskGroup("Remaining", RemainingTasks));

            }
            if (CompletedTasks.Count > 0)
            {
                Tasks.Add(new TaskGroup("Completed", CompletedTasks));
            }
            //Tasks.Add(new TaskGroup("Remaining", RemainingTasks));
            //Tasks.Add(new TaskGroup("Completed", CompletedTasks));
            return Tasks;
        }
        public static void TaskComplete(int Id)
        {
            foreach (var aTask in TaskData)
            {
                if (aTask.Id == Id)
                {
                    //CompletedTasks.Add(aTask);
                    aTask.IsDone = !aTask.IsDone;
                    break;
                }
            }
        }
    }
}
