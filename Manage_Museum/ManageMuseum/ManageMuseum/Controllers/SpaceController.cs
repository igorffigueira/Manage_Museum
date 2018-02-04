using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageMuseum.Models;
using ManageMuseumData.GetData;

namespace ManageMuseum.Controllers
{
    public class SpaceController : Controller
    {
        private RoomMuseumData roomMuseumData = new RoomMuseumData();
        
        public ActionResult Map()
        {
            var rooms = roomMuseumData.GetListRoomMuseums();
            //foreach (var roomCapacity in rooms)
            //{
            //    roomCapacity.Id += 8;
            //}
            
            ViewBag.RoomMuseums = new SelectList(rooms, "Id", "Id");
            ViewBag.capacity = TempData["capacity"];
            ViewBag.Role = Request.Cookies["Role"].Value;
            return View();


        }

        [HttpPost]
        public ActionResult Map(SpaceViewModel roomMuseum)
        {
            //var rooms = roomMuseumData.GetListRoomMuseums();
            
            //ViewBag.RoomMuseums = new SelectList(rooms, "Id", "Id");
            //roomMuseum.RoomId -= 8;
            var roomId = roomMuseum.RoomId;
            var roomCapacity = roomMuseum.MaxRoomArtPieces;

            
           roomMuseumData.ChanceRoomCapacity(roomId,roomCapacity);
            
            

            return RedirectToAction("Map");



        }
    }
}