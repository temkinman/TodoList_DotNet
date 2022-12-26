namespace TodoList.DataAccess.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
