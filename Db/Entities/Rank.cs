using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentManager.Db.Entities
{
    public class Rank
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;

        public virtual ICollection<Player> Players { get; set; } = default!;
    }
}