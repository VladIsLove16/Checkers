using Db.DTOs;
using Microsoft.EntityFrameworkCore;
using TournamentManager.Db;
using TournamentManager.Db.Entities;

namespace Db.Queries
{
    public class UserQueries : IUserQueries
    {
        private TournamentDbContext _dbContext;

        public UserQueries(TournamentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(UserCreate user)
        {
            var existingUser = _dbContext.Users.Include(x => x.UserSettings).FirstOrDefault(u => u.Email == user.Email);
            // existingUser = (from u in _dbContext.Users
            //                 where u.Email == user.Email
            //                 select u).FirstOrDefault();
            if (existingUser == default)
            {
                _dbContext.Users.Add(new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Patronymic = user.Patronymic,
                    Email = user.Email,
                    Password = user.Password,
                    UserSettings = user.Settings.Select(s => new Entities.UserSetting()
                    {
                        SettingId = s.Id,
                        Value = s.Value
                    }).ToArray()
                });
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(UserUpdate user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            // existingUser = (from u in _dbContext.Users
            //                 where u.Email == user.Email
            //                 select u).FirstOrDefault();
            if (existingUser != default)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Patronymic = user.Patronymic;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.UserSettings = user.Settings.Select(s => new Entities.UserSetting()
                {
                    SettingId = s.Id,
                    Value = s.Value
                }).ToArray();
                _dbContext.Users.Update(existingUser);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(string email)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (existingUser != default)
            {
                _dbContext.Users.Remove(existingUser);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<UserInfo?> GetUserAsync(string email)
        {
            var userWithSettings = await (from user in _dbContext.Users
                                          join userSetting in _dbContext.UserSettings on user.Id equals userSetting.UserId
                                          join setting in _dbContext.Settings on userSetting.SettingId equals setting.Id
                                          where user.Email == email
                                          select new
                                          {
                                              user.Id,
                                              user.FirstName,
                                              user.LastName,
                                              user.Patronymic,
                                              user.Email,
                                              user.Password,
                                              SettingId = setting.Id,
                                              SettingCode = setting.Code,
                                              SettingDescription = setting.Description,
                                              SettingValue = userSetting.Value
                                          }).ToArrayAsync();
            return (from user in userWithSettings
                    group user by new
                    {
                        user.Id,
                        user.FirstName,
                        user.LastName,
                        user.Patronymic,
                        user.Email,
                        user.Password
                    } into userGroup
                    select new UserInfo(
                              userGroup.Key.Id,
                              userGroup.Key.FirstName,
                              userGroup.Key.LastName,
                              userGroup.Key.Patronymic,
                              userGroup.Key.Email,
                              userGroup.Key.Password,
                              userGroup.Select(s =>
                                  new ReferenceItemReadValue(
                                      Id: s.SettingId,
                                      Code: s.SettingCode,
                                      Description: s.SettingDescription,
                                      Value: s.SettingValue)).ToArray())
            ).FirstOrDefault();
        }
    }
}