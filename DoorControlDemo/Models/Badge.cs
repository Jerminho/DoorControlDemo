using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControlDemo.Models
{
    internal class Badge
    {
        [Required(ErrorMessage = "BadgeId is required.")]
        public int BadgeId { get; set; }
    }
}
