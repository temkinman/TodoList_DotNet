using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using TodoList.API.Interfaces;
using TodoList.ViewModels.Models;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class TodoItemsController : ControllerBase
    {
        private readonly ILogger<TodoItemsController> _logger;
        private readonly ITodoService _todoService;

        public TodoItemsController(ILogger<TodoItemsController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TodoItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTodoItem(Guid id)
        {
            var result = await _todoService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItemViewModel viewModel)
        {
            return Ok();
        }
    }
}
