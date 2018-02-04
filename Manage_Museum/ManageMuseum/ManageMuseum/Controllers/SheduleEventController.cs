using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;
using ManageMuseumData.GetData;

namespace ManageMuseum.Controllers
{
    public class SheduleEventController : Controller
    {
        private EventData eventData = new EventData();
        private RoomMuseumData roomMuseumData = new RoomMuseumData();
        private OutSideSpaceData outSideSpaceData = new OutSideSpaceData();

        [SpaceManagerAuthorize]
        public ActionResult SheduleEvent()
        {


            //var getRoomFreeState = db.SpaceStates.First(d => d.Name == "livre"); // Estado de sala livre
            //var getListEventTypes = db.EventTypes.ToList(); // Lista dos tipos de evento (social ou exposição)
            ViewBag.EventType = new SelectList(eventData.GetListEventTypes(), "Name", "Name");

           // var getListFreeRooms = db.RoomMuseums.Where(d => d.SpaceState.Name == getRoomFreeState.Name).ToList();  // Salas com o estado livre
            ViewBag.ListSpaces = new SelectList(roomMuseumData.GetListRoomsByState("livre"), "Name", "Name");
            ViewBag.sizeNumberRooms = roomMuseumData.GetListRoomsByState("livre").Count;

            //var getListOutSideSpaces = db.OutSideSpaces.Where(d => d.SpaceState.Name == getRoomFreeState.Name).ToList();  // Salas com o estado livre
            ViewBag.ListOutSideSpaces = new SelectList(outSideSpaceData.GetListOutSideSpacesByState("livre"), "Name", "Name");
            ViewBag.sizeNumberOutSideSpaces = outSideSpaceData.GetListOutSideSpacesByState("livre").Count;

            //db.SaveChanges();

            return View();
        }
        [ArtPieceAuthorize]
        public ActionResult ApprovedExhibition()
        {
            var userId = Int32.Parse(Request.Cookies["UserId"].Value);
            //var eventType = db.EventTypes.Single(s => s.Name == "exposicao");
            //var eventState = db.EventStates.Single(s => s.Name == "aceites");
            //var eventsToShow = db.Events.Include(d => d.UserAccount).Include(d => d.EventType).Include(d => d.EventState).Where(d => d.UserAccount.Id == userId && d.EventType.Id == eventType.Id && d.EventState.Id == eventState.Id).ToList();
            //ViewBag.EventsToShow = eventsToShow;
            ViewBag.EventsToShow = eventData.GetEventsList(userId,"aceites","exposicao");


            return View();
        }
        [ArtPieceAuthorize]
        [HttpPost]
        public ActionResult ApprovedExhibition(EventViewModel even)
        {
            return View();
        }

        [SpaceManagerAuthorize]
        [HttpPost]
        public ActionResult SheduleEvent(EventViewModel events)
        {

            //var eventType = events.EventType;
            //var eventSpacesList = events.SpacesList;
            //var outSide = events.OutSideSpaces;

            //var roomState = db.SpaceStates.Single(s => s.Name == "ocupada");
            //var getEventTypeRow = db.EventTypes.FirstOrDefault(s => s.Name == eventType);
            //var eventState = db.EventStates.Single(s => s.Name == "aceites");
            //var userId = Int32.Parse(Request.Cookies["UserId"].Value);
            //var userAccount = db.UserAccounts.Include(d => d.Role).FirstOrDefault(s => s.Id == userId);
            //var finalEvent = new Event()
            //{
            //    Name = events.Name,
            //    StartDate = events.StartDate,
            //    EnDate = events.EnDate,
            //    Description = events.Description,
            //    EventType = getEventTypeRow,
            //    EventState = eventState,
            //    UserAccount = userAccount
            //};
            //if (events.EventType == "exposicao")
            //{

            //    var listSpaces = new List<RoomMuseum>();
            //    foreach (var rooms in eventSpacesList)
            //    {
            //        listSpaces.Add(db.RoomMuseums.Single(s => s.Name == rooms));
            //    }


            //    foreach (var rooms in listSpaces)
            //    {
            //        rooms.Event = finalEvent;
            //        rooms.SpaceState = roomState;
            //    }


            //}
            //else if (events.EventType == "social")
            //{
            //    var listOuside = new List<OutSideSpace>();
            //    foreach (var space in outSide)
            //    {
            //        listOuside.Add(db.OutSideSpaces.Single(s => s.Name == space));
            //    }
            //    foreach (var spaces in listOuside)
            //    {
            //        spaces.Event = finalEvent;
            //        spaces.SpaceState = roomState;
            //    }
            //}

            //db.Events.Add(finalEvent);

            //db.SaveChanges();

            var userId = Int32.Parse(Request.Cookies["UserId"].Value);
            if (events.EventType == "exposicao")
            {
                eventData.RequestEvent(events.SpacesList,events.Name,events.EventType,events.Description,events.StartDate,events.EnDate,userId);
            }
            else if (events.EventType == "social")
            {
                eventData.RequestEvent(events.OutSideSpaces, events.Name, events.EventType, events.Description, events.StartDate, events.EnDate, userId);
            }
            return Redirect("SheduleEvent");
        }

    }
}