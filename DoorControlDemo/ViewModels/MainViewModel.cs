using DoorControlDemo.Models;
using DoorControlDemo.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace DoorControlDemo.ViewModels
{
    public class MainViewModel
    {
        //Set the Commands
        public RelayCommand CreateBadgeCommand { get; private set; }
        public RelayCommand CreateDeviceCommand { get; private set; }
        public RelayCommand CreateUserCommand { get; private set; }

        // Link the commands to their respective actions and call them
        public MainViewModel() 
        {
            CreateBadgeCommand = new RelayCommand(CreateBadgeButtonClick);
            CreateDeviceCommand = new RelayCommand(CreateDeviceButtonClick);
            CreateUserCommand = new RelayCommand(CreateUserButtonClick);
        }  


        //Set the methods
        //Create the views and close the existing view upon opening the new View
        public void CreateBadgeButtonClick()
        {
            CreateBadgeView createBadgeView = new();
            createBadgeView.Show();
            //Application.Current.Windows[0]?.Close();
        }

        public void CreateDeviceButtonClick()
        {
            CreateDeviceView createDeviceView = new();
            createDeviceView.Show();
            Application.Current.Windows[0]?.Close();
        }

        public void CreateUserButtonClick()
        {
            CreateUserView createUserView = new();
            createUserView.Show();
            Application.Current.Windows[0]?.Close();
        }
    }
}
