using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Registry 
{
    static class RegistrySystem
    {
        static private UserList users=new UserList();
        static public User CurrentUser;
        //0-вход успешен
        //1-неправильная пара логин - пароль
        //2-введенные данные не соответствуют формату
        static public int Entrance(string login, string password)
        {
           if(!IsValid(login))
                return 2;
            if(!users.Contain(login))
                return 1;
            if(users.GetUserByLogin(login).Password!= password)
                return 1;
            CurrentUser=users.GetUserByLogin(login);
            return 0;
        }
        //0-регистрация успешна 
        //1-логин уже существует
        //2-введенные данные не соответствуют формату
        static public int Sign_up(string Name, string login, string password)
        {
            if(!IsValid(login))
            {
                return 2;
            }
            if(users.Contain(login))
                return 1;
            users.Add(new User(Name, login, password));
            return 0;

        }
        static private bool IsValid(string a)
        {
            return true;    
        }
    };
}
