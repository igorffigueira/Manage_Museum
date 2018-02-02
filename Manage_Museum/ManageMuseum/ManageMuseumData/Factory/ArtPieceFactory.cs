using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.Factory
{
    public abstract class ArtPieceFactory
    {
        public AArtPiece at { get; set; }
        public abstract void createArtPiece(string name, string description, double dimension, string author, DateTime year);
    }
}
