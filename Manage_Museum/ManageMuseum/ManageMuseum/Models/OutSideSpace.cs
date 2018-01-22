using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageMuseum.Models
{
    public class OutSideSpace
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public double Area { get; set; }
        public SpaceState SpaceState { get; set; } // State of the space free or busy
        public Event Event { get; set; }
    }
}