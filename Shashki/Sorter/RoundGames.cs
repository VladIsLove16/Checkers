using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    public class RoundGames : List<Game>
    {
        public void Add(Participant white, Participant black)
        {
            Add(new Game(white, black));
        }
    }
}
