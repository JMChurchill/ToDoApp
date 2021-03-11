using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Models
{
    public class TaskGroup : List<ToDoTask>
    {
        public string Name { get; private set; }

        public TaskGroup(string name, List<ToDoTask> tasks) : base(tasks)
        {
            Name = name;
        }
    }
}
