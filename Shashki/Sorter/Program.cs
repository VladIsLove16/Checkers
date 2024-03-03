using Sorter;
const int PaticipantCount= 6;
//добавь свою систему здесь
List<SortSystem> sortSystems=
[
    new RoundSort(PaticipantCount),
    new ScheveningenSystem(PaticipantCount),
    //Олимийская
    //Швейцарская
];
Console.WriteLine("Выбери систему сортировки");
int i = 0;
foreach (SortSystem sortSystem in sortSystems)
{
    Console.WriteLine(sortSystem.ToString() + " <--> "+i++);
}
int choosen = Convert.ToInt32(Console.ReadLine());
SortSystem choosenSortSystem = sortSystems[choosen];
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



