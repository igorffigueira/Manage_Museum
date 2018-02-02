using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMuseumData.Factory
{
   public abstract class UserFactory
    {
        public AUser sp { get; set; }

        protected UserFactory()
        {

        }

        public abstract void createUser(string FirstName, string LastName, string Password, string Role, string Username);

    }
}
