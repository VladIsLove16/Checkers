using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shashki
{
    public enum ParticipantRank
    {
        G3, G2, G1, CM, FM, NM, IM, GM
    }

    public interface IParticipant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public ParticipantRank Rank { get; set; }
        public List<IGame> Games { get; }
        public double Score { get; }
    }
}