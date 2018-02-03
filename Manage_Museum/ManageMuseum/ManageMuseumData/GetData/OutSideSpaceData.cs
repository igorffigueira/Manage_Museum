using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.GetData
{
    public class OutSideSpaceData : AData
    {

        public void DetachOutSideSpacesFromEvent(int eventId)
        {
            var outSide = db.OutSideSpaces.Include(d => d.Event).Where(d => d.Event.Id == eventId).ToList();
            foreach (var item in outSide)
            {
                item.Event = null;
                db.SaveChanges();
            }
        }

    }
}
