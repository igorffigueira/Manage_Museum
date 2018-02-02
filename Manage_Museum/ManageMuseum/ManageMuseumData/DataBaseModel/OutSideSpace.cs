using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.DataBaseModel
{
    public class OutSideSpace
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public double Area { get; set; }
        public SpaceState SpaceState { get; set; } // State of the space free or busy
        public Events Event { get; set; }
    }
}
