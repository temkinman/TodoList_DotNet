using TodoList.DataAccess.Models;
using TodoList.ViewModels.Models;

namespace TodoList.API.Extensions
{
    public static class MappingExtensions
    {
        public static TodoItemViewModel MapToTodoItemDto(this TodoItem todoItem)
        {
            return new TodoItemViewModel()
            {
                Id = todoItem.Id,
                Note = todoItem.Note,
                CreatedDate = todoItem.CreatedDate,
                UserLogin = todoItem.User.Login
            };
        }
    }
}
