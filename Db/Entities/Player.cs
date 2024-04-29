namespace TournamentManager.Db.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public char Gender { get; set; }
        public int RankId { get; set; }

        public virtual ICollection<TournamentParticipant> TournamentParticipants { get; set; } = default!;
        public virtual Rank PlayerRank { get; set; } = default!;
        public virtual ICollection<Game> GamesWhite { get; set; } = default!;
        public virtual ICollection<Game> GamesBlack { get; set; } = default!;
    }
}