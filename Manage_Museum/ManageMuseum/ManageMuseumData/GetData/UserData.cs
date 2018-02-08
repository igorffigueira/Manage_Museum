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
        /// <summary>
        /// registo de um utilizador
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="role"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void RegisterUser(string firstName,string lastName, string role,string username,string password)
        {
            UserFactory factory = new CreateUser();
            factory.createUser(firstName,lastName,password,role,username);
        }
        /// <summary>
        /// obter um utilizador pelo seu id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserAccount GetUserAccountBy(int userId)
        {
            return db.UserAccounts.Single(d => d.Id == userId);
        }
        /// <summary>
        /// listagem de papeis que os utilizadores podem desempenhar
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoles()
        {
            return db.Roles.ToList();
        }
        /// <summary>
        /// validação do utilizador
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValid(string name, string password)
        {
                return db.UserAccounts.Any(u => u.Username == name && u.Password == password);   
        }
        /// <summary>
        /// obter o role de um user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Role(string name, string password)
        {      
                return db.UserAccounts.Where(u => u.Username == name && u.Password == password).Select(p => p.Role).First().Name;
        }

        /// <summary>
        /// obter um id de utilizador
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int GetId(string name, string password)
        {
                return db.UserAccounts.Where(u => u.Username == name && u.Password == password).Select(p => p.Id).First();
        }
    }
}
