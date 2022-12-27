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

        public async Task Create(TodoItemViewModel item)
        {
            User userViewModel = await _userRepository.GetDefaultUser();
            TodoItem todoItem = new();

            if (userViewModel != null)
            {
                todoItem = item.MapToTodoItem();
            }
            
            await _todoItemRepository.Create(todoItem);
        }

        public async Task Delete(Guid id)
        {
            await _todoItemRepository.Delete(id);
        }

        public async Task<TodoItemViewModel> Get(Guid id)
        {
            TodoItem todoItem = await _todoItemRepository.Get(id);
            TodoItemViewModel todoItemViewModel = todoItem.MapToTodoItemViewModel();

            return todoItemViewModel;
        }

        public Task<IEnumerable<TodoItemViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(TodoItemViewModel item)
        {
            TodoItem updatedTodoItem = item.MapToTodoItem();
            await _todoItemRepository.Update(updatedTodoItem);
        }
    }
}
