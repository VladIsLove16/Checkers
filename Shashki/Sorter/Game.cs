using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shashki
{
    public class Game : IGame
    {
        private GameResult gameResult;
        public Game(int round, IParticipant participantWhite, IParticipant participantBlack)
        {
            Round = round;
            PlayerWhite = participantWhite;
            PlayerBlack = participantBlack;
        }
        public Game(IParticipant participantWhite, IParticipant participantBlack)
        {
            PlayerWhite = participantWhite;
            PlayerBlack = participantBlack;
        }
        public int Round { get; }

        public IParticipant PlayerWhite { get; }

        public IParticipant PlayerBlack { get; }
        public GameResult Result
        {
            get
            {
                return gameResult;
            }
            set
            {
                gameResult = value;
                ResultSetted?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? ResultSetted;
    }
}