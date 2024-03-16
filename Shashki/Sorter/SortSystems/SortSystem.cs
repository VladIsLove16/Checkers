using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shashki.SortSystems
{
    public abstract class SortSystem
    {
        public SortSystem()
        {
        }
        public abstract List<RoundGames> CreateTournamentSchedule();
    }
}
