using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.Builder;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.GetData
{
   public class EventData : AData
    {
      
        private RoomMuseumData roomData = new RoomMuseumData();
        private OutSideSpaceData outData = new OutSideSpaceData();
        public Events GetEvent(RoomMuseum room)
        {
            var eventData = db.Events.First(d => d.Id == room.Event.Id);

            return eventData;
        }

        public Events GetEventById(int id)
        {
            return db.Events.Include(d => d.UserAccount).Include(d => d.EventState).Include(d => d.EventType).Single(s => s.Id == id);
        }

        public List<Events> GetListEvents(string state)
        {
            var getExhibitionAcceptedState = db.EventStates.Include("Events").Single(s => s.Name == state);
            var ExhibitionAccepted = db.Events.Include("EventType").Include("UserAccount").Include("OutSideSpaces").Include("EventState").Where(d => d.EventState.Name == getExhibitionAcceptedState.Name).ToList();
            return ExhibitionAccepted;
        }

        public List<Events> GetEventsByState(string state)
        {
            return db.Events.Include(d => d.EventState).Include(d => d.EventType).Where(d => d.EventState.Name == state).ToList();
        }
        //requisitar eventos do tipo exposição
        public void RequestEvent(List<string> rooms,string eventName,string eventDescription, DateTime startDate,DateTime endDate,int userId)
        {

            //var listSpaces = new List<RoomMuseum>();

            //foreach (var items in rooms)
            //{
            //    var query = db.RoomMuseums.Include(d => d.Event).Single(d => d.Name == items);
            //    listSpaces.Add(query);
            //}
            //var eventState = db.EventStates.Single(s => s.Name == "poraprovar");
            //var eventType = db.EventTypes.Single(s => s.Name == "exposicao");

            //var userAccont = db.UserAccounts.Single(s => s.Id == userId);
            //var newEvent = new Events() { UserAccount = userAccont, Name = eventName, EventState = eventState, EventType = eventType, Description = eventDescription, StartDate = startDate, EnDate = endDate };

            //foreach (var item in listSpaces)
            //{
            //    item.Event = newEvent;
            //}
            //db.SaveChanges();

            Manager man = new Manager();
            EventBuilder ev = new ExpositionEventBuilder();
            man.Construct(ev,rooms,eventName,startDate,endDate,eventDescription,userId);
        }

        public void ApproveExhibition(int eventId)
        {
            Events update = db.Events.Include(d => d.EventType).Include(v => v.EventState).First(d => d.Id == eventId);

            if (update.EventType.Name.Equals("social"))
            {
                var outSide = db.OutSideSpaces.Where(s => s.Event.Id == eventId).ToList();
                var spaceState = db.SpaceStates.Single(s => s.Name == "ocupada");
                foreach (var item in outSide)
                {
                    item.SpaceState = spaceState;
                }

            }
            else if (update.EventType.Name.Equals("exposicao"))
            {
                var rooms = db.RoomMuseums.Where(s => s.Event.Id == eventId).ToList();
                var roomState = db.SpaceStates.Single(s => s.Name == "ocupada");
                foreach (var room in rooms)
                {
                    room.SpaceState = roomState;
                }


            }
            ChangeEventState("aceites", eventId);
            db.SaveChanges();
        }

        public void ChangeEventState(string state, int eventId)
        {

            EventState eventState = db.EventStates.First(d => d.Name == state);

            Events update = db.Events.Include(v => v.EventState).Include(d=>d.EventType).First(d => d.Id == eventId);
            update.EventState = eventState;
            if (state.Equals("rejeitado"))
            {
                if (update.EventType.Name.Equals("exposicao"))
                {
                    roomData.DetachRoomsFromEvent(eventId);
                }
                else
                {
                    outData.DetachOutSideSpacesFromEvent(eventId);
                }
            }
            db.SaveChanges();
        }
        
    }
}
