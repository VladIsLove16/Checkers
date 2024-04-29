using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Db.Entities;

namespace TournamentManager.Db.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Patronymic { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        public virtual ICollection<UserSetting> UserSettings { get; set; } = default!;
    }
}