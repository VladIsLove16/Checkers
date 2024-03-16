
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Registry
{
    internal class User
    {
        public User() { }
        public User(string Name , string Login, string Password) {
            this.Name = Name; 
            this.Login = Login;
            this.Password = Password;
        }   
        public string Name { get; set; }
        public string Login { get; set; }
         public string Password { get; set; }
    }
}
