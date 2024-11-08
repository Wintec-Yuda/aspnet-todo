using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.DTO;
using TodoListApi.Models;
using TodoListApi.Services;

namespace TodoListApi.Controllers;
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAllTodos()
        {
            var todos = await _todoService.GetAllTodosAsync();

            return Ok(new
            {
                status = "success",
                message = "Todos retrieved successfully",
                data = todos
            });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TodoResponseDTO>> GetTodoById(Guid id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound(new
                {
                    status = "error",
                    message = "Todo not found"
                });
            }
            return Ok(new
            {
                status = "success",
                message = "Todo retrieved successfully",
                data = todo
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateTodo([FromBody] TodoRequestDTO todoDto)
        {
            var todo = await _todoService.CreateTodoAsync(todoDto);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo!.Id }, new
            {
                status = "success",
                message = "Todo created successfully",
                data = todo
            });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] TodoRequestDTO todoDto)
        {
            try
            {
                await _todoService.UpdateTodoAsync(id, todoDto);
                return Ok(new
                {
                    status = "success",
                    message = "Todo updated successfully"
                });
            }
            catch (Exception e)
            {
                return NotFound(new
                {
                    status = "error",
                    message = e.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            await _todoService.DeleteTodoAsync(id);
            return Ok(new
            {
                status = "success",
                message = "Todo deleted successfully"
            });
        }
}
