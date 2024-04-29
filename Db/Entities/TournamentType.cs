using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentManager.Db.Entities
{
    public class TournamentType
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;

        public virtual ICollection<Tournament> Tournaments { get; set; } = default!;
    }
}