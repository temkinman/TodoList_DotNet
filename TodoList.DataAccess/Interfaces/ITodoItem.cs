using TodoList.DataAccess.Models;

namespace TodoList.DataAccess.Interfaces
{
    public interface ITodoItem
    {
        Task<TodoItem> GetTodoItem(Guid id);
        Task CreateTodoItem(TodoItem item);
        Task DeleteTodoItem(Guid id);
        Task UpdateTodoItem(TodoItem item);
        Task<IEnumerable<TodoItem>> GetAllTodoItems();
    }
}
