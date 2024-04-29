using Db.DTOs;
using Microsoft.EntityFrameworkCore;
using TournamentManager.Db;
using TournamentManager.Db.Entities;

namespace Db.Queries
{
    public class PlayerQueries : IPlayerQueries
    {
        private TournamentDbContext _dbContext;
        public PlayerQueries(TournamentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPlayerAsync(PlayerCreate player)
        {
            _dbContext.Players.Add(new Player()
            {
                Name = player.Name,
                Age = player.Age,
                Gender = player.Gender,
                RankId = player.RankId
            });

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddPlayerToTournamentAsync(int playerId, int tournamentId)
        {
            var existingPlayer = _dbContext.Players.FirstOrDefault(p => p.Id == playerId);
            var existingTournament = _dbContext.Tournaments.FirstOrDefault(t => t.Id == tournamentId);
            if (existingPlayer != default && existingTournament != default)
            {
                _dbContext.TournamentParticipants.Add(new TournamentParticipant()
                {
                    TournamentId = tournamentId,
                    PlayerId = playerId
                });

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdatePlayerAsync(PlayerUpdate player)
        {
            var existingPlayer = _dbContext.Players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != default)
            {
                existingPlayer.Name = player.Name;
                existingPlayer.Age = player.Age;
                existingPlayer.Gender = player.Gender;
                existingPlayer.RankId = player.RankId;

                _dbContext.Players.Update(existingPlayer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePlayerFromTournamentAsync(int playerId, int tournamentId)
        {
            var existingPlayerInTournament = _dbContext.TournamentParticipants.FirstOrDefault(tp => tp.PlayerId == playerId && tp.TournamentId == tournamentId);
            if (existingPlayerInTournament != default)
            {
                _dbContext.TournamentParticipants.Remove(existingPlayerInTournament);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePlayerAsync(int playerId)
        {
            var existingPlayer = _dbContext.Players.FirstOrDefault(p => p.Id == playerId);
            if (existingPlayer != default)
            {
                _dbContext.Players.Remove(existingPlayer);

                var existingPlayerInTournament = _dbContext.TournamentParticipants.FirstOrDefault(t => t.PlayerId == playerId);
                if (existingPlayerInTournament != default)
                {
                    _dbContext.TournamentParticipants.RemoveRange(_dbContext.TournamentParticipants.Where(t => t.PlayerId == playerId));
                }

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PlayerInfo?> GetPlayerAsync(int playerId)
        {
            return await (from player in _dbContext.Players
                          join rank in _dbContext.Ranks on player.RankId equals rank.Id
                          where player.Id == playerId
                          select new PlayerInfo(
                              player.Id,
                              player.Name,
                              player.Age,
                              player.Gender,
                              new ReferenceItemInfo(
                                  player.RankId,
                                  rank.Code,
                                  rank.Description
                              ))).FirstOrDefaultAsync();
        }

        public async Task<ICollection<TournamentInfo>> GetTournamentsForPlayerAsync(int playerId)
        {
            return await (from tournament in _dbContext.Tournaments
                          join participants in _dbContext.TournamentParticipants on tournament.Id equals participants.TournamentId
                          join tournamentType in _dbContext.TournamentTypes on tournament.TypeId equals tournamentType.Id
                          where participants.PlayerId == playerId
                          select new TournamentInfo(
                                  tournament.Id,
                                  tournament.Name,
                                  tournament.TypeId,
                                  new ReferenceItemInfo(
                                      tournament.TypeId,
                                      tournamentType.Code,
                                      tournamentType.Name
                                  ),
                                  tournament.Started,
                                  tournament.Finished
                              )).ToArrayAsync();
        }
    }
}