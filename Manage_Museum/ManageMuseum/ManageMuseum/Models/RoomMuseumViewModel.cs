using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageMuseum.Models
{
    public class RoomMuseumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SumRoomArtPieces { get; set; }
        public int MaxRoomArtPieces { get; set; }
        public int Floor { get; set; }
    }
}