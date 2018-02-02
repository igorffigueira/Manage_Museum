using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.Factory;

namespace ManageMuseumData.DataBaseModel
{
    public class UserAccount : AUser
    {
        public Role Role { get; set; }
        public virtual ICollection<Events> Events { get; set; }
    }
}
