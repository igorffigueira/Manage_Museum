using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;

namespace ManageMuseum.Models
{
    class UserManager
    {
        public bool IsValid(string name, string password)
        {
            using (var db = new OurContectDb())
            {
                return db.UserAccounts.Any(u => u.Username == name && u.Password == password);
            }
        }

        public int Role(string name, string password)
        {
         
                using (var db = new OurContectDb())
                {
                    return db.UserAccounts.Where(u => u.Username == name && u.Password == password).Select(p => p.Role).First().Id;

                }
            
        }

        public int GetId(string name, string password)
        {
            using (var db = new OurContectDb())
            {
                return db.UserAccounts.Where(u => u.Username == name && u.Password == password).Select(p => p.Id).First();
            }
        }
    }
}