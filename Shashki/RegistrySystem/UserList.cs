using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Registry
{
    internal class UserList
    {
        private Dictionary<string, User> users=new Dictionary<string, User>();   
        public UserList() { }
        public void Add (User user) { 
            users[user.Login]=user;
        }
        public void Remove (User user) { 
            users.Remove(user.Login);
        }
        public User GetUserByLogin(string login)
        {
            return users[login];
        }
        public bool Contain(string login)
        {
            return users.ContainsKey(login);
        }
    }
}
