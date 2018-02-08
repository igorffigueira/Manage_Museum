using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.GetData
{
   public class ArtPiecesData : AData
    {
       
        private RoomMuseumData roomData =  new RoomMuseumData();
        private EventData eventData = new EventData();

        /// <summary>
        /// listagem das peças de arte do museu
        /// </summary>
        /// <returns></returns>
        public List<ArtPiece> ListArtPieces()
        {
            var query = db.ArtPieces.Include("ArtPieceState").Include("RoomMuseum").ToList();
            return query;
        }

        /// <summary>
        /// obter um determinado estado
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public ArtPieceState GetArtPieceState(string state)
        {
            var estadoPeca = db.ArtPieceStates.Include("ArtPieces").First(d => d.Name == state);
            return estadoPeca;
        }

        /// <summary>
        /// retorna uma peça de arte dando o id da peça
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArtPiece GetPieceByID(int id)
        {
            var pieceData = db.ArtPieces.Include(d => d.RoomMuseum).Include("ArtPieceState").First(d => d.Id == id);
            return pieceData;
        }

        /// <summary>
        /// remover uma peça de arte pelo id
        /// </summary>
        /// <param name="pieceId"></param>
        public void RemoveFromExhibition(int pieceId)
        {
            

            var getPieceStorageState = GetArtPieceState("armazem");
            var pieceData = GetPieceByID(pieceId);
            var getRoom = roomData.GetRoom(pieceData);
            var getEvent = eventData.GetEvent(getRoom);

            pieceData.ArtPieceState = getPieceStorageState;

            pieceData.RoomMuseum = null;
            getRoom.SumRoomArtPieces -= 1; // remove 1 art piece from 1 room
            getEvent.SumArtPieces -= 1;

            db.SaveChanges();
        }

        /// <summary>
        /// muda o estado da peça
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public ArtPieceState ChangeStorageState(string state)
        {
            return db.ArtPieceStates.Include(d => d.ArtPieces).First(s => s.Name == state);
        }

        /// <summary>
        /// adiciona uma peça de arte ao um quarto do museu
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="roomId"></param>
        /// <param name="pieceId"></param>
        /// <param name="state"></param>
        public void AddPieceToRoom(int eventId, int roomId, int pieceId, string state)
        {
            var getSelectedEventData = eventData.GetEventById(eventId);
            var getPieceDataFromId = GetPieceByID(pieceId);
            var getSelectedRoomData = roomData.GetRoomById(roomId);
            var getPieceStorageState = ChangeStorageState(state);  //Obter estado de peça em exibição

            getPieceDataFromId.ArtPieceState = getPieceStorageState;

            getPieceDataFromId.RoomMuseum = getSelectedRoomData;
            getPieceDataFromId.RoomMuseum.ArtPieces.Add(getPieceDataFromId);
            getSelectedRoomData.SumRoomArtPieces += 1;  // Incrementar 1 peça à soma de peças na sala
            getSelectedEventData.SumArtPieces += 1;  // Incrementar 1 peça à soma de peças no evento

            db.SaveChanges();
        }


    }
}
