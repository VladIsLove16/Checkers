using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentManager
{
    public interface IRound
    {
        IGame[] Games { get; }
        void Add(IGame game);
        event EventHandler? RoundFinished;
    }
}