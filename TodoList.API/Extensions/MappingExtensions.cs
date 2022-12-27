using TodoList.DataAccess.Models;
using TodoList.ViewModels.Models;

namespace TodoList.API.Extensions
{
    public static class MappingExtensions
    {
        public static TodoItemViewModel MapToTodoItemViewModel(this TodoItem todoItem)
        {
            return new TodoItemViewModel()
            {
                Id = todoItem.Id,
                Note = todoItem.Note,
                CreatedDate = todoItem.CreatedDate,
                UserLogin = todoItem.User.Login,
                UserId = todoItem.UserId
            };
        }

        public static TodoItem MapToTodoItem(this TodoItemViewModel todoItemViewModel)
        {
            return new TodoItem() 
            {
                Id = todoItemViewModel.Id,
                Note = todoItemViewModel.Note,
                CreatedDate = todoItemViewModel.CreatedDate,
                UserId = todoItemViewModel.UserId
            };
        }

        public static UserViewModel MapToUser(this User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                CreatedDate = user.CreatedDate,
                Login = user.Login
            };
        }
    }
}
