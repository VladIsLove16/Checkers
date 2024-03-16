using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shashki;

namespace Shashki.SortSystems
{
    public class RoundSort : SortSystem
    {
        private Participant[] participants;
        public RoundSort(int numberOfParticipants)
        {
            participants = new Participant[numberOfParticipants];
            for (int i = 0; i < numberOfParticipants; i++)
            {
                participants[i] = new Participant(i + 1);
            }
        }
        private List<int> RandomizeParticipantOrder()
        {
            var rnd = new Random();
            var startingElement = 1;
            var orderLength = participants.Length;
            if (participants.Length % 2 > 0)
            {
                startingElement--;
                orderLength++;
            }
            var participantOrder = Enumerable.Range(startingElement, orderLength).ToList();
            for (int i = 0; i < participantOrder.Count - 1; i += 1)
            {
                int swapIndex = rnd.Next(i, participantOrder.Count);
                if (swapIndex != i)
                {
                    int temp = participantOrder[i];
                    participantOrder[i] = participantOrder[swapIndex];
                    participantOrder[swapIndex] = temp;
                }
            }
            return participantOrder;
        }

        public override List<RoundGames> CreateTournamentSchedule()
        {
            var tournamentSchedule = new List<RoundGames>();
            var participantOrder = RandomizeParticipantOrder();
            for (int i = 0; i < participantOrder.Count - 1; i++)
            {
                var games = new RoundGames();
                for (int pairIndex = 0; pairIndex < participantOrder.Count / 2; pairIndex++)
                {
                    var player1Order = participantOrder[pairIndex];
                    var player2Order = participantOrder[participantOrder.Count - 1 - pairIndex];
                    if (player1Order == 0 || player2Order == 0) continue;

                    var player1 = participants[player1Order - 1];
                    var player2 = participants[player2Order - 1];

                    if (tournamentSchedule.Count > 0 && tournamentSchedule[tournamentSchedule.Count - 1].Find(game => game.WhitePlayer == player1) != null)
                    {
                        games.Add(player2, player1);
                    }
                    else
                    {
                        games.Add(player1, player2);
                    }
                }
                tournamentSchedule.Add(games);

                int elm = participantOrder[participantOrder.Count - 2];
                participantOrder.RemoveAt(participantOrder.Count - 2);
                participantOrder.Insert(0, elm);
            }
            return tournamentSchedule;
        }
    }
}