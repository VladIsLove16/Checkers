using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.Interfaces;

namespace WebApplication2.Models.SortSystems
{
    public class SwissSortSystem : SortSystem
    {
        //        private int roundCount;

        //        public SwissTournament(int rounds)
        //        {
        //            roundCount = rounds;
        //        }

        //        public override int RoundCount => roundCount;

        //        public override IGame[] GetPairs(int roundNum)
        //        {
        //            if (!IsStarted) throw new TournamentNotStartedException();
        //            if (roundNum > CurrentRound) throw new RoundNotExistException();
        //            if (roundNum == CurrentRound && rounds.Count < CurrentRound)
        //            {
        //                if (UnfinishedGamesInPreviousRound().Any()) throw new PreviousRoundNotFinishedException();
        //                // new round
        //                IRound round = new Round();
        //                round.RoundFinished += OnRoundFinished;
        //                var roundParticipants = participants.OrderByDescending(p => p.Score).Select((p, i) => (IsTaken: false, Index: i, Participant: p)).ToArray();

        //                while (roundParticipants.Any(p => !p.IsTaken))
        //                {
        //                    var rp1 = roundParticipants.First(p => !p.IsTaken);
        //                    var rp2 = roundParticipants.Skip(rp1.Index + 1).First(p => !p.IsTaken);
        //                    var playedWhite1 = rp1.Participant.Games.Count(x => x.PlayerWhite == rp1.Participant);
        //                    var playedWhite2 = rp2.Participant.Games.Count(x => x.PlayerWhite == rp2.Participant);
        //                    var game = new Game(CurrentRound,
        //                        playedWhite1 < playedWhite2 ? rp1.Participant : rp2.Participant,
        //                        playedWhite1 >= playedWhite2 ? rp1.Participant : rp2.Participant);
        //                    round.Add(game);
        //                    rp1.Participant.Games.Add(game);
        //                    rp2.Participant.Games.Add(game);
        //                    roundParticipants[rp1.Index].IsTaken = roundParticipants[rp2.Index].IsTaken = true;
        //                }
        //                rounds.Add(round);

        //            }
        //            return rounds[roundNum - 1].Games;
        //        }

        //        public override void Start()
        //        {
        //            if (participants.Count % 2 > 0) throw new OddParticipantCountException();
        //            base.Start();
        //        }
        public override List<RoundGames> CreateTournamentSchedule()
        {
            throw new NotImplementedException();
        }
    }
}