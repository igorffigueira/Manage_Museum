using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.Factory;

namespace ManageMuseumData.DataBaseModel
{
    public class ArtPiece : AArtPiece
    {
       public RoomMuseum RoomMuseum { get; set; }
        public ArtPieceState ArtPieceState { get; set; }
    }
}
