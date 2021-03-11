using System;
using System.Collections.Generic;
using ToDoApp.ViewModels;
using ToDoApp.Views;
using Xamarin.Forms;

namespace ToDoApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute("HomePage", typeof(HomePage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
