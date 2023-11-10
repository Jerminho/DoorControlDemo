using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlDemo.Models
{
    internal class Device

    {
        //Properties

        [Required(ErrorMessage = "IP Address is required")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "Device name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Device type is required.")]
        public string Type { get; set; }

        
        // Collection of users associated with the device
        public List<User> AssignedUsers { get; set; } = new List<User>();
    }
}
