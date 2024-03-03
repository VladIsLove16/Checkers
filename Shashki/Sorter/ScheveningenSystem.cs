using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СхевенингерскаяСистема
{
    internal class ScheveningenSystem : SortSystem
    {
        private Team Team1 = new Team();
        private Team Team2 = new Team();
        public ScheveningenSystem(Team team1, Team team2) 
        { 
            (Team1,Team2)=(team1,team2);
        }
        public ScheveningenSystem(int numberOfParticipants)
        {
            for (int i = 0; i < numberOfParticipants; i++)
            {
                Team1.Add(new Participant(i));
                Team2.Add(new Participant(i + numberOfParticipants));
            }
            Console.WriteLine(Team2.Participants.Count);
        }
        public override List<RoundGames> CreateTournamentSchedule()
        {
            List < RoundGames > Schedule = new List< RoundGames >();
            int ParticipantsCount = Team1.Participants.Count;
            int roundAddition = 0;
            for (int j = 0; j < ParticipantsCount; j++)
            {
                RoundGames roundGames = new RoundGames();
                for (int i = 0; i < ParticipantsCount; i++)
                {
                    Game game = new Game(Team1.Participants[i], Team2.Participants[(i + roundAddition) % ParticipantsCount]);
                    roundGames.Add(game);
                }
                roundAddition++;
                Schedule.Add(roundGames);
            }
            return Schedule;
        }
    }
}
