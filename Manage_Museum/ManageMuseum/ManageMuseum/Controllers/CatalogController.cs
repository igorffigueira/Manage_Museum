using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;


namespace ManageMuseum.Controllers
{
    public class CatalogController : Controller
    {
        
        
        private OurContectDb db = new OurContectDb();
        
        
        public ActionResult ListArtPieces()
        {
            var query = db.ArtPieces.Include(d => d.ArtPieceState).Include(v => v.RoomMuseum).ToList();
            ViewBag.Data = query;
            return View();
        }
        [HttpPost]
        public ActionResult InsertArtPiece(ArtPiece artpiece)
        {
            var estadoPeca = db.ArtPieceStates.Include(d=>d.ArtPieces).First(d => d.Name == "armazem");
            artpiece.ArtPieceState = estadoPeca;
            var roomDefault = db.RoomMuseums.Include(d=>d.Event).Include(d=>d.SpaceState).First();
            artpiece.RoomMuseum = roomDefault;
            var newArtPiece = new ArtPiece() { Name = artpiece.Name, Description = artpiece.Description, Dimension = artpiece.Dimension, RoomMuseum = artpiece.RoomMuseum, Year = artpiece.Year, Author = artpiece.Author, ArtPieceState = artpiece.ArtPieceState};

            db.ArtPieces.Add(newArtPiece);
            db.SaveChanges();
            return Redirect("ListArtPieces");
        }

        public ActionResult InsertArtPiece()
        {
            var query = db.ArtPieces.Include(d => d.ArtPieceState).Include(v => v.RoomMuseum).ToList();
            ViewBag.Data = query;
            return View();
        }

        public ActionResult RemovePiece(string artpieceId)
        {
            var pieceStorageState = db.ArtPieceStates.Single(s=>s.Name == "armazem");
            var pieceId = Int32.Parse(artpieceId);
            var query = db.ArtPieces.Single(d => d.Id == pieceId);
            query.ArtPieceState = pieceStorageState;
            db.SaveChanges();
            return Redirect("ListArtPieces");;
        }

        public ActionResult AttachPiece(string artpieceId)
        {
            // Já temos aqui o id da peça a adicionar a um evento
            return Content("Insert art pieces to the event");
        }
    }
}