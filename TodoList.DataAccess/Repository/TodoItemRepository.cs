using TodoList.DataAccess.Interfaces;
using TodoList.DataAccess.Models;

namespace TodoList.DataAccess.Repository
{
    public class TodoItemRepository : ITodoItem
    {
        public Task Create(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TodoItem> Get(Guid id)
        {
            return await Task.FromResult(new TodoItem()
            {
                Id = id,
                Note = "test",
                User = new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "test user"
                }
            });
        }

        public Task<IEnumerable<TodoItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
