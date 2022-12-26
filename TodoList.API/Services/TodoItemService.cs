using TodoList.API.Extensions;
using TodoList.API.Interfaces;
using TodoList.DataAccess.Interfaces;
using TodoList.ViewModels.Models;

namespace TodoList.API.Services
{
    public class TodoItemService : ITodoService
    {
        private readonly ITodoItem _todoItemRepository;

        public TodoItemService(ITodoItem todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public Task Create(TodoItemViewModel item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TodoItemViewModel> Get(Guid id)
        {
            var todoItem = await _todoItemRepository.Get(id);
            var todoItemViewModel = todoItem.MapToTodoItemDto();

            return todoItemViewModel;

        }

        public Task<IEnumerable<TodoItemViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(TodoItemViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
