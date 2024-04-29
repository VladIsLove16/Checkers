using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentManager.Db.Entities
{
    public class TournamentParticipant
    {
        public int TournamentId { get; set; }
        public int PlayerId { get; set; }

        public virtual Tournament Tournament { get; set; } = default!;
        public virtual Player Player { get; set; } = default!;
    }
}