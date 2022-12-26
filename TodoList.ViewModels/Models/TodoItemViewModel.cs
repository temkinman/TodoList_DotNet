namespace TodoList.ViewModels.Models
{
    public sealed class TodoItemViewModel
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string UserLogin { get; set; }
    }
}
