using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Models.SortSystems
{
    public abstract class SortSystem
    {
        public SortSystem()
        {
        }
        public abstract List<RoundGames> CreateTournamentSchedule();
    }
}
