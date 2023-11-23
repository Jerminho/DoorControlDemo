using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlDemo.Models
{
    public class Badge
    {
        [Key]
        [Required(ErrorMessage = "BadgeId is required.")]
        public int BadgeId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        //Navigation Property
        public User User { get; set; }
    }
}

// BadgeId can just be  Id
// [ForeignKey("User")] is not required after setting up the navigation property, as the best way to set up relationships is in the DbContext 