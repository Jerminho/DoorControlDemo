using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoorControlDemo.Models
{
    internal class User
    {
        [Key]
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

        [ForeignKey("Device")]
        public int DeviceId { get; set; }

        // Navigation Property
        public Device? Device { get; set; }


        // Methods

        // Add badge to user
        public void AddBadge(Badge badge)
        {
            if (!AssignedBadges.Contains(badge)){
                AssignedBadges.Add(badge);
            }
            else
            {
                throw new InvalidOperationException("Badge has already been assigned.");

            }
        }


        // Remove badge from user
        public void RemoveBadge(Badge badge)
        {
            if (AssignedBadges.Contains(badge))
            {
                AssignedBadges.Remove(badge);
            }
            else
            {
                MessageBox.Show("Badge cannot be removed. It was never assigned.");

            }
        }

    }
}

