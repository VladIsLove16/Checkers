using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentManager.Db.Entities;

namespace Db.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;

        public virtual ICollection<Game> Games { get; set; } = default!;
    }
}