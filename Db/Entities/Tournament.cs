using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentManager.Db.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int TypeId { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }

        public virtual ICollection<TournamentParticipant> TournamentParticipants { get; set; } = default!;
        public virtual ICollection<Game> Games { get; set; } = default!;
        public virtual TournamentType TournamentType { get; set; } = default!;
    }
}