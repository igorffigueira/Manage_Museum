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

        /// <summary>
        /// metodo resposavel pela a criação de utilizadores
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="Role"></param>
        /// <param name="username"></param>
        public override void createUser(string firstName, string lastName, string password, string Role, string username)
        {
            var role = db.Roles.Single(s => s.Name == Role);
            sp = new UserAccount() { LastName = lastName, Password = password, FirstName = firstName, Role = role, Username = username };
            Insert();

        }

        private void Insert()
        {
            db.UserAccounts.Add((UserAccount)sp);
            db.SaveChanges();
        }
    }
}
