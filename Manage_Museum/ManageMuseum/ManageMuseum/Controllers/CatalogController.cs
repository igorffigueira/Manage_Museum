using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;
using ManageMuseumData.DataBaseModel;
using ManageMuseumData.Factory;
using ManageMuseumData.GetData;


namespace ManageMuseum.Controllers
{
    public class CatalogController : Controller
    {
        
        private ArtPiecesData artData = new ArtPiecesData();
        private RoomMuseumData roomData = new RoomMuseumData();
        private EventData eventData = new EventData();


        private ArtPieceFactory artPieceFactory = new CreateArtPiece();
        
       // private OurContectDb db = new OurContectDb();

        [ArtPieceAuthorize]
        public ActionResult ListArtPieces()
        {
            //var query = db.ArtPieces.Include(d => d.ArtPieceState).Include(v => v.RoomMuseum).ToList();

            ViewBag.Data = artData.ListArtPieces();
            return View();
        }
        [ArtPieceAuthorize]
        public ActionResult InsertArtPiece()
        {
            //var query = db.ArtPieces.Include(d => d.ArtPieceState).Include(v => v.RoomMuseum).ToList();
            //ViewBag.Data = query;
            var query = new ArtPiecesData();
            ViewBag.Data = query.ListArtPieces();
            return View();
        }
        [ArtPieceAuthorize]
        [HttpPost]
        public ActionResult InsertArtPiece(ArtPiece artpiece)
        {
            //var estadoPeca = db.ArtPieceStates.Include(d => d.ArtPieces).First(d => d.Name == "armazem");
            artpiece.ArtPieceState = artData.GetArtPieceState("armazem");
            
           // var newArtPiece = new ArtPiece() { Name = artpiece.Name, Description = artpiece.Description, Dimension = artpiece.Dimension, RoomMuseum = null, Year = artpiece.Year, Author = artpiece.Author, ArtPieceState = artpiece.ArtPieceState};
            artPieceFactory.createArtPiece(artpiece.Name,artpiece.Description,artpiece.Dimension,artpiece.Author,artpiece.Year);
          //db.ArtPieces.Add(newArtPiece);
          //db.SaveChanges();
          return Redirect("ListArtPieces");
          
        }
        [ArtPieceAuthorize]
        public ActionResult RemovePiece(string artpieceId)
        {
            var pieceId = Int32.Parse(artpieceId); // Convert artpieceId from string to int
            //var getPieceStorageState = db.ArtPieceStates.Include(d => d.ArtPieces).First(s => s.Name == "armazem");
            //var pieceData = db.ArtPieces.Include(d => d.RoomMuseum).Include(b => b.ArtPieceState).First(d => d.Id == pieceId);  //Get data from one art piece by ID
            //var getRoomId = pieceData.RoomMuseum.Id;
            //var roomData = db.RoomMuseums.Include(d => d.Event).First(v => v.Id == getRoomId);  //Get data from one room by ID
            //var eventId = roomData.Event.Id;
            //var eventData = db.Events.First(d => d.Id == eventId);  //Get data from one event by ID

            //pieceData.ArtPieceState = getPieceStorageState;
            //pieceData.RoomMuseum = null;
            //if (roomData.SumRoomArtPieces > 0)  // verify if number of pieces in the room is greater than 0
            //{
            //    roomData.SumRoomArtPieces -= 1; // remove 1 art piece from 1 room

            //    if (eventData.SumArtPieces > 0)   // verify if number of pieces in all rooms (in the event) is greater than 0
            //    {
            //        eventData.SumArtPieces -= 1;
            //    }
            //}

            //db.SaveChanges();
            artData.RemoveFromExhibition(pieceId);

           
            return Redirect("ListArtPieces");;
        }
        [ArtPieceAuthorize]
        public ActionResult SelectEventToAttachArtPice(string artpieceId)
        {
            var pieceId = Int32.Parse(artpieceId); // Convert artpieceId from string to int
            //var getPieceDataFromId = db.ArtPieces.Include(d => d.ArtPieceState).Include(d => d.RoomMuseum).First(d => d.Id == pieceId);
            ViewBag.PieceSelected = artData.GetPieceByID(pieceId);


            //var getExhibitionAcceptedState = eventData.GetEventState("aceites");
            //var ExhibitionAccepted = db.Events.Include(d=>d.EventType).Include(v=>v.UserAccount).Include(v=>v.OutSideSpaces).Include(d=>d.EventState).Where(d=>d.EventState.Name == getExhibitionAcceptedState.Name).ToList();
            ViewBag.ExhibitionsAccepted = eventData.GetListEvents("aceites");
            return View();
        }
        [ArtPieceAuthorize]
        public ActionResult SelectRoomToAttachArtPiece(string artpieceID, string eventId)
        {
            var getPieceId = Int32.Parse(artpieceID); // Convert artpieceId from string to int
            //var getPieceDataFromId = db.ArtPieces.Include(d=>d.RoomMuseum).Include(d=>d.ArtPieceState).First(d => d.Id == getPieceId);
            var getEventId = Int32.Parse(eventId); // Convert artpieceId from string to int
            //var getSelectedEventData = db.Events.Include(d=>d.EventState).Include(d=>d.RoomMuseums).Include(d=>d.EventType).Include(d=>d.OutSideSpaces).Include(v=>v.UserAccount).First(d => d.Id == getEventId);
            //var getRoomsEventSelected = db.RoomMuseums.Include(v=>v.ArtPieces).Include(v=>v.SpaceState).Where(d => d.Event.Id == getEventId).ToList();
            //ViewBag.ExhibitionSelected = getSelectedEventData;
            //ViewBag.PieceSelected = getPieceDataFromId;
            //ViewBag.RoomsExhibition = getRoomsEventSelected;


            ViewBag.ExhibitionSelected = eventData.GetEventById(getEventId);
            ViewBag.PieceSelected = artData.GetPieceByID(getPieceId);
            ViewBag.RoomsExhibition = roomData.GetListRoomByEventId(getEventId);
            return View();
        }
        [ArtPieceAuthorize]
        public ActionResult AttachArtPiece(string artpieceID, string eventId, string roomId)
        {
            var getEventId = Int32.Parse(eventId); // Convert artpieceId from string to int
            var getRoomtId = Int32.Parse(roomId); // Convert roomID from string to int
            var getPieceId = Int32.Parse(artpieceID); // Convert artpieceId from string to int

            //var getSelectedEventData = db.Events.Include(d => d.EventState).Include(d => d.RoomMuseums).Include(d => d.EventType).Include(d => d.OutSideSpaces).Include(v => v.UserAccount).Single(d => d.Id == getEventId);
            
            //var getPieceDataFromId = db.ArtPieces.Include(d => d.RoomMuseum).Include(d => d.ArtPieceState).First(d => d.Id == getPieceId);
    
            //var getSelectedRoomData = db.RoomMuseums.Include(d=>d.ArtPieces).Include(d=>d.SpaceState).First(d => d.Id == getRoomtId);

            //var getPieceStorageState = db.ArtPieceStates.Include(d => d.ArtPieces).First(s => s.Name == "exposicao");  //Obter estado de peça em exibição

            //    getPieceDataFromId.ArtPieceState = getPieceStorageState;

            //        getPieceDataFromId.RoomMuseum = getSelectedRoomData;
            //        getPieceDataFromId.RoomMuseum.ArtPieces.Add(getPieceDataFromId);
            //        getSelectedRoomData.SumRoomArtPieces += 1;  // Incrementar 1 peça à soma de peças na sala
            //        getSelectedEventData.SumArtPieces += 1;  // Incrementar 1 peça à soma de peças no evento
          
            //db.SaveChanges();
            artData.AddPieceToRoom(getEventId,getRoomtId,getPieceId, "exposicao");

            return Redirect("ListArtPieces");
            
        }
    }
}