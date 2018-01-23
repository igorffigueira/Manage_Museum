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
            var pieceId = Int32.Parse(artpieceId); // Convert artpieceId from string to int
            var getPieceStorageState = db.ArtPieceStates.Include(d=>d.ArtPieces).First(s=>s.Name == "armazem");
            var pieceData = db.ArtPieces.Include(d=>d.RoomMuseum).Include(b=>b.ArtPieceState).First(d => d.Id == pieceId);  //Get data from one art piece by ID
            var getRoomId = db.ArtPieces.First(d=>d.Id == pieceId);
            var roomId = getRoomId.RoomMuseum.Id;
            var roomData = db.RoomMuseums.First(v => v.Id == roomId);  //Get data from one room by ID
            pieceData.ArtPieceState = getPieceStorageState;

            var getEventId = db.RoomMuseums.First(d => d.Id == roomId);
            var eventId = getEventId.Id;
            var eventData = db.Events.First(d => d.Id == eventId);  //Get data from one event by ID

                if (roomData.SumRoomArtPieces > 0)  // verify if number of pieces in the room is greater than 0
                {
                    roomData.SumRoomArtPieces += -1; // remove 1 art piece from 1 room
                }

                if (eventData.SumArtPieces > 0)   // verify if number of pieces in all rooms (in the event) is greater than 0
                {
                    eventData.SumArtPieces += -1;
                }

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