using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.GetData
{
    public class RoomMuseumData : AData
    {
     
        /// <summary>
        /// obter um quarto que a peça de arte está
        /// </summary>
        /// <param name="artPiece"></param>
        /// <returns></returns>
        public  RoomMuseum GetRoom(ArtPiece artPiece)
        {

            var roomData = db.RoomMuseums.Include(d=>d.ArtPieces).Include(d=>d.Event).First(v => v.Id == artPiece.RoomMuseum.Id);
            return roomData;
        }

        /// <summary>
        /// obter um quarto pelo o seu id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public RoomMuseum GetRoomById(int roomId)
        {

           
            return db.RoomMuseums.Include(d => d.ArtPieces).Include(d => d.SpaceState).Single(d => d.Id == roomId); 
        }

        public void ChanceRoomCapacity(int roomId,int capacity)
        {
            var room = GetRoomById(roomId);
            room.MaxRoomArtPieces = capacity;
            db.RoomMuseums.AddOrUpdate(room);
            db.SaveChanges();
        }

        /// <summary>
        /// listagem de quartos de um determinado evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RoomMuseum> GetListRoomByEventId(int id)
        {
            return db.RoomMuseums.Include(d => d.ArtPieces).Include(d => d.SpaceState).Where(d => d.Event.Id == id).ToList();
        }

        /// <summary>
        /// listagem de todos os quartos
        /// </summary>
        /// <returns></returns>
        public List<RoomMuseum> GetListRoomMuseums()
        {
            return db.RoomMuseums.ToList();
        }

        /// <summary>
        /// listagem de quartos pelo seu estado
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<RoomMuseum> GetListRoomsByState(string state)
        {
            var getRoomFreeState = db.SpaceStates.First(d => d.Name == state); // Estado de sala livre
           return db.RoomMuseums.Where(d => d.SpaceState.Name == getRoomFreeState.Name).ToList();
        }
        /// <summary>
        /// remover os quartos de um evento
        /// </summary>
        /// <param name="eventId"></param>
        public void DetachRoomsFromEvent(int eventId)
        {
            var rooms = db.RoomMuseums.Include(d => d.Event).Where(d => d.Event.Id == eventId).ToList();
            foreach (var item in rooms)
            {
                item.Event = null;
                db.SaveChanges();
            }
        }
    }
}
