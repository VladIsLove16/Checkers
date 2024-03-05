using Sorter;
const int PaticipantCount= 6;
using System;

class CheckersGame
{
    private char[,] board;
    private char currentPlayer;
    private bool gameEnded;

    public CheckersGame()
    {
        board = new char[8, 8];
        InitializeBoard();
        currentPlayer = 'X';
        gameEnded = false;
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board[i, j] = '_';
            }
        }
    }

    private void PrintBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private bool IsValidMove(int startRow, int startCol, int endRow, int endCol)
    {
        // Add your move validation logic here
        return true; // Placeholder - always return true for now
    }

    private void MakeMove(int startRow, int startCol, int endRow, int endCol)
    {
        if (IsValidMove(startRow, startCol, endRow, endCol))
        {
            board[endRow, endCol] = board[startRow, startCol];
            board[startRow, startCol] = '_';
        }
        else
        {
            Console.WriteLine("Invalid move. Try again.");
        }
    }

    public void Play()
    {
        while (!gameEnded)
        {
            PrintBoard();
            Console.WriteLine("Current Player: " + currentPlayer);
            Console.Write("Enter start row (0-7): ");
            int startRow = int.Parse(Console.ReadLine());
            Console.Write("Enter start column (0-7): ");
            int startCol = int.Parse(Console.ReadLine());
            Console.Write("Enter end row (0-7): ");
            int endRow = int.Parse(Console.ReadLine());
            Console.Write("Enter end column (0-7): ");
            int endCol = int.Parse(Console.ReadLine());

            MakeMove(startRow, startCol, endRow, endCol);

            // Change player
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }

    static void Main(string[] args)
    {
        CheckersGame game = new CheckersGame();
        game.Play();
    }
}
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



