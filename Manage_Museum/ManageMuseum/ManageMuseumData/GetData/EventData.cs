using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.GetData
{
   public class EventData : AData
    {
      

        public Events GetEvent(RoomMuseum room)
        {
            var eventData = db.Events.First(d => d.Id == room.Event.Id);

            return eventData;
        }

        public Events GetEventById(int id)
        {
            return db.Events.Include("EventState").Include("RoomMuseums").Include("EventType").Include("UserAccount").First(d => d.Id == id);
        }

        public List<Events> GetListEvents(string state)
        {
            var getExhibitionAcceptedState = db.EventStates.Include("Events").Single(s => s.Name == state);
            var ExhibitionAccepted = db.Events.Include("EventType").Include("UserAccount").Include("OutSideSpaces").Include("EventState").Where(d => d.EventState.Name == getExhibitionAcceptedState.Name).ToList();
            return ExhibitionAccepted;
        }
    }
}
