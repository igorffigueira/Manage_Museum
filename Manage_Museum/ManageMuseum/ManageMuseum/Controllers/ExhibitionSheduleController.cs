using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;

namespace ManageMuseum.Controllers
{
    public class ExhibitionSheduleController : Controller
    {
        private OurContectDb db = new OurContectDb();
        // GET: ExhibitionShedule
        public ActionResult SheduleExhibition()
        {
          
            var queryListSpaces = db.RoomMuseums.ToList();
            ViewBag.ListSpaces = new SelectList(queryListSpaces, "Name", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult SheduleExhibition(EventViewModel events)
        {
            //var queryRooms = db.RoomMuseums.Include(d=>d.Event).Single(s => s.Name == events.RoomName);

            var rooms = events.SpacesList;
            var listSpaces = new List<RoomMuseum>();

            foreach (var items in rooms)
            {
                var query = db.RoomMuseums.Include(d => d.Event).Single(d => d.Name == items);
                listSpaces.Add(query);
            }
            var eventState = db.EventStates.Single(s=>s.Name == "poraprovar");
            var eventType = db.EventState.Single(s => s.Name == "exposicao");
            var userId = Int32.Parse(Request.Cookies["UserId"].Value);
            var userAccont = db.UserAccounts.Single(s => s.Id == userId);
            var newEvent = new Event() { UserAccount = userAccont, Name = events.Name, EventState = eventState, EventType = eventType, Description = events.Description, StartDate = events.StartDate, EnDate = events.EnDate };

            foreach (var item in listSpaces)
            {
                item.Event = newEvent;
            }
            db.SaveChanges();
            return View();
        }

        public ActionResult ShowRequestsList()
        {
            var query = db.Events.Include(d => d.EventState).Include(d => d.EventType).Where(d => d.EventState.Id == 1).ToList();
            ViewBag.Data = query;
            return View();
        }

        public ActionResult EventRequestApprove(string eventId)
        {
            var EventIdApprove = Int32.Parse(eventId);

            EventState approvedState = db.EventStates.First(d => d.Name == "aceites");
            
            Event update = db.Events.Include(v => v.EventState).First(d => d.Id == EventIdApprove);
            update.EventState = approvedState;
            db.SaveChanges();
            //FALTA COLOCAR AQUI UMA MENSAGEM DE AVISO QUE O PEDIDO DE EVENTO FOI APROVADO
            return Redirect("ShowRequestsList");
        }

        public ActionResult EventRequestDetails(string eventId)
        {
            var EventIdSelected = Int32.Parse(eventId);

            var queryEventDetails = db.Events.Include(d=>d.UserAccount).Include(d => d.EventState).Include(d => d.EventType).Single(s => s.Id == EventIdSelected);
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
    }
}
//var queryEventDetails = db.Events.Include(d => d.UserAccount).Include(d => d.EventState).Include(d => d.EventType).Where(s => s.Id == EventIdSelected).ToList();