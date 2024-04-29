using Db.DTOs;

namespace Db.Queries
{
    public interface ITournamentQueries
    {
        Task AddTournamentAsync(TournamentCreate tournament);
        Task UpdateTournamentAsync(TournamentUpdate tournament);
        Task DeleteTournamentAsync(int tournamentId);
        Task<TournamentInfo?> GetTournamentAsync(string tournamentName);
    }
}