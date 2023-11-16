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
