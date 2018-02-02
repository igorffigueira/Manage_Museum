using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.Builder
{
    public abstract class EventBuilder
    {
        public Events _event { get; set; }

        protected EventBuilder()
        {
            _event = new Events();
        }

        public abstract void AddSpace(List<string> spaces);
        public abstract void AddUser(int user);
        public abstract void AddEventState();
        public abstract void AddEventType();
        public abstract void AddEventDetails(string name, DateTime starTime, DateTime endDateTime, string description);
        public abstract void Save();


    }
}
