using TodoList.ViewModels.Models;

namespace TodoList.API.Interfaces
{
    public interface ITodoService
    {
        Task<TodoItemViewModel> GetTodoItemViewModel(Guid id);
        Task CreateTodoItemViewModel(TodoItemViewModel item);
        Task DeleteTodoItemViewModel(Guid id);
        Task UpdateTodoItemViewModel(TodoItemViewModel item);
        Task<IEnumerable<TodoItemViewModel>> GetAllTodoItemViewModels();
    }
}
