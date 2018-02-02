using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.DataBaseModel
{
    public class SpaceState
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoomMuseum> RoomMuseums { get; set; }
    }
}
