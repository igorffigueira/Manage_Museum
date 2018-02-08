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
        private UserData userData = new UserData();


        /// <summary>
        /// obter um evento que estão associado a um quarto do museu
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public Events GetEvent(RoomMuseum room)
        {
            var eventData = db.Events.First(d => d.Id == room.Event.Id);

            return eventData;
        }

        /// <summary>
        /// obert o evento pelo o seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Events GetEventById(int id)
        {
            return db.Events.Include(d => d.UserAccount).Include(d => d.EventState).Include(d => d.EventType).Single(s => s.Id == id);
        }

        /// <summary>
        /// lista de eventos com um determinado estado
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<Events> GetListEvents(string state)
        {
            var getExhibitionAcceptedState = db.EventStates.Include("Events").Single(s => s.Name == state);
            var ExhibitionAccepted = db.Events.Include("EventType").Include("UserAccount").Include("OutSideSpaces").Include("EventState").Where(d => d.EventState.Name == getExhibitionAcceptedState.Name).ToList();
            return ExhibitionAccepted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<Events> GetEventsByState(string state)
        {
            return db.Events.Include(d => d.EventState).Include(d => d.EventType).Where(d => d.EventState.Name == state).ToList();
        }
        /// <summary>
        /// obtem um estado de evento
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public EventState GetEventState(string state)
        {
            return db.EventStates.Single(s => s.Name == state);
        }

        /// <summary>
        /// obter um tipo de evento
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public EventType GetEventType(string type)
        {
            return db.EventTypes.Single(s => s.Name == type);
        }

        //requisitar eventos do tipo exposição
        /// <summary>
        /// marcação de eventos
        /// </summary>
        /// <param name="rooms"></param>
        /// <param name="eventName"></param>
        /// <param name="eventType"></param>
        /// <param name="eventDescription"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="userId"></param>
        public void RequestEvent(List<string> rooms,string eventName,string eventType,string eventDescription, DateTime startDate,DateTime endDate,int userId)
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
            switch (eventType)
            {
                case "exposicao":
                {
                    EventBuilder ev = new ExpositionEventBuilder();
                    man.Construct(ev, rooms, eventName, startDate, endDate, eventDescription, userId);
                        break;
                }
                case "social":
                {
                    EventBuilder ev = new SocialEventBuilder();
                    man.Construct(ev, rooms, eventName, startDate, endDate, eventDescription, userId);
                        break;
                }
            }

          
            
           
        }
        /// <summary>
        /// aprovação de uma exibição
        /// </summary>
        /// <param name="eventId"></param>
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

        /// <summary>
        /// mudar um estado do evento
        /// </summary>
        /// <param name="state"></param>
        /// <param name="eventId"></param>
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


        /// <summary>
        /// listagem dos estados dos eventos
        /// </summary>
        /// <returns></returns>
        public List<EventType> GetListEventTypes()
        {
            return db.EventTypes.ToList();
            
        }
        /// <summary>
        /// listagem de eventos consoante o userId, eventState e o eventtype
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="eventState"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        public List<Events> GetEventsList(int userId, string eventState, string eventType)
        {
            var getEventState = GetEventState(eventState);
            var getEventType = GetEventType(eventType);
            var getUserAccout = userData.GetUserAccountBy(userId);
            var eventsList = db.Events.Include(d => d.UserAccount).Include(d => d.EventType).Include(d => d.EventState).Where(d => d.UserAccount.Id ==getUserAccout.Id && d.EventType.Name == getEventType.Name && d.EventState.Name == getEventState.Name).ToList();
            return eventsList;

        }

    }
}
