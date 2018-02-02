using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.Factory
{
    public abstract class AUser
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "First Name is Required")]

        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
