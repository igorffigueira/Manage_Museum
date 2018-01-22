using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageMuseum.Models
{
    public class RoomMuseum
    {
        [Key]
        public int Id { get; set; }//number of the room
        public string Name { get; set; }
        public SpaceState SpaceState { get; set; } // State of the room free or busy
        public double Area { get; set; }
        public int Floor { get; set; }
        public Event Event { get; set; }

        public ICollection<ArtPiece> ArtPieces { get; set; }
    }
}