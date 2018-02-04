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
        
       

        [ArtPieceAuthorize]
        public ActionResult ListArtPieces()
        {
            

            ViewBag.Data = artData.ListArtPieces();
            return View();
        }
        [ArtPieceAuthorize]
        public ActionResult InsertArtPiece()
        {
            
            var query = new ArtPiecesData();
            ViewBag.Data = query.ListArtPieces();
            return View();
        }
        [ArtPieceAuthorize]
        [HttpPost]
        public ActionResult InsertArtPiece(ArtPieceModel artpiece)
        {
         
            artpiece.ArtPieceState = artData.GetArtPieceState("armazem");
            artPieceFactory.createArtPiece(artpiece.Name,artpiece.Description,artpiece.Dimension,artpiece.Author,artpiece.Year);
          return Redirect("ListArtPieces");
          
        }
        [ArtPieceAuthorize]
        public ActionResult RemovePiece(string artpieceId)
        {
            var pieceId = Int32.Parse(artpieceId); // Convert artpieceId from string to int
            
            artData.RemoveFromExhibition(pieceId);

           
            return Redirect("ListArtPieces");;
        }
        [ArtPieceAuthorize]
        public ActionResult SelectEventToAttachArtPice(string artpieceId)
        {
            var pieceId = Int32.Parse(artpieceId); // Convert artpieceId from string to int
            ViewBag.PieceSelected = artData.GetPieceByID(pieceId);
            ViewBag.ExhibitionsAccepted = eventData.GetListEvents("aceites");
            return View();
        }
        [ArtPieceAuthorize]
        public ActionResult SelectRoomToAttachArtPiece(string artpieceID, string eventId)
        {
            var getPieceId = Int32.Parse(artpieceID); // Convert artpieceId from string to int
            var getEventId = Int32.Parse(eventId); // Convert artpieceId from string to int
            ViewBag.ExhibitionSelected = eventData.GetEventById(getEventId);
            ViewBag.PieceSelected = artData.GetPieceByID(getPieceId);

            var roomList = new List<RoomMuseumViewModel>();
            foreach (var item in roomData.GetListRoomByEventId(getEventId))
            {
                RoomMuseumViewModel room = new RoomMuseumViewModel();
                room.Id = item.Id;
                room.Floor = item.Floor;
                room.Name = item.Name;
                room.SumRoomArtPieces = item.SumRoomArtPieces;
                room.MaxRoomArtPieces = item.MaxRoomArtPieces;
                roomList.Add(room);

            }
            ViewBag.RoomsExhibition = roomList;
            return View();
        }
        [ArtPieceAuthorize]
        public ActionResult AttachArtPiece(string artpieceID, string eventId, string roomId)
        {
            var getEventId = Int32.Parse(eventId); // Convert artpieceId from string to int
            var getRoomtId = Int32.Parse(roomId); // Convert roomID from string to int
            var getPieceId = Int32.Parse(artpieceID); // Convert artpieceId from string to int
            artData.AddPieceToRoom(getEventId,getRoomtId,getPieceId, "exposicao");

            return Redirect("ListArtPieces");
            
        }
    }
}