using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shashki
{
    public class Participant : IParticipant
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public int Gender { get; set; }
        public ParticipantRank Rank { get; set; }
        public List<IGame> Games { get; } = new();
        public int IntID { get; set; }
        public double Score
        {
            get => Games.Sum(g =>
                (g.PlayerWhite == this && g.Result == GameResult.WhiteWon)
                || (g.PlayerBlack == this && g.Result == GameResult.BlackWon) ? 1 :
                    (g.Result == GameResult.Draw ? 0.5 : 0));
        }

        public Participant()
        {

        }
        public Participant(int ID)
        {
            IntID = ID;
        }
    }
}