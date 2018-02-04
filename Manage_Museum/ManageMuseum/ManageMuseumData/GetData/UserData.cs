using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageMuseumData.DataBaseModel;
using ManageMuseumData.Factory;

namespace ManageMuseumData.GetData
{
    public class UserData : AData
    {
        public void RegisterUser(string firstName,string lastName, string role,string username,string password)
        {
            UserFactory factory = new CreateUser();
            factory.createUser(firstName,lastName,password,role,username);
        }

        public UserAccount GetUserAccountBy(int userId)
        {
            return db.UserAccounts.Single(d => d.Id == userId);
        }

        public List<Role> GetRoles()
        {
            return db.Roles.ToList();
        }

        public bool IsValid(string name, string password)
        {
                return db.UserAccounts.Any(u => u.Username == name && u.Password == password);   
        }

        public string Role(string name, string password)
        {      
                return db.UserAccounts.Where(u => u.Username == name && u.Password == password).Select(p => p.Role).First().Name;
        }

        public int GetId(string name, string password)
        {
                return db.UserAccounts.Where(u => u.Username == name && u.Password == password).Select(p => p.Id).First();
        }
    }
}
