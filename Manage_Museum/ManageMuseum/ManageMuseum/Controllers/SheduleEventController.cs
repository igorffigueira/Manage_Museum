using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;

namespace ManageMuseum.Controllers
{
    public class SheduleEventController : Controller
    {
        private OurContectDb db = new OurContectDb();
        // GET: SheduleEvent
        public ActionResult SheduleEvent()
        {
            

            var now = DateTime.Now.Date;
            var getEventExhibitionState = db.EventStates.First(d => d.Name == "exibicao");
            var oldEventsOnExihibtion = db.Events.Include(d => d.EventState).Where(d => d.EnDate < now && d.EventState.Id == getEventExhibitionState.Id).ToList();
            var getFreeState = db.SpaceStates.First(d => d.Name == "livre");
            var getEventFinishedState = db.EventStates.First(d => d.Name == "encerrado");
            foreach (var _event in oldEventsOnExihibtion)  // Coloca todos os eventos que o endDate já ocorreu, e que ainda se encontram em exibicao, com o estado encerrado
            {
                var getEventRooms = db.RoomMuseums.Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _room in getEventRooms) // coloca todas as salas associadas ao evento nas condicoes acima, com o estado de salas livres
                {
                    _room.SumRoomArtPieces = 0;
                    _room.SpaceState = getFreeState;

                    db.SaveChanges();
                }
                var getEventOutSideSpaces = db.OutSideSpaces.Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                foreach (var _outSideSpace in getEventOutSideSpaces) // coloca todos os espaços exteriores associados ao evento nas condicoes acima, com o estado de espaços livres
                {
                    _outSideSpace.SpaceState = getFreeState;

                    db.SaveChanges();
                }

                _event.SumArtPieces = 0;
                _event.EventState = getEventFinishedState;

                db.SaveChanges();
            }
            
            var getListEventTypes = db.EventTypes.ToList(); // Lista dos tipos de evento (social ou exposição)
            ViewBag.EventType = new SelectList(getListEventTypes, "Name", "Name");
            var getListFreeRooms = db.RoomMuseums.Where(d => d.SpaceState.Name == getFreeState.Name).ToList();  // Salas com o estado livre
            ViewBag.ListSpaces = new SelectList(getListFreeRooms, "Name","Name");
            ViewBag.sizeNumberRooms = getListFreeRooms.Count;
            var getListOutSideSpaces = db.OutSideSpaces.Where(d => d.SpaceState.Name == getFreeState.Name).ToList();  // Salas com o estado livre
            ViewBag.ListOutSideSpaces = new SelectList(getListOutSideSpaces, "Name", "Name");
            ViewBag.sizeNumberOutSideSpaces = getListOutSideSpaces.Count;

            db.SaveChanges();
           
            return View();
        }

        public ActionResult ApprovedExhibition()
        {
            var userId = Int32.Parse(Request.Cookies["UserId"].Value);
            var eventType = db.EventTypes.Single(s => s.Name == "exposicao");
            var eventState = db.EventStates.Single(s=>s.Name == "aceites");
            var eventsToShow = db.Events.Include(d => d.UserAccount).Include(d=>d.EventType).Include(d=>d.EventState).Where(d=>d.UserAccount.Id == userId && d.EventType.Id == eventType.Id &&d.EventState.Id == eventState.Id ).ToList();
            ViewBag.EventsToShow = eventsToShow;
            return View();
        }

        [HttpPost]
        public ActionResult ApprovedExhibition(EventViewModel even)
        {
            return View();
        }


        [HttpPost]
        public ActionResult SheduleEvent(EventViewModel events)
        {
           
            var eventType = events.EventType;
            var eventSpacesList = events.SpacesList;
            var outSide = events.OutSideSpaces;
           
            var roomState = db.SpaceStates.Single(s => s.Name == "ocupada");
            var getEventTypeRow = db.EventTypes.FirstOrDefault(s => s.Name == eventType);
            var eventState = db.EventStates.Single(s => s.Name == "aceites");
            var userId = Int32.Parse(Request.Cookies["UserId"].Value);
            var userAccount = db.UserAccounts.Include(d => d.Role).FirstOrDefault(s => s.Id == userId);
            var finalEvent = new Event()
            {
                Name = events.Name,
                StartDate = events.StartDate,
                EnDate = events.EnDate,
                Description = events.Description,
                EventType = getEventTypeRow,
                EventState = eventState,
                UserAccount = userAccount
            };
            if (events.EventType =="exposicao")
            {

                var listSpaces = new List<RoomMuseum>();
                foreach (var rooms in eventSpacesList)
                {
                    listSpaces.Add(db.RoomMuseums.Single(s => s.Name == rooms));
                }
              

                foreach (var rooms in listSpaces)
                {
                    rooms.Event = finalEvent;
                    rooms.SpaceState = roomState;
                }

              
            } else if (events.EventType =="social")
            {
                var listOuside = new List<OutSideSpace>();
                foreach (var space in outSide)
                {
                    listOuside.Add(db.OutSideSpaces.Single(s=>s.Name == space));
                }
                foreach (var spaces in listOuside)
                {
                    spaces.Event = finalEvent;
                    spaces.SpaceState = roomState;
                }
            }
            
            db.Events.Add(finalEvent);
            db.SaveChanges();
            return Redirect("SheduleEvent");
        }

    }
}