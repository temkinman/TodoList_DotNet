using Microsoft.EntityFrameworkCore;
using TodoList.DataAccess.Data;
using TodoList.DataAccess.Interfaces;
using TodoList.DataAccess.Models;

namespace TodoList.DataAccess.Repository
{
    public class TodoItemRepository : ITodoItem
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoItemRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IQueryable<TodoItem> todoItems => _dbContext.TodoItems
                                                            .Include(t => t.User);

        public async Task Create(TodoItem item)
        {
            _dbContext.TodoItems.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            TodoItem todoItem = await Get(id);

            if (todoItem != null)
            {
                _dbContext.TodoItems.Remove(todoItem);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<TodoItem> Get(Guid id)
        {
            return await _dbContext.TodoItems
                .AsNoTracking()
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<IEnumerable<TodoItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(TodoItem item)
        {
            _dbContext.TodoItems.Update(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
