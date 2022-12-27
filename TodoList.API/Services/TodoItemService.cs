using TodoList.API.Extensions;
using TodoList.API.Interfaces;
using TodoList.DataAccess.Interfaces;
using TodoList.DataAccess.Models;
using TodoList.ViewModels.Models;

namespace TodoList.API.Services
{
    public class TodoItemService : ITodoService
    {
        private readonly ITodoItem _todoItemRepository;
        private readonly IUser _userRepository;

        public TodoItemService(ITodoItem todoItemRepository, IUser userRepository)
        {
            _todoItemRepository = todoItemRepository;
            _userRepository = userRepository;
        }

        public async Task CreateTodoItemViewModel(TodoItemViewModel item)
        {
            User userViewModel = await _userRepository.GetDefaultUser();
            TodoItem todoItem = new();

            if (userViewModel != null)
            {
                todoItem = item.MapToTodoItem();
            }
            
            await _todoItemRepository.CreateTodoItem(todoItem);
        }

        public async Task DeleteTodoItemViewModel(Guid id)
        {
            await _todoItemRepository.DeleteTodoItem(id);
        }

        public async Task<TodoItemViewModel?> GetTodoItemViewModel(Guid id)
        {
            TodoItem? todoItem = await _todoItemRepository.GetTodoItem(id);

            TodoItemViewModel? todoItemViewModel = todoItem?.MapToTodoItemViewModel();

            return todoItemViewModel;
        }

        public async Task<IEnumerable<TodoItemViewModel>> GetAllTodoItemViewModels()
        {
            IEnumerable<TodoItem> todoItems = await _todoItemRepository.GetAllTodoItems();
            IEnumerable<TodoItemViewModel> todoItemViewModels = todoItems.MapToListViewModels();

            return todoItemViewModels;
        }

        public async Task UpdateTodoItemViewModel(TodoItemViewModel item)
        {
            TodoItem updatedTodoItem = item.MapToTodoItem();
            await _todoItemRepository.UpdateTodoItem(updatedTodoItem);
        }
    }
}
