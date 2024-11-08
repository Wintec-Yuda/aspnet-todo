namespace TodoListApi.DTO
{
    public class TodoUpdateDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
