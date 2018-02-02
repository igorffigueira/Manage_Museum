using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.Builder
{

    public class Manager
    {
        public void Construct(EventBuilder eventBuilder, List<string> spaces, string name, DateTime starTime, DateTime endDateTime, string description, int user)
        {

            eventBuilder.AddSpace(spaces);

            eventBuilder.AddUser(user);
            eventBuilder.AddEventState();
            eventBuilder.AddEventType();
            eventBuilder.AddEventDetails(name, starTime, endDateTime, description);
            eventBuilder.Save();

        }
    }
}
