using Db.Entities;

namespace TournamentManager.Db.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public int TournamentId { get; set; }
        public int ParticipantWhiteId { get; set; }
        public int ParticipantBlackId { get; set; }
        public int? ResultId { get; set; }

        public virtual Player PlayerWhite { get; set; } = default!;
        public virtual Player PlayerBlack { get; set; } = default!;
        public virtual Tournament Tournament { get; set; } = default!;
        public virtual Result Result { get; set; } = default!;
    }
}