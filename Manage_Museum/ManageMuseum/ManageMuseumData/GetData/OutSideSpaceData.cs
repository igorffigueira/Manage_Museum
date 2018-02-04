using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

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

        public List<OutSideSpace> GetListOutSideSpacesByState(string state)
        {
            var getState = db.SpaceStates.First(d => d.Name == state); // Estado de sala livre
            return db.OutSideSpaces.Where(d => d.SpaceState.Name == getState.Name).ToList();
        }

    }
}
