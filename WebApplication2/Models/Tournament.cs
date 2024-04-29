using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.Interfaces;
using WebApplication2.Models.SortSystems;
namespace WebApplication2.Models
{
    public class Tournament
    {
        public SortSystem SortSystem { get; set; }
        public int Id;
        public Judge Judge { get; set; }
        private int currentRound;
        private bool isStarted = false;
        private bool isFinished = false;
        protected List<IParticipant> participants = new();
        protected List<IRound> rounds = new();
        

        public int ParticipantCount => participants.Count;

        public int RoundCount { get; }

        public int CurrentRound => currentRound;

        public bool IsStarted => isStarted;

        public bool IsFinished => isFinished;

        public void AddParticipant(IParticipant participant)
        {
            if (IsStarted)
                throw new TournamentStartedException();
            if (participants.Find(p => p.Name == participant.Name && p.Age == participant.Age && p.Gender == participant.Gender) == null)
                participants.Add(participant);
            else
                throw new ParticipantExistsException(participant);
        }

        public ITable GetTournamentTable()
        {
            throw new NotImplementedException();
        }

        public void RemoveParticipant(Guid id)
        {
            if (IsStarted)
                throw new TournamentStartedException();
            participants.RemoveAll(p => p.Id == id);
        }

        public virtual void Start()
        {
            currentRound = 1;
            isStarted = true;
        }

        public IGame[] UnfinishedGamesInPreviousRound()
        {
            var prevoiusRoundIndex = CurrentRound - 2;
            if (prevoiusRoundIndex < 0) return Array.Empty<IGame>();
            return rounds[prevoiusRoundIndex].Games.Where(g => g.Result == GameResult.None).ToArray();
        }

        public IGame[] UnfinishedGamesInCurrentRound()
        {
            var currentRoundIndex = CurrentRound - 1;
            if (currentRoundIndex < 0) return Array.Empty<IGame>();
            return rounds[currentRoundIndex].Games.Where(g => g.Result == GameResult.None).ToArray();
        }

        public void OnRoundFinished(object? sender, EventArgs e)
        {
            currentRound++;
            if (currentRound > RoundCount)
            {
                currentRound = RoundCount;
                isFinished = true;
            }
        }
    }
}