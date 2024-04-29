using System;
using System.Collections.Generic;

namespace WebApplication2.Models.SortSystems
{
    public class OlympicSortSystem : SortSystem
    {
        //        public List<RoundGames> CreateTournamentSchedule(int numberOfParticipants)
        //        {
        //            // Ensure the number of participants is valid
        //            if (numberOfParticipants <= 0)
        //                throw new ArgumentException("Number of participants must be greater than zero.");

        //            var tournamentSchedule = new List<RoundGames>();
        //            var participantOrder = RandomizeParticipantOrder(numberOfParticipants);

        //            // Loop through all rounds of the tournament
        //            for (int round = 0; round < numberOfParticipants - 1; round++)
        //            {
        //                var games = new RoundGames();

        //                // Pair participants for each round
        //                for (int pairIndex = 0; pairIndex < numberOfParticipants / 2; pairIndex++)
        //                {
        //                    // Determine the indices of the paired participants
        //                    int player1Index = participantOrder[pairIndex];
        //                    int player2Index = participantOrder[numberOfParticipants - 1 - pairIndex];

        //                    // Ensure the indices are valid
        //                    if (player1Index < 0 || player2Index < 0 || player1Index >= numberOfParticipants || player2Index >= numberOfParticipants)
        //                        throw new InvalidOperationException("Invalid participant index.");

        //                    // Add the pair to the games list
        //                    games.Add(player1Index + 1, player2Index + 1); // Adding 1 to convert from 0-based to 1-based index
        //                }

        //                // Add the games for this round to the tournament schedule
        //                tournamentSchedule.Add(games);

        //                // Rotate participant order for the next round
        //                int lastParticipantIndex = participantOrder[numberOfParticipants - 2];
        //                participantOrder.RemoveAt(numberOfParticipants - 2);
        //                participantOrder.Insert(0, lastParticipantIndex);
        //            }

        //            return tournamentSchedule;
        //        }

        //        private List<int> RandomizeParticipantOrder(int numberOfParticipants)
        //        {
        //            var rnd = new Random();
        //            var participantOrder = new List<int>();

        //            // Generate a list of participant indices
        //            for (int i = 0; i < numberOfParticipants; i++)
        //            {
        //                participantOrder.Add(i);
        //            }

        //            // Shuffle the list using Fisher-Yates algorithm
        //            for (int i = numberOfParticipants - 1; i > 0; i--)
        //            {
        //                int swapIndex = rnd.Next(0, i + 1);
        //                int temp = participantOrder[i];
        //                participantOrder[i] = participantOrder[swapIndex];
        //                participantOrder[swapIndex] = temp;
        //            }

        //            return participantOrder;
        //        }
        public override List<RoundGames> CreateTournamentSchedule()
        {
            throw new NotImplementedException();
        }
    }
}
