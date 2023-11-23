using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DoorControlDemo.Models
{
    public class Device
    {
        // Constructor
        public Device()
        {
            // Set default values if not provided
            Name = "Default Access Device";
            Ip = "192.168.1.1";
            PortNumber = 8008.ToString();
            Type = "Access Controller";
        }


        //Properties
        //Required is not needed here since the properties are nullable...

        [Key]
        public int DeviceId { get; set; }

        //[Required(ErrorMessage = "IP Address is required")]
        public string? Ip { get; set; }

        //[Required(ErrorMessage = "Device name is required.")]
        public string? Name { get; set; }

        //[Required(ErrorMessage = "Device port is required.")]
        public string? PortNumber { get; set; }

        //[Required(ErrorMessage = "Device type is required.")]
        public string Type { get; set; }

        
        // Collection of users associated with the device
        public List<User> AssignedUsers { get; set; } = new List<User>();

        // Set the message in case one must be given

        private string? _message;
        public string? Message { get => _message; set => _message = value; }


        // Methods

        // Add user to device
        public void AddUser(User user)
        {
            // If the user is not yet assigned to the device, add.
            if (!AssignedUsers.Contains(user))
            {
                AssignedUsers.Add(user);
            }
            else
            {
                // User already exists, throw an exception or log a message
                throw new InvalidOperationException("User already exists in the device.");
            }

        }

        // Remove user from device
        public void RemoveUser(User user )
        {  
            if (AssignedUsers.Contains(user))
            {
                AssignedUsers.Remove(user);
            }
            else
            {
                // You can consider logging instead of throwing an exception
                _message = $"Attempted to remove user {user.Name} from device {Name}, but the user was not assigned.";
                //MessageBox.Show($"Attempted to remove user {user.Name} from device {Name}, but the user was not assigned.");
            }
        }

        public Device CreateDevice(string? portNumber, string? ipAddress, string? deviceName)
        {
            if (portNumber is null || ipAddress is null || deviceName is null)
            {
                deviceName = Name;
                ipAddress = Ip;
                portNumber = PortNumber;
                
                //if (portNumber.GetType() != typeof(int) || ipAddress.GetType() != typeof(string) || deviceName.GetType() != typeof(string))
                //{
                //    _message = "One or more of the entered values is not of the correct data type!";
                //}
            }

            try
            {
                Convert.ToInt32(portNumber);
            }
            catch 
            {
                _message = "One or more of the entered values is not of the correct data type!";
                return null;
            }


            Device device = new Device
            {

                Name = deviceName,
                Ip = ipAddress,
                PortNumber = portNumber
            };
            return device;  
        }
    }
}

//DeviceId can just be Id
