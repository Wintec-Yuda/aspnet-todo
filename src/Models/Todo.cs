using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
