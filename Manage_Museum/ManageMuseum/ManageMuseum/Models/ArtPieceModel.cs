using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseum.Models
{
    public class ArtPieceModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double Dimension { get; set; }

        public DateTime Year { get; set; }
        public string Author { get; set; }
        public RoomMuseum RoomMuseum { get; set; }
        public ArtPieceState ArtPieceState { get; set; }
    }
}