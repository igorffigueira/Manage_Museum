using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.GetData;

namespace ManageMuseumData.EventManagement
{
    public class EventManagement : AData
    {
        public void Management()
        {
            var now = DateTime.Now.Date;
            var nowDay = now.Day;
            var eventTypeExhibitionState = db.EventTypes.Single(s => s.Name == "exposicao");
            var eventClosedState = db.EventStates.Single(s => s.Name == "encerrado");
            var eventExhibitiondState = db.EventStates.Single(s => s.Name == "exibicao");
            var eventAcceptState = db.EventStates.Single(s => s.Name == "aceites");
            var spaceFreeState = db.SpaceStates.Single(s => s.Name == "livre");
            var spaceBusyState = db.SpaceStates.Single(s => s.Name == "ocupada");
            var artPieceStorageState = db.ArtPieceStates.Single(s => s.Name == "armazem");
            var artPieceExpositionState = db.ArtPieceStates.Single(s => s.Name == "exposicao");

            // Defines Exhibition events without artpieces as closed
            var eventsOnExhibitionEmptyArtPieces = db.Events.Include(d => d.EventState).Include(d => d.EventType).Where(d => d.EventState.Name == "exibicao" && d.SumArtPieces == 0).ToList();

            foreach (var event_ in eventsOnExhibitionEmptyArtPieces)
            {
                if (event_.EventType.Name == "exposicao" && event_.StartDate.Day < now.Day)
                {
                    var getEventRooms = db.RoomMuseums.Include(d => d.Event).Where(d => d.Event.Id == event_.Id).ToList();
                    foreach (var rooms in getEventRooms)
                    {
                        rooms.SpaceState = spaceFreeState;
                        rooms.Event = null;
                        db.SaveChanges();
                    }
                    event_.EventState = eventClosedState;

                    db.SaveChanges();
                }
            }

            // Defines past events as closed, and the rooms associated with those events are again free
            var oldEventsOnExihibtion = db.Events.Include(d => d.EventState).Include(d => d.EventType).Where(d => d.EnDate.Day < now.Day && d.EventState.Name == "exibicao").ToList();
            foreach (var _events in oldEventsOnExihibtion)
            {
                if (_events.EventType.Name == "exposicao")
                {
                    var getEventRooms = db.RoomMuseums.Include(d => d.Event).Where(d => d.Event.Id == _events.Id).ToList();
                    foreach (var rooms in getEventRooms)
                    {
                        var getArtPieces = db.ArtPieces.Include(d => d.RoomMuseum).Include(d => d.ArtPieceState).Where(d => d.RoomMuseum.Id == rooms.Id).ToList();
                        foreach (var piece in getArtPieces)
                        {
                            piece.ArtPieceState = artPieceStorageState;
                            rooms.SumRoomArtPieces -= 1;
                            db.SaveChanges();
                        }
                        rooms.SpaceState = spaceFreeState;
                        rooms.Event = null;
                        _events.SumArtPieces -= 1;
                        db.SaveChanges();
                    }
                    _events.EventState = eventClosedState;
                    db.SaveChanges();
                }
                else
                {
                    var getEventsOut = db.OutSideSpaces.Include(d => d.Event).Include(d => d.SpaceState).Where(d => d.Event.Id == _events.Id).ToList();
                    foreach (var outSide in getEventsOut)
                    {
                        outSide.SpaceState = spaceFreeState;
                        outSide.Event = null;
                        db.SaveChanges();
                    }
                    _events.EventState = eventClosedState;
                    db.SaveChanges();
                }
            }

            // Defines events in exhibition, and the rooms associated with those events busy
            var NewEventsNotInExihibtion = db.Events.Include(d => d.EventType).Include(d => d.EventState).Where(d => d.StartDate.Day <= now.Day && d.EventState.Name == "aceites").ToList();
            foreach (var _event in NewEventsNotInExihibtion) // Coloca todos os eventos que o StartDate é agora ou um pouco antes, e que ainda se encontram com o estado "aceites"
            {
                if (_event.EventType.Name == "exposicao")
                {
                    var getEventsRooms = db.RoomMuseums.Include(d => d.SpaceState).Include(d => d.Event).Where(d => d.Event.Id == _event.Id).ToList();
                    foreach (var _room_ in getEventsRooms) // coloca todas as salas associadas ao evento nas condicoes acima, com o estado de salas ocupado
                    {
                        if (_event.SumArtPieces < 1 && _event.StartDate.Day < now.Day)
                        {
                            _room_.SpaceState = spaceFreeState;
                            _event.EventState = eventClosedState;
                            _room_.SumRoomArtPieces = 0;
                            _event.SumArtPieces = 0;
                            _room_.Event = null;
                            db.SaveChanges();
                        }
                        else
                        {
                            var getPieces = db.ArtPieces.Include(d => d.RoomMuseum).Include(d => d.ArtPieceState).Where(d => d.RoomMuseum.Id == _room_.Id).ToList();
                            foreach (var piece in getPieces)
                            {
                                piece.ArtPieceState = artPieceExpositionState;
                                db.SaveChanges();
                            }
                            _room_.SpaceState = spaceBusyState;
                            _event.EventState = eventExhibitiondState;
                            db.SaveChanges();
                        }
                    }
                    db.SaveChanges();
                }
                else
                {
                    var getEventsRooms = db.OutSideSpaces.Include(d => d.Event).Include(d => d.SpaceState).Where(d => d.Event.Id == _event.Id).ToList();
                    foreach (var outSide in getEventsRooms)
                    {
                        outSide.SpaceState = spaceBusyState;
                        db.SaveChanges();
                    }
                    _event.EventState = eventExhibitiondState;
                    db.SaveChanges();
                }
            }
        }
    }
}
