using Db.DTOs;

namespace Db.Queries
{
    public interface IGameQueries
    {
        Task<int> AddGameAsync(GameCreate game);
        Task SetGameResultAsync(int gameId, int resultId);
        Task SetGameResultAsync(int gameId, string resultCode);
        Task DeleteGameAsync(int gameId);
        Task<GameInfo?> GetGameAsync(int gameId);
        Task<ICollection<GameInfo>> GetGamesAsync(int tournamentId, int round);
    }
}