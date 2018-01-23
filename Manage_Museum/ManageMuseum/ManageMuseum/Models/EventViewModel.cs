using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ExpressiveAnnotations.Attributes;

namespace ManageMuseum.Models
{
    public class EventViewModel
    {
        public string Name { get; set; }
      
        public DateTime StartDate { get; set; }
        
        [AssertThat("Dates()", ErrorMessage = "A data de fim pode ser anterior à data de início ")]
        public DateTime EnDate { get; set; }
        

        public string RoomName { get; set; }
        public int SpaceId { get; set; }
        public string EventType { get; set; }
        public string Description { get; set; }
        public List<string> SpacesList { get; set; }
        public List<string> OutSideSpaces { get; set; }

        public bool Dates()
        {
            if (EnDate < StartDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
