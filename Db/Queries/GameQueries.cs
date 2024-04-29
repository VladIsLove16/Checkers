using Db.DTOs;
using Microsoft.EntityFrameworkCore;
using TournamentManager.Db;
using TournamentManager.Db.Entities;

namespace Db.Queries
{
    public class GameQueries : IGameQueries
    {
        private TournamentDbContext _dbContext;
        public GameQueries(TournamentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddGameAsync(GameCreate game)
        {
            var addedGame = _dbContext.Games.Add(new Game()
            {
                Round = game.Round,
                TournamentId = game.TournamentId,
                ParticipantWhiteId = game.ParticipantWhiteId,
                ParticipantBlackId = game.ParticipantBlackId
            });
            await _dbContext.SaveChangesAsync();
            return addedGame.Entity.Id;
        }

        public async Task SetGameResultAsync(int gameId, int resultId)
        {
            var game = _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
            game!.ResultId = resultId;
            await _dbContext.SaveChangesAsync();
        }

        public async Task SetGameResultAsync(int gameId, string resultCode)
        {
            var game = _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
            game!.ResultId = _dbContext.Results.FirstOrDefault(r => r.Code == resultCode)?.Id;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int gameId)
        {
            var existingGame = _dbContext.Games.FirstOrDefault(g => g.Id == gameId);
            if (existingGame != default)
            {
                _dbContext.Games.Remove(existingGame);
                await _dbContext.SaveChangesAsync();
            }
        }

        /*Для MySql - пример запросов с Include*/
        /*
         public async Task<GameInfo?> GetGameAsync(int gameId)
        {
            return await (_dbContext.Games
                .Include(g => g.PlayerWhite)
                    .ThenInclude(p => p.PlayerRank)
                .Include(g => g.PlayerBlack)
                    .ThenInclude(p => p.PlayerRank)
                .Include(g => g.Result)
                .Where(g => g.Id == gameId)
                .Select(game => new GameInfo(
                              game.Id,
                              game.Round,
                              game.TournamentId,
                              new PlayerInfo(
                                  game.PlayerWhite.Id,
                                  game.PlayerWhite.Name,
                                  game.PlayerWhite.Age,
                                  game.PlayerWhite.Gender,
                                  new ReferenceItemInfo(
                                      game.PlayerWhite.RankId,
                                      game.PlayerWhite.PlayerRank.Code,
                                      game.PlayerWhite.PlayerRank.Description
                                  )
                              ),
                          new PlayerInfo(
                              game.PlayerBlack.Id,
                              game.PlayerBlack.Name,
                              game.PlayerBlack.Age,
                              game.PlayerBlack.Gender,
                              new ReferenceItemInfo(
                                  game.PlayerBlack.RankId,
                                  game.PlayerBlack.PlayerRank.Code,
                                  game.PlayerBlack.PlayerRank.Description
                              )
                          ),
                          new ReferenceItemInfo(
                              game.Result.Id,
                              game.Result.Code,
                              game.Result.Description
                          ))))
                          .FirstOrDefaultAsync();
        }
        */

        public async Task<GameInfo?> GetGameAsync(int gameId)
        {
            return await (from game in _dbContext.Games
                          join playerWhite in _dbContext.Players on game.ParticipantWhiteId equals playerWhite.Id
                          join playerBlack in _dbContext.Players on game.ParticipantBlackId equals playerBlack.Id
                          join playerWhiteRank in _dbContext.Ranks on playerWhite.RankId equals playerWhiteRank.Id
                          join playerBlackRank in _dbContext.Ranks on playerBlack.RankId equals playerBlackRank.Id
                          join result in _dbContext.Results on game.ResultId equals result.Id
                          where game.Id == gameId
                          select new GameInfo(
                              game.Id,
                              game.Round,
                              game.TournamentId,
                              new PlayerInfo(
                                  playerWhite.Id,
                                  playerWhite.Name,
                                  playerWhite.Age,
                                  playerWhite.Gender,
                                  new ReferenceItemInfo(
                                      playerWhite.RankId,
                                      playerWhiteRank.Code,
                                      playerWhiteRank.Description
                                  )
                              ),
                          new PlayerInfo(
                              playerBlack.Id,
                              playerBlack.Name,
                              playerBlack.Age,
                              playerBlack.Gender,
                              new ReferenceItemInfo(
                                  playerBlack.RankId,
                                  playerBlackRank.Code,
                                  playerBlackRank.Description
                              )
                          ),
                          new ReferenceItemInfo(
                              result.Id,
                              result.Code,
                              result.Description
                          ))).FirstOrDefaultAsync();
        }

        public async Task<ICollection<GameInfo>> GetGamesAsync(int tournamentId, int round)
        {
            return await (from game in _dbContext.Games
                          join playerWhite in _dbContext.Players on game.ParticipantWhiteId equals playerWhite.Id
                          join playerBlack in _dbContext.Players on game.ParticipantBlackId equals playerBlack.Id
                          join playerWhiteRank in _dbContext.Ranks on playerWhite.RankId equals playerWhiteRank.Id
                          join playerBlackRank in _dbContext.Ranks on playerBlack.RankId equals playerBlackRank.Id
                          join result in _dbContext.Results on game.ResultId equals result.Id
                          where game.TournamentId == tournamentId && game.Round == round
                          select new GameInfo(
                              game.Id,
                              game.Round,
                              game.TournamentId,
                              new PlayerInfo(
                                  playerWhite.Id,
                                  playerWhite.Name,
                                  playerWhite.Age,
                                  playerWhite.Gender,
                                  new ReferenceItemInfo(
                                      playerWhite.RankId,
                                      playerWhiteRank.Code,
                                      playerWhiteRank.Description
                                  )
                              ),
                              new PlayerInfo(
                                  playerBlack.Id,
                                  playerBlack.Name,
                                  playerBlack.Age,
                                  playerBlack.Gender,
                                  new ReferenceItemInfo(
                                      playerBlack.RankId,
                                      playerBlackRank.Code,
                                      playerBlackRank.Description
                                  )
                              ),
                              new ReferenceItemInfo(
                                  result.Id,
                                  result.Code,
                                  result.Description
                              ))).ToArrayAsync();
        }
    }
}