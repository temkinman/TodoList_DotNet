using TodoList.DataAccess.Models;

namespace TodoList.DataAccess.Interfaces
{
    public interface IUser
    {
        Task<User> Get(Guid id);
        Task Create(User user);
        Task Delete(Guid id);
        Task Update(User user);
        Task<User> GetDefaultUser();
    }
}
