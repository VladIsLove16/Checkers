using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentManager.Db.Entities;

namespace Db.Entities
{
    public class UserSetting
    {
        public int UserId { get; set; }
        public int SettingId { get; set; }
        public string Value { get; set; } = default!;

        public virtual User User { get; set; } = default!;
        public virtual Setting Setting { get; set; } = default!;
    }
}