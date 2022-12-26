using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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

    public sealed class TodoItemEntityConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Note).HasMaxLength(500);
        }
    }
}
