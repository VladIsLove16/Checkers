using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    internal class Team
    {
        public string Name { get; set; }
        public List<Participant> Participants { get; set; }
        public void Add(Participant p)
        {
            if (Participants == null) { Participants = new List<Participant>(); }
            Participants.Add(p);
        }
    }
}
