using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    public class Game
    {
        public Participant WhitePlayer { get; }
        public Participant BlackPlayer { get; }

        public Game(Participant white, Participant black)
        {
            WhitePlayer = white;
            BlackPlayer = black;
        }
    }
}
