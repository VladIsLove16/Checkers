// See https://aka.ms/new-console-template for more information
using  Registry;
UserList users = new UserList();
Console.WriteLine("Система Регистрации");
Console.WriteLine("1. Зарегистрироваться");
//Console.WriteLine("2. Войти");

Console.WriteLine("Ваше имя:");
string Name = Console.ReadLine();
Console.WriteLine("Введите логин: ");
string login= Console.ReadLine();
Console.WriteLine("Введите пароль: ");
string password= Console.ReadLine();

int status = RegistrySystem.Sign_up(Name,login, password);
if(status != 0)
{
    Console.WriteLine("Ошибка регистрации: "+status);
    return;
}
else
{
    Console.WriteLine("Успешная регистрация! ");
    Console.WriteLine("Для входа введите логин: ");
    login = Console.ReadLine();
    Console.WriteLine("Введите пароль: ");
    password = Console.ReadLine();
    status = RegistrySystem.Entrance(login, password);
    if (status != 0)
    {
        Console.WriteLine("Ошибка входа: " + status);
        return;
    }
    else
    {
        Console.WriteLine("Успешный вход, "+RegistrySystem.CurrentUser.Name );
    }
}

