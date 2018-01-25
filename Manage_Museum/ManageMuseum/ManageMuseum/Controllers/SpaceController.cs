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
            foreach (var roomCapacity in rooms)
            {
                roomCapacity.Id += 8;
            }
            
            ViewBag.RoomMuseums = new SelectList(rooms, "Id", "Id");
            ViewBag.capacity = TempData["capacity"];
            ViewBag.Role = Request.Cookies["Role"].Value;
            return View();

        }

        [HttpPost]
        public ActionResult Map(SpaceViewModel roomMuseum)
        {
            var rooms = db.RoomMuseums.ToList();
            roomMuseum.RoomId -= 8;
            ViewBag.RoomMuseums = new SelectList(rooms, "Id", "Id");
            var roomId = roomMuseum.RoomId;
            var roomCapacity = roomMuseum.MaxRoomArtPieces;
            
            var Room = db.RoomMuseums.Single(s=>s.Id == roomId);

            Room.MaxRoomArtPieces = roomCapacity;
            
            db.SaveChanges();
            

            return RedirectToAction("Map");



        }
    }
}