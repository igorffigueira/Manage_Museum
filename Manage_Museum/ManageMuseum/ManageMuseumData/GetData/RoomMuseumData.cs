using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.GetData
{
    public class RoomMuseumData : AData
    {
       
        public  RoomMuseum GetRoom(ArtPiece artPiece)
        {

            var roomData = db.RoomMuseums.Include(d=>d.Event).First(v => v.Id == artPiece.RoomMuseum.Id);
            return roomData;
        }

        public RoomMuseum GetRoomById(int roomId)
        {

           
            return db.RoomMuseums.Include(d => d.ArtPieces).Include(d => d.SpaceState).First(d => d.Id == roomId); 
        }

        public List<RoomMuseum> GetListRoomByEventId(int id)
        {
            return db.RoomMuseums.Include(d => d.ArtPieces).Include(d => d.SpaceState).Where(d => d.Event.Id == id).ToList();
        }

    }
}
