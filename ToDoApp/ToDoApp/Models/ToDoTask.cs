using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ToDoApp.Data;
using ToDoApp.ViewModels;
using ToDoApp.Views;
using Xamarin.Forms;

namespace ToDoApp.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public ToDoTask()
        {
        }
    }
}
