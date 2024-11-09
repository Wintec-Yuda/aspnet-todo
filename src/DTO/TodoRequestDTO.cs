using System.ComponentModel.DataAnnotations;

namespace TodoListApi.DTO
{
    public class TodoRequestDTO
    {   
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public bool IsCompleted { get; set; } = false;

        [Required]
        public Guid UserId { get; set; }
    }
}
