using DoorControlDemo.ViewModels;
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
            CHCNetSDK.NET_DVR_Init();
            // Test the mainWindow
            if (CHCNetSDK.NET_DVR_Init() == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            else
            {
                MessageBox.Show("NET_DVR_Init Succes!");
            }
            var app = new App();
            var mainWindow = new MainWindow(); // Replace with the actual main window of your application
            app.Run(mainWindow);
        }
    }
}
