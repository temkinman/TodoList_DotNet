using TodoList.DataAccess.Models;

namespace TodoList.DataAccess.Interfaces
{
    public interface ITodoItem
    {
        Task<TodoItem> Get(Guid id);
        Task Create(TodoItem item);
        Task Delete(Guid id);
        Task Update(TodoItem item);
        Task<IEnumerable<TodoItem>> GetAll();
    }
}
