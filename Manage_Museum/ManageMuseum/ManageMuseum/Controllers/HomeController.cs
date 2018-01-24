using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;

namespace ManageMuseum.Controllers
{
    public class HomeController : Controller
    {
        private  OurContectDb db = new OurContectDb();

        public ActionResult Index()
        {
            EndandStartEvents();
            //EventoExibicaoTest();
            return RedirectToAction("Index1", "Home");

        }

        //public void EventoExibicaoTest()
        //{
        //    var evento = db.Events.Single(d=>d.Id == )
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void EndandStartEvents()
        {

            // Defines past events as closed, and the rooms associated with those events are again free
            var now = DateTime.Now.Date;
            var artPieceExposicaoState = db.ArtPieceStates.Include(d=>d.ArtPieces).Single(s=>s.Name == "exposicao");
            var getEventExhibitionState = db.EventStates.Include(d=>d.Events).Single(d => d.Name == "exibicao");
            var oldEventsOnExihibtion = db.Events.Include(d => d.EventState).Include(d=>d.OutSideSpaces).Include(d=>d.RoomMuseums).Include(d=>d.UserAccount).Include(d=>d.EventType).Where(d => d.EnDate < now && d.EventState.Id == getEventExhibitionState.Id).ToList();
            var getRoomFreeState = db.SpaceStates.Include(d=>d.RoomMuseums).First(d => d.Name == "livre"); // Estado de sala livre
            var getEventFinishedState = db.EventStates.Include(d=>d.Events).First(d => d.Name == "encerrado");
            foreach (var _event in oldEventsOnExihibtion)  // Coloca todos os eventos que o endDate já ocorreu, e que ainda se encontram em exibicao, com o estado encerrado
            {
                //RoomsMuseum
                var getEventRooms = db.RoomMuseums.Include(d => d.Event).Include(d=>d.ArtPieces).Include(d=>d.SpaceState).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _room in getEventRooms) // coloca todas as salas associadas ao evento nas condicoes acima, com o estado de salas livres
                {
                    _room.SumRoomArtPieces = 0;
                    _room.SpaceState = getRoomFreeState;
                    db.SaveChanges();
                }
                //OutSideSpaces
                var getEventOutSideSpaces = db.OutSideSpaces.Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _outSideSpace in getEventOutSideSpaces) // coloca todos os espaços exteriores associados ao evento nas condicoes acima, com o estado de espaços livres
                {
                    _outSideSpace.SpaceState = getRoomFreeState;
                    db.SaveChanges();
                }

                _event.SumArtPieces = 0;
                _event.EventState = getEventFinishedState;
                db.SaveChanges();
            }

            
            // Defines events in exhibition, and the rooms associated with those events busy
            var sumArtPiecesInRooms = 0;
            var sumArtPiecesInEvent = 0;
            var getEventAcceptedState = db.EventStates.Include(d=>d.Events).First(d => d.Name == "aceites");
            var NewEventsNotInExihibtion = db.Events.Include(d=>d.EventType).Include(d=>d.OutSideSpaces).Include(d=>d.UserAccount).Include(d => d.EventState).Where(d => d.StartDate <= now && d.EventState.Id == getEventAcceptedState.Id).ToList();
            var getRoomBusyState = db.SpaceStates.Include(d=>d.RoomMuseums).First(d => d.Name == "ocupada"); // Estado de sala ocupada
            foreach (var _event in NewEventsNotInExihibtion)  // Coloca todos os eventos que o StartDate é agora ou um pouco antes, e que ainda se encontram com o estado "aceites"
            {
                //RoomsMuseum
                var getEventsRooms = db.RoomMuseums.Include(d=>d.ArtPieces).Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _room_ in getEventsRooms) // coloca todas as salas associadas ao evento nas condicoes acima, com o estado de salas ocupado
                {
                    if (_room_.SumRoomArtPieces > 0)
                    {
                        var ArtpiecesInRoom = db.ArtPieces.Where(d => d.RoomMuseum.Id == _room_.Id).ToList();
                        foreach (var artpiece in ArtpiecesInRoom)
                        {
                            artpiece.ArtPieceState = artPieceExposicaoState;
                            _room_.SumRoomArtPieces += 1;
                            db.SaveChanges();
                        }
                    }
                    sumArtPiecesInRooms += _room_.SumRoomArtPieces;
                    //_room_.SpaceState = getRoomBusyState;
                    db.SaveChanges();
                }
                sumArtPiecesInEvent += sumArtPiecesInRooms;

                //OutSideSpaces
                var getEventOutSideSpaces = db.OutSideSpaces.Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _outSideSpace_ in getEventOutSideSpaces) // coloca todos os espaços exteriores associados ao evento nas condicoes acima, com o estado de espaços livres
                {
                    _outSideSpace_.SpaceState = getRoomBusyState;
                    db.SaveChanges();
                }
                if (getEventOutSideSpaces.Count > 0)
                {
                    _event.SumArtPieces = 0;
                    _event.EventState = getEventExhibitionState;
                    db.SaveChanges();
                }
                else if (sumArtPiecesInEvent > 0)
                {
                    var getSalasEvent = db.RoomMuseums.Include(d => d.ArtPieces).Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                    foreach (var salaEvent in getSalasEvent)
                    {
                        salaEvent.SpaceState = getRoomBusyState;
                        db.SaveChanges();
                    }
                    _event.SumArtPieces = sumArtPiecesInEvent;
                    _event.EventState = getEventExhibitionState;
                    db.SaveChanges();
                }
                else 
                {
                    var getSalas = db.RoomMuseums.Include(d => d.ArtPieces).Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                    foreach (var sala in getSalas)
                    {
                        sala.SpaceState.Name = "livre";
                        sala.SumRoomArtPieces = 0;
                        var getPecas = db.ArtPieces.Where(d => d.RoomMuseum.Id == sala.Id).ToList();
                        foreach (var peca in getPecas)
                        {
                            peca.ArtPieceState.Name = "armazem";
                            db.SaveChanges();
                        }
                        db.SaveChanges();
                    }
                    _event.SumArtPieces = 0;
                    _event.EventState = getEventFinishedState;
                    var TimeNow = DateTime.Now;
                    _event.EnDate = TimeNow;
                    db.SaveChanges();
                }
            }
        }

        public ActionResult Index1()
        {
            return RedirectToAction("ConfirmLogin", "Login");
        }
    }
}