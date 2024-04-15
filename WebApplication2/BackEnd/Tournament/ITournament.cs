using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shashki
{
    public enum TournamentType
    {
        RoundRobin, Swiss, Ganutlet
    }

    public interface ITournament
    {
        public int ParticipantCount { get; }
        public int RoundCount { get; }
        public int CurrentRound { get; }
        public TournamentType Type { get; }
        public bool IsStarted { get; }
        public bool IsFinished { get; }
        public void AddParticipant(IParticipant participant);
        public void RemoveParticipant(Guid id);
        public void Start();
        public IGame[] GetPairs(int roundNum);
        public IGame[] UnfinishedGamesInCurrentRound();
        public ITable GetTournamentTable();
    }
}