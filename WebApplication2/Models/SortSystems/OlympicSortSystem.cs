using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Models.SortSystems
{
    public class OlympicSortSystem : SortSystem
    {
        private readonly List<Participant> participants;

        public OlympicSortSystem(List<Participant> participants)
        {
            this.participants = participants ?? throw new ArgumentNullException(nameof(participants));
        }

        public override List<RoundGames> CreateTournamentSchedule()
        {
            if (participants.Count % 2 != 0)
            {
                throw new InvalidOperationException("The number of participants must be even for an Olympic-style tournament.");
            }

            var tournamentSchedule = new List<RoundGames>();
            var shuffledParticipants = participants.OrderBy(p => Guid.NewGuid()).ToList();

            int numRounds = shuffledParticipants.Count - 1;

            for (int roundIndex = 0; roundIndex < numRounds; roundIndex++)
            {
                var games = new RoundGames();

                for (int pairIndex = 0; pairIndex < shuffledParticipants.Count / 2; pairIndex++)
                {
                    var player1 = shuffledParticipants[pairIndex];
                    var player2 = shuffledParticipants[shuffledParticipants.Count - 1 - pairIndex];

                    games.Add(player1, player2);
                }

                tournamentSchedule.Add(games);

                // Rotate participants for the next round (swap positions)
                var lastParticipant = shuffledParticipants.Last();
                shuffledParticipants.RemoveAt(shuffledParticipants.Count - 1);
                shuffledParticipants.Insert(1, lastParticipant);
            }

            return tournamentSchedule;
        }
    }
}
