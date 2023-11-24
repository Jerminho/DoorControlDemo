using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoorControlDemo.Models
{
    internal class ControlDoor
    {
        // Declare the properties
        public int Id { get; set; }


        // Set methods
        public ControlDoor createDoor(int id)
        {
            // Create an instance of the Class, set properties and return
            ControlDoor controlDoor = new ControlDoor
            {
                Id = id,
            };
            return controlDoor;
        }
    }
}
