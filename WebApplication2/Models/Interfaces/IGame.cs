using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.Interfaces
{
    public enum GameResult
    {
        None, WhiteWon, BlackWon, Draw
    }

    public interface IGame
    {
        public int Round { get; }
        public IParticipant PlayerWhite { get; }
        public IParticipant PlayerBlack { get; }
        public GameResult Result { get; set; }
        public event EventHandler? ResultSetted;
    }
}