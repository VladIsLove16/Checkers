using Microsoft.Win32;
using Shashki;
string? choice;
var allowedTourTypeChoices = new[] { "1", "2" };
do
{
    Console.Clear();
    Console.WriteLine("Какой турнир создать?");
    Console.WriteLine("1. Круговой");
    Console.WriteLine("2. Швейцарский");
    choice = Console.ReadLine();
} while (!allowedTourTypeChoices.Contains(choice));

Tournament tournament = default!;
switch (choice)
{
    case "1": tournament = new RoundRobinTournament(); break;
    case "2":
        Console.WriteLine("Количество туров:");
        var roundCount = Console.ReadLine();
        tournament = new SwissTournament(int.Parse(roundCount!)); break;
}


var allowedChoices = new[] { "1", "2" };
do
{
    do
    {
        Console.Clear();
        Console.WriteLine($"Выберите действие для {tournament.Type} турнира:");
        Console.WriteLine("1. Добавить участника");
        Console.WriteLine("2. Начать турнир");
        choice = Console.ReadLine();
    } while (!allowedChoices.Contains(choice));

    switch (choice)
    {
        case "1":
            var participantAdded = false;
            do
            {
                try
                {
                    Console.WriteLine("Введите имя, пол, возраст, ранг через пробел: ");
                    string[] values = Console.ReadLine()!.Split(' ');
                    IParticipant participant = new Participant()
                    {
                        Name = values[0],
                        Gender = values[1] == "M" ? 0 : 1,
                        Age = int.Parse(values[2]),
                        Rank = (ParticipantRank)Enum.Parse(typeof(ParticipantRank), values[3])
                    };
                    tournament.AddParticipant(participant);
                    participantAdded = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!participantAdded);
            break;

        case "2":
            try
            {
                tournament.Start();
            }
            catch (OddParticipantCountException oddEx)
            {
                Console.WriteLine(oddEx.Message);
            }
            break;
    }
} while (!tournament.IsStarted);

while (!tournament.IsFinished)
{
    Console.WriteLine($"Round {tournament.CurrentRound}");
    var games = tournament.GetPairs(tournament.CurrentRound);
    var gameIndex = 0;
    foreach (var game in games)
    {
        Console.WriteLine($"{++gameIndex}. {game.PlayerWhite.Name} - {game.PlayerBlack.Name}");
    }
    Console.WriteLine($"Enter results (0 - white wins, 1 - draw, 2 - black wins):");
    for (int i = 1; i <= games.Length; i++)
    {
        Console.Write($"game #{i}: ");
        var result = Console.ReadLine();
        games[i - 1].Result = result switch
        {
            "0" => GameResult.WhiteWon,
            "1" => GameResult.Draw,
            "2" => GameResult.BlackWon,
            _ => GameResult.None
        };
    }
}
