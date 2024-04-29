using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Db.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;

        public virtual ICollection<UserSetting> UserSettings { get; set; } = default!;
    }
}