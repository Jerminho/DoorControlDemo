using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

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
            PortNumber = 8008;
            Type = "Access Controller";
        }


        //Properties

        [Key]
        public int DeviceId { get; set; }

        [Required(ErrorMessage = "IP Address is required")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "Device name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Device port is required.")]
        public int PortNumber { get; set; }

        [Required(ErrorMessage = "Device type is required.")]
        public string Type { get; set; }

        
        // Collection of users associated with the device
        public List<User> AssignedUsers { get; set; } = new List<User>();


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
        public void RemoveUser(User user)
        {
            if (AssignedUsers.Contains(user))
            {
                AssignedUsers.Remove(user);
            }
            else
            {
                // You can consider logging instead of throwing an exception
                MessageBox.Show($"Attempted to remove user {user.Name} from device {Name}, but the user was not assigned.");
            }
        }

    }
}
