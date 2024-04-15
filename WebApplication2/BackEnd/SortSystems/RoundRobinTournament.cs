using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shashki
{
    public class RoundRobinTournament : Tournament
    {
        public override int RoundCount => rounds.Count;

        private void CreateTournamentSchedule()
        {
            var participantOrder = RandomizeParticipantOrder();
            for (int i = 0; i < participantOrder.Count - 1; i++)
            {
                var round = new Round();
                round.RoundFinished += OnRoundFinished;
                for (int pairIndex = 0; pairIndex < participantOrder.Count / 2; pairIndex++)
                {
                    var player1Order = participantOrder[pairIndex];
                    var player2Order = participantOrder[participantOrder.Count - 1 - pairIndex];
                    if (player1Order == 0 || player2Order == 0) continue;

                    var player1 = participants[player1Order - 1];
                    var player2 = participants[player2Order - 1];
            
                    if (rounds.Count > 0 && rounds[rounds.Count - 1].Games.FirstOrDefault(game => game.PlayerWhite == player1) != null)
                    {
                        round.Add(new Game(rounds.Count + 1, player2, player1));
                    }
                    else
                    {
                        round.Add(new Game(rounds.Count + 1, player1, player2));
                    }
                }
                rounds.Add(round);

                int elm = participantOrder[participantOrder.Count - 2];
                participantOrder.RemoveAt(participantOrder.Count - 2);
                participantOrder.Insert(0, elm);
            }
        }

        private List<int> RandomizeParticipantOrder()
        {
            var rnd = new Random();
            var startingElement = 1;
            var orderLength = participants.Count;
            if (participants.Count % 2 > 0)
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

        public override void Start()
        {
            CreateTournamentSchedule();
            base.Start();
        }

        public override IGame[] GetPairs(int round)
        {
            return rounds[round - 1].Games;
        }
    }
}