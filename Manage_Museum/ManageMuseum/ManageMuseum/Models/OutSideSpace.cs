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
        public Event Event { get; set; }
    }
}