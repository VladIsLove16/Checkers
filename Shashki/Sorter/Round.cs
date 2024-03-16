using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shashki
{
    public class Round : List<IGame>, IRound
    {
        public IGame[] Games => ToArray();
        public event EventHandler? RoundFinished;

        public new void Add(IGame game)
        {
            game.ResultSet += OnGameResultSet;
            base.Add(game);
        }

        public void OnGameResultSet(object? sender, EventArgs e)
        {
            if (this.All(game => game.Result != GameResult.None))
            {
                RoundFinished?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}