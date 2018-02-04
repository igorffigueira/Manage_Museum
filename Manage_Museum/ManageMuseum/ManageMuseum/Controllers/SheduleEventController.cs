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
            ViewBag.EventType = new SelectList(eventData.GetListEventTypes(), "Name", "Name");
            ViewBag.ListSpaces = new SelectList(roomMuseumData.GetListRoomsByState("livre"), "Name", "Name");
            ViewBag.sizeNumberRooms = roomMuseumData.GetListRoomsByState("livre").Count;ViewBag.ListOutSideSpaces = new SelectList(outSideSpaceData.GetListOutSideSpacesByState("livre"), "Name", "Name");
            ViewBag.sizeNumberOutSideSpaces = outSideSpaceData.GetListOutSideSpacesByState("livre").Count;
            return View();
        }
        [ArtPieceAuthorize]
        public ActionResult ApprovedExhibition()
        {
            var userId = Int32.Parse(Request.Cookies["UserId"].Value);
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