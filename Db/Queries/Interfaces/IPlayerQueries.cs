using Db.DTOs;

namespace Db.Queries
{
    public interface IPlayerQueries
    {
        Task AddPlayerAsync(PlayerCreate player);
        Task AddPlayerToTournamentAsync(int playerId, int tournamentId);
        Task UpdatePlayerAsync(PlayerUpdate player);
        Task DeletePlayerFromTournamentAsync(int playerId, int tournamentId);
        Task DeletePlayerAsync(int playerId);
        Task<PlayerInfo?> GetPlayerAsync(int playerId);
        Task<ICollection<TournamentInfo>> GetTournamentsForPlayerAsync(int playerId);
    }
}