using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;

namespace ManageMuseumData.Factory
{
    class CreateUser : UserFactory
    {
        private DbAccess db = new DbAccess();
        public override void createUser(string FirstName, string LastName, string Password, string Role, string Username)
        {
            var role = db.Roles.Single(s => s.Name == Role);
            sp = new UserAccount() { LastName = LastName, Password = Password, FirstName = FirstName, Role = role, Username = Username };
            Insert();

        }



        private void Insert()
        {
            db.UserAccounts.Add((UserAccount)sp);
            db.SaveChanges();
        }
    }
}
