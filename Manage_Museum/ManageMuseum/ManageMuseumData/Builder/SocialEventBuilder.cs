using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.Builder
{
    public class SocialEventBuilder : EventBuilder
    {
        private DbAccess db = new DbAccess();



        public override void AddSpace(List<string> spaces)
        {
            List<OutSideSpace> rooms = new List<OutSideSpace>();
            var ocupied = db.SpaceStates.Single(s => s.Name == "ocupada");
            foreach (var item in spaces)
            {
                var aux = db.OutSideSpaces.Single(s => s.Name == item);
                aux.SpaceState = ocupied;
                rooms.Add(aux);
            }


            _event.OutSideSpaces = rooms;
        }

        public override void AddUser(int user)
        {
            var uu = db.UserAccounts.Include("Role").Single(s => s.Id == user);

            _event.UserAccount = uu;
        }

        public override void AddEventState()
        {

            var state = db.EventStates.Single(s => s.Name == "aceites");
            _event.EventState = state;


        }

        public override void AddEventType()
        {
            var type = db.EventTypes.Single(s => s.Name == "social");
            _event.EventType = type;
        }

        public override void AddEventDetails(string name, DateTime starTime, DateTime endDateTime, string description)
        {
            _event.Name = name;
            _event.StartDate = starTime;
            _event.EnDate = endDateTime;
            _event.Description = description;

        }


        public override void Save()
        {
            db.Events.Add(_event);
            db.SaveChanges();
        }
    }
}
