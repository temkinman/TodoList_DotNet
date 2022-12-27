namespace TodoList.ViewModels.Models
{
    public sealed class UserViewModel
    {
        public UserViewModel()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public ICollection<TodoItemViewModel> TodoItems { get; set; }
    }
}
