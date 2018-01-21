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
            

            var queryEventTypes = db.EventTypes.ToList();
            ViewBag.EventType = new SelectList(queryEventTypes,"Name","Name");

            var queryListSpaces = db.RoomMuseums.ToList();
            ViewBag.ListSpaces = new SelectList(queryListSpaces,"Id","Id");

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
            var getEventTypeRow = db.EventTypes.FirstOrDefault(s => s.Name == eventType);
            var eventState = db.EventStates.Single(s => s.Id == 1);
            var userId = Int32.Parse(Request.Cookies["UserId"].Value);
            var userAccount = db.UserAccounts.Include(d=>d.Role).FirstOrDefault(s => s.Id == userId);
            var finalEvent = new Event() {Name = events.Name, StartDate = events.StartDate, EnDate = events.EnDate,Description = events.Description,EventType = getEventTypeRow, EventState = eventState,UserAccount = userAccount};


            db.Events.Add(finalEvent);
            db.SaveChanges();



            return Content("hahahahaahahaha");
        }

    }
}