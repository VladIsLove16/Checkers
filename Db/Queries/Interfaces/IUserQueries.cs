using Db.DTOs;

namespace Db.Queries
{
    public interface IUserQueries
    {
        Task AddUserAsync(UserCreate user);
        Task UpdateUserAsync(UserUpdate user);
        Task DeleteUserAsync(string email);
        Task<UserInfo?> GetUserAsync(string email);
    }
}