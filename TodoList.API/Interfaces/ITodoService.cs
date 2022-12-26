using TodoList.ViewModels.Models;

namespace TodoList.API.Interfaces
{
    public interface ITodoService
    {
        Task<TodoItemViewModel> Get(Guid id);
        Task Create(TodoItemViewModel item);
        Task Delete(Guid id);
        Task Update(TodoItemViewModel item);
        Task<IEnumerable<TodoItemViewModel>> GetAll();
    }
}
