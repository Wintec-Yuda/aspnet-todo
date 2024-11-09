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
        var todos = await _todoService.GetAllTodos();

        return Ok(new
        {
            status = "success",
            message = "Todos retrieved successfully",
            data = todos
        });
    }

    [HttpGet("user/{id}")]
    [Authorize]
    public async Task<ActionResult<TodoResponseDTO>> GetTodoById(Guid id)
    {
        var todo = await _todoService.GetTodoById(id);
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
        var todo = await _todoService.CreateTodo(todoDto);
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
            await _todoService.UpdateTodo(id, todoDto);
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
        await _todoService.DeleteTodo(id);
        return Ok(new
        {
            status = "success",
            message = "Todo deleted successfully"
        });
    }

    [HttpGet("{userId}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<TodoResponseDTO>>> GetTodosByUserId(Guid userId)
    {
        try
        {
            var todos = await _todoService.GetTodosByUserId(userId);
            return Ok(new
            {
                status = "success",
                message = "Todos retrieved successfully",
                data = todos
            });
        }
        catch (Exception e)
        {
            return NotFound(new
            {
                status = "error",
                message = e.Message
            });
            throw;
        }
    }
}
