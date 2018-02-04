using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ManageMuseum.Models
{
    public class SpaceViewModel
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Capacity of a room is Required")]
        [Range(1, 100, ErrorMessage = "The number must between 1 and 100")]
        public int MaxRoomArtPieces { get; set; }
    }
}