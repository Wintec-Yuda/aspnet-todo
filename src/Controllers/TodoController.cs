using Microsoft.AspNetCore.Mvc;
using TodoListApi.DTO;
using TodoListApi.Models;
using TodoListApi.Services;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAllTodos()
        {
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        // GET: api/Todo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoResponseDTO>> GetTodoById(Guid id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] TodoCreateDTO todoDto)
        {
            var todo = await _todoService.CreateTodoAsync(todoDto);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo!.Id }, todo);
        }

        // PUT: api/Todo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] TodoUpdateDTO todoDto)
        {
            await _todoService.UpdateTodoAsync(id, todoDto);
            return NoContent();
        }

        // DELETE: api/Todo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }
    }
}
