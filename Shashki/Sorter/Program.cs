using Sorter;
using System.Buffers;
using System.Reflection;
const int PaticipantCount= 6;
//добавь свою систему здесь
Type[] sortSystems = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(SortSystem).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .ToArray();
Console.WriteLine("Выбери систему сортировки");
int i = 0;
List<SortSystem> sortSystems1 = new List<SortSystem>();
object[] constructorParams = { PaticipantCount
};
foreach (Type type in sortSystems)
{
    ConstructorInfo constructor = type.GetConstructor(new[] { typeof(int) });
    if (constructor != null)
    {
        // Создаем объект с помощью конструктора и параметров
        SortSystem obj = (SortSystem)constructor.Invoke(constructorParams);
        sortSystems1.Add(obj);
    }
    Console.WriteLine(type.ToString() + " <--> "+i++);
}
int choosen = Convert.ToInt32(Console.ReadLine());
SortSystem choosenSortSystem = sortSystems1[choosen];
List<RoundGames> tournamentRounds = choosenSortSystem.CreateTournamentSchedule();
Print(tournamentRounds);
void Print(List<RoundGames> tournamentRounds)
{
    foreach (RoundGames round in tournamentRounds)
    {
        Console.WriteLine($"Раунд {tournamentRounds.IndexOf(round) + 1}:");
        foreach (var game in round)
        {
            Console.WriteLine($"Белые {game.WhitePlayer.Number} <--> {game.BlackPlayer.Number} Черные");
        }
        Console.WriteLine();
    }
}



