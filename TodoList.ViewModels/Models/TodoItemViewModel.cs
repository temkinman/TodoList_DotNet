using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoList.ViewModels.Models
{
    public sealed class TodoItemViewModel
    {
        public TodoItemViewModel()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        
        [Required]
        public string Note { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public string UserLogin { get; set; }
        public Guid UserId { get; set; }
    }
}
