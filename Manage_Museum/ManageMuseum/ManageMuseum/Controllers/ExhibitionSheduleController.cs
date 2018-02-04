using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;
using ManageMuseumData.GetData;

namespace ManageMuseum.Controllers
{
    public class ExhibitionSheduleController : Controller
    {
        private RoomMuseumData roomData = new RoomMuseumData();
        private EventData eventData = new EventData();
        // GET: SheduleExhibition
        [ArtPieceAuthorize]
        public ActionResult SheduleExhibition()
        {
            var getListFreeRooms = roomData.GetListRoomsByState("livre");
            ViewBag.ListSpaces = new SelectList(getListFreeRooms, "Name", "Name");
            ViewBag.sizeListRooms = getListFreeRooms.Count;
            return View();
        }
        [ArtPieceAuthorize]
        [HttpPost]
        public ActionResult SheduleExhibition(EventViewModel events)
        {
            events.EventType = "exposicao";
            var queryListSpaces = roomData.GetListRoomsByState("livre");
            ViewBag.ListSpaces = new SelectList(queryListSpaces, "Name", "Name");

            var userId = Int32.Parse(Request.Cookies["UserId"].Value);
            eventData.RequestEvent(events.SpacesList,events.Name,events.EventType,events.Description,events.StartDate,events.EnDate,userId);
            
            return Redirect("SheduleExhibition");
        }
        [SpaceManagerAuthorize]
        public ActionResult ShowRequestsList()
        {
            var query = eventData.GetEventsByState("poraprovar");
            ViewBag.Data = query;

            return View();
        }
        [SpaceManagerAuthorize]
        public ActionResult EventRequestApprove(string eventId)
        {
            var EventIdApprove = Int32.Parse(eventId);
            eventData.ApproveExhibition(EventIdApprove);

            return Redirect("ShowRequestsList");
        }
        [SpaceManagerAuthorize]
        public ActionResult EventRequestDetails(string eventId)
        {
            var EventIdSelected = Int32.Parse(eventId);
            var queryEventDetails = eventData.GetEventById(EventIdSelected);
            ViewBag.evento = queryEventDetails;
            ViewData["EventUserId"] = queryEventDetails.UserAccount.Id;
            ViewData["EventUserFName"] = queryEventDetails.UserAccount.FirstName;
            ViewData["EventUserLName"] = queryEventDetails.UserAccount.LastName;
            ViewData["EventSelected"] = queryEventDetails.Id;
            ViewData["EventName"] = queryEventDetails.Name;
            ViewData["EventType"] = queryEventDetails.EventType.Name;
            ViewData["EventStartDate"] = queryEventDetails.StartDate;
            ViewData["EventEndDate"] = queryEventDetails.EnDate;
            ViewData["EventDescription"] = queryEventDetails.Description;

            return View();
        }
        [SpaceManagerAuthorize]
        public ActionResult EventRequestReject(string eventId)
        {
            var EventIdReject = Int32.Parse(eventId);
            eventData.ChangeEventState("rejeitado", EventIdReject);
            return Redirect("ShowRequestsList");
        }
    }
}
