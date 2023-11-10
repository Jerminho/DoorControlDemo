using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlDemo.Models
{
    internal class User
    {
        [Required(ErrorMessage = "Id is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required. Provide a name to this user.")]
        public string Name { get; set; }

        // Collection of badges for the user
        [Required(ErrorMessage = "Badge is required. Assign a badge to this user.")]
        public List<Badge> AssignedBadges { get; set; } = new List<Badge>();

        public string? Mail { get; set; }

        //A phone number can hold max 15 numbers
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
    }
}

