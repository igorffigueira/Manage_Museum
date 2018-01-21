using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageMuseum.Models
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public  ICollection<Event> Events { get; set; }
    }
}