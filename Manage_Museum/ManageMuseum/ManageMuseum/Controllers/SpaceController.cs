using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;

namespace ManageMuseum.Controllers
{
    public class SpaceController : Controller
    {
        private OurContectDb db = new OurContectDb();
        // GET: Space
        public ActionResult Map()
        {
            var rooms = db.RoomMuseums.ToList();
            ViewBag.RoomMuseums = new SelectList(rooms, "Name", "Name");
            ViewBag.capacity = TempData["capacity"];
            return View();
        }

        [HttpPost]
        public ActionResult Map(SpaceViewModel roomMuseum)
        {
            var rooms = db.RoomMuseums.ToList();
            ViewBag.RoomMuseums = new SelectList(rooms, "Name", "Name");
            var roomName = roomMuseum.RoomName;
            var roomCapacity = roomMuseum.MaxRoomArtPieces;

            var Room = db.RoomMuseums.Single(s=>s.Name == roomName);

            Room.MaxRoomArtPieces = roomCapacity;
            
            db.SaveChanges();
            

            return RedirectToAction("Map");



        }
    }
}