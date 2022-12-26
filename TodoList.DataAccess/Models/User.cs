using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoList.DataAccess.Models
{
    public class User
    {
        public User()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; }

    }
    public sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Login).HasMaxLength(50);
            builder.HasMany(x => x.TodoItems)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
