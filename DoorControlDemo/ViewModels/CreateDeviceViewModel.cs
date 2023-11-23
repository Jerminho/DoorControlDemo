using DoorControlDemo.Data;
using DoorControlDemo.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace DoorControlDemo.ViewModels
{
    public class CreateDeviceViewModel : ViewModelBase
    {
        // Declare the database
        public readonly DoorControlDbContext dbContext;

        //Declare a MessageBoxDisplay
        private MessageBoxDisplay _messageBoxDisplay = new();

        // Set the constructor
        public CreateDeviceViewModel(DoorControlDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            CreateDeviceCommand = new RelayCommand(/*CreateDevice*/CreateDeviceButton);
        }

        // Declare the Create User Command
        public ICommand CreateDeviceCommand { get; }

        // Declare a private field for the new value
        string _deviceName;

        // Set its new value
        public string DeviceName
        {
            get => _deviceName;
            set
            {
                _deviceName = value;
                OnPropertyChanged(nameof(DeviceName));
            }
        }

        string _ipAddress;
        public string IpAddress
        {
            get => _ipAddress;
            set
            {
                _ipAddress = value;
                OnPropertyChanged(nameof(IpAddress));
            }
        }

        string _port;
        public string Port
        {
            get => _port;
            set
            {
                _port = value;
                OnPropertyChanged(nameof(Port));
            }
        }

        // Create the method to be used as command
        // Use the data context to add the new user to the database

        // To be refactored
        //public void CreateDevice()
        //{
        //    // Check if required fields are empty
        //    if (string.IsNullOrWhiteSpace(DeviceName))
        //    {
        //        MessageBox.Show("Please fill in a name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return; // Stop the user creation process
        //    }
        //    // Check if required fields are empty
        //    if (string.IsNullOrWhiteSpace(IpAddress))
        //    {
        //        MessageBox.Show("Please fill in a valid Ip-Address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return; // Stop the user creation process
        //    }
        //    // Check if required fields are empty
        //    if (Port == 0) // You can adjust this condition based on your specific requirements
        //    {
        //        MessageBox.Show($"Please fill in a valid Port number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return; // Validation failed
        //    }

        //    // Check if a device with the same properties already exists in the database
        //    if (dbContext.Devices.Any(d => d.Name == DeviceName && d.Ip == IpAddress && d.PortNumber == Port))
        //    {
        //        MessageBox.Show($"Device with the same properties already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return; // Stop the user creation process
        //    }

        //    // Implement logic to create a device, perhaps by calling a method in your model
        //    Device newDevice = new Device
        //    {
        //        Name = DeviceName,
        //        Ip = IpAddress,
        //        PortNumber = Port
        //    };


            //// Add the device to the context
            //dbContext.Devices.Add(newDevice);

            //// Save changes to the database
            //dbContext.SaveChanges();

            //// Add additional logic as needed, e.g., validation, interaction with your data context
            //// Construct a message string with information about all devices
            //StringBuilder devicesInfo = new StringBuilder("Devices in the database:\n");

            //foreach (var device in dbContext.Devices)
            //{
            //    devicesInfo.AppendLine($"Name: {device.Name}, IP: {device.Ip}, Port: {device.PortNumber}");
            //}

            //// Display the message with device information
            //MessageBox.Show($"Device {newDevice.Name} created successfully!\n\n{devicesInfo.ToString()}");
        //}
        //Set a method to create a device
        public void CreateDeviceButton()
        {
            //Create an instance of a device
            Device device = new();

            // Check if a device with the same properties already exists in the database
            if ((string.IsNullOrEmpty(_deviceName)  || string.IsNullOrEmpty(_ipAddress) || string.IsNullOrEmpty(_port)))
            {
                if(dbContext.Devices.Any(d => d.Name == "Default Access Device" && d.Ip == "192.168.1.1" && d.PortNumber == "8008"))
                {
                    _messageBoxDisplay.DisplayMessage("Device with the same properties already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (dbContext.Devices.Any(d => d.Name == _deviceName /*&& d.Ip == _ipAddress && d.PortNumber == _port*/))
            {
                _messageBoxDisplay.DisplayMessage("Device with the same Name already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var createdDevice = device.CreateDevice(_port, _ipAddress, _deviceName);

            
            if (createdDevice is null)
            {
                _messageBoxDisplay.DisplayMessage(device.Message);
                return;
            }

            // Add the device to the context
            dbContext.Devices.Add(createdDevice);

            // Save changes to the database
            dbContext.SaveChanges();

            // Add additional logic as needed, e.g., validation, interaction with your data context
            // Construct a message string with information about all devices
            StringBuilder devicesInfo = new StringBuilder("Devices in the database:\n");

            foreach (var dev in dbContext.Devices)
            {
                devicesInfo.AppendLine($"Name: {dev.Name}, IP: {dev.Ip}, Port: {dev.PortNumber}");
            }

            // Display the message with device information
            _messageBoxDisplay.DisplayMessage($"Device {createdDevice.Name} created successfully!\n\n{devicesInfo.ToString()}");
        }
    }
}
