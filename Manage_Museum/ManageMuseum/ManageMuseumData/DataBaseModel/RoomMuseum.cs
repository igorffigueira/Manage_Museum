using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.DataBaseModel
{
    public class RoomMuseum
    {
        [Key]
        public int Id { get; set; }//number of the room
        public string Name { get; set; }
        public SpaceState SpaceState { get; set; } // State of the room free or busy
        [DefaultValue(0)]
        public int SumRoomArtPieces { get; set; }
        public int MaxRoomArtPieces { get; set; }
        public int Floor { get; set; }
        public Events Event { get; set; }

        public ICollection<ArtPiece> ArtPieces { get; set; }
    }
}
