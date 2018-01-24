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
            return RedirectToAction("ConfirmLogin", "Login");
        }

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
            var getEventExhibitionState = db.EventStates.First(d => d.Name == "exibicao");
            var oldEventsOnExihibtion = db.Events.Include(d => d.EventState).Where(d => d.EnDate < now && d.EventState.Id == getEventExhibitionState.Id).ToList();
            var getRoomFreeState = db.SpaceStates.First(d => d.Name == "livre"); // Estado de sala livre
            var getEventFinishedState = db.EventStates.First(d => d.Name == "encerrado");
            foreach (var _event in oldEventsOnExihibtion)  // Coloca todos os eventos que o endDate já ocorreu, e que ainda se encontram em exibicao, com o estado encerrado
            {
                //RoomsMuseum
                var getEventRooms = db.RoomMuseums.Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _room in getEventRooms) // coloca todas as salas associadas ao evento nas condicoes acima, com o estado de salas livres
                {
                    _room.SumRoomArtPieces = 0;
                    _room.SpaceState = getRoomFreeState;
                }
                //OutSideSpaces
                var getEventOutSideSpaces = db.OutSideSpaces.Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _outSideSpace in getEventOutSideSpaces) // coloca todos os espaços exteriores associados ao evento nas condicoes acima, com o estado de espaços livres
                {
                    _outSideSpace.SpaceState = getRoomFreeState;
                }

                _event.SumArtPieces = 0;
                _event.EventState = getEventFinishedState;

                db.SaveChanges();
            }

            var SumArtpiecesInAllRoomsOfEvent = 0;

            // Defines events in exhibition, and the rooms associated with those events busy
            var getEventAcceptedState = db.EventStates.First(d => d.Name == "aceites");
            var NewEventsNotInExihibtion = db.Events.Include(d => d.EventState).Where(d => d.StartDate >= now && d.EventState.Id == getEventAcceptedState.Id).ToList();
            var getRoomBusyState = db.SpaceStates.First(d => d.Name == "ocupada"); // Estado de sala ocupada
            foreach (var _event in NewEventsNotInExihibtion)  // Coloca todos os eventos que o StartDate é agora ou um pouco antes, e que ainda se encontram com o estado "aceites"
            {
                //RoomsMuseum
                var getEventRooms = db.RoomMuseums.Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _room_ in getEventRooms) // coloca todas as salas associadas ao evento nas condicoes acima, com o estado de salas ocupado
                {
                    if (_room_.SumRoomArtPieces < 1)
                    {
                        _room_.SumRoomArtPieces = 0;
                        _room_.SpaceState = getRoomFreeState;
                        _event.SumArtPieces = 0;
                        _event.EventState = getEventFinishedState;
                    }
                    else
                    {
                        var ArtpiecesInRoom = db.ArtPieces.Where(d => d.RoomMuseum.Id == _room_.Id).ToList();

                        for (int i = 0; i < ArtpiecesInRoom.Count; i++)
                        {
                            _room_.SumRoomArtPieces += 1;
                        }
                        _room_.SpaceState = getRoomBusyState;

                        SumArtpiecesInAllRoomsOfEvent += _room_.SumRoomArtPieces;
                    }
                    db.SaveChanges();
                }

                //OutSideSpaces
                var getEventOutSideSpaces = db.OutSideSpaces.Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _outSideSpace_ in getEventOutSideSpaces) // coloca todos os espaços exteriores associados ao evento nas condicoes acima, com o estado de espaços livres
                {
                    _outSideSpace_.SpaceState = getRoomBusyState;
                }

                _event.SumArtPieces = 0;
                _event.EventState = getEventExhibitionState;

                db.SaveChanges();
            }
        }
    }
}
