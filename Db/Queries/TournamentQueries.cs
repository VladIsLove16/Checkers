using Db.DTOs;
using Microsoft.EntityFrameworkCore;
using TournamentManager.Db;
using TournamentManager.Db.Entities;

namespace Db.Queries
{
    public class TournamentQueries : ITournamentQueries
    {
        private TournamentDbContext _dbContext;

        public TournamentQueries(TournamentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddTournamentAsync(TournamentCreate tournament)
        {
            var existingTournament = _dbContext.Tournaments.FirstOrDefault(t => t.Name == tournament.Name);
            if (existingTournament == default)
            {
                _dbContext.Tournaments.Add(new Tournament()
                {
                    Name = tournament.Name,
                    TypeId = tournament.TypeId
                });
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateTournamentAsync(TournamentUpdate tournament)
        {
            var existingTournament = _dbContext.Tournaments
                .FirstOrDefault(t => t.Name == tournament.Name);
            if (existingTournament != default)
            {
                existingTournament.Name = tournament.Name;
                existingTournament.TypeId = tournament.TypeId;
                _dbContext.Tournaments.Update(existingTournament);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteTournamentAsync(int tournamentId)
        {
            var existingTournament = _dbContext.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if (existingTournament != default)
            {
                _dbContext.Tournaments.Remove(existingTournament);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<TournamentInfo?> GetTournamentAsync(string tournamentName)
        {
            return await (from tournament in _dbContext.Tournaments
                          join tournamentType in _dbContext.TournamentTypes on tournament.TypeId equals tournamentType.Id
                          where tournament.Name == tournamentName
                          select new TournamentInfo(
                              tournament.Id,
                              tournament.Name,
                              tournament.TypeId,
                              new ReferenceItemInfo(
                                  tournamentType.Id,
                                  tournamentType.Code,
                                  tournamentType.Name
                              ),
                              tournament.Started,
                              tournament.Finished
                          )).FirstOrDefaultAsync();
        }
    }
}