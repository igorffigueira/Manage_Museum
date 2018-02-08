using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.Factory
{
    public class CreateArtPiece : ArtPieceFactory
    {
        private DbAccess db = new DbAccess();

        /// <summary>
        /// metodo responsavel pela criação das peças
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="dimension"></param>
        /// <param name="author"></param>
        /// <param name="year"></param>
        public override void createArtPiece(string name, string description, double dimension, string author, DateTime year)
        {
            var artState = db.ArtPieceStates.Single(d => d.Name == "armazem");

            at = new ArtPiece() { Name = name, ArtPieceState = artState, Author = author, Description = description, Dimension = dimension, Year = year, RoomMuseum = null };
            Insert();
        }

        public void Insert()
        {
            db.ArtPieces.Add((ArtPiece)at);
            db.SaveChanges();
        }
    }
}
