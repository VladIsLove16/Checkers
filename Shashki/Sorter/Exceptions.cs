using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentManager
{
    public class ParticipantExistsException : Exception
    {
        public IParticipant Participant { get; }
        public ParticipantExistsException(IParticipant participant)
        {
            Participant = participant;
        }
    }

    public class TournamentStartedException : Exception
    {
        public TournamentStartedException() : base("Tournament is already started") { }
    }

    public class TournamentNotStartedException : Exception
    {
        public TournamentNotStartedException() : base("Tournament is not started") { }
    }

    public class RoundNotExistException : Exception
    {
        public RoundNotExistException() : base("Round does not exist") { }
    }

    public class OddParticipantCountException : Exception
    {
        public OddParticipantCountException() : base("The number of participants is odd") { }
    }

    public class PreviousRoundNotFinishedException : Exception
    {
        public PreviousRoundNotFinishedException() : base("The previous round is not finished") { }
    }
}