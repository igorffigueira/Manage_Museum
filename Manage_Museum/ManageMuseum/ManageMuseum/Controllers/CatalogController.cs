using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;


namespace ManageMuseum.Controllers
{
    public class CatalogController : Controller
    {
        private OurContectDb db = new OurContectDb();
        // GET: Catalog
        public ActionResult ListArtPieces()
        {
            var query = db.ArtPieces.Include(d => d.ArtPieceState).Include(v => v.RoomMuseum).ToList();
            ViewBag.Data = query;
            return View();
        }

        public ActionResult InsertArtPiece()
        {
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