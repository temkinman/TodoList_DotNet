using TodoList.DataAccess.Models;

namespace TodoList.DataAccess.Interfaces
{
    public interface IUser
    {
        Task<User> GetUser(Guid id);
        Task CreateUser(User user);
        Task DeleteUser(Guid id);
        Task UpdateUser(User user);
        Task<User> GetDefaultUser();
    }
}
