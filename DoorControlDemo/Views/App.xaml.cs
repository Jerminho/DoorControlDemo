using DoorControlDemo.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DoorControlDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Add the main method below in case it's missing

        [STAThread]
        public static void Main()
        {
            var app = new App();
            var createUserView = new CreateUserView(); // Replace with the actual main window of your application
            app.Run(createUserView);
        }
    }
}
