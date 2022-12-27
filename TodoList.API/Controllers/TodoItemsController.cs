using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using TodoList.API.Interfaces;
using TodoList.DataAccess.Models;
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
        private readonly IUserService _userService;

        public TodoItemsController(
            ILogger<TodoItemsController> logger,
            ITodoService todoService,
            IUserService userService
        )
        {
            _logger = logger;
            _todoService = todoService;
            _userService = userService;
        }

        /// <summary>
        /// Get TodoItem by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [ProducesResponseType(typeof(TodoItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTodoItem(Guid id)
        {
            TodoItemViewModel? viewModel = await _todoService.GetTodoItemViewModel(id);

            if (viewModel == null)
            {
                _logger.LogWarning($"ViewTodoItem with id {id} was not found");
                return NotFound();
            }
            
            return Ok(viewModel);
        }

        /// <summary>
        /// Create TodoItem    
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItemViewModel viewModel)
        {
            UserViewModel userViewModel = await _userService.GetDefaultUserViewModel();
            viewModel.Id = Guid.NewGuid();
            viewModel.UserId = userViewModel.Id;

            await _todoService.CreateTodoItemViewModel(viewModel);

            return Ok(viewModel.Id);
        }

        /// <summary>
        /// Update TodoItem    
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTodoItem([FromBody] TodoItemViewModel viewModel)
        {
            TodoItemViewModel todoItem = await _todoService.GetTodoItemViewModel(viewModel.Id);

            if(todoItem == null)
            {
                _logger.LogWarning($"TodoItem with id {viewModel.Id} was not found");
                return NotFound();
            }
            else
            {
                await _todoService.UpdateTodoItemViewModel(viewModel);
            }

            return Ok();
        }

        /// <summary>
        /// Delete TodoItem    
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            TodoItemViewModel todoItem = await _todoService.GetTodoItemViewModel(id);

            if (todoItem == null)
            {
                _logger.LogWarning($"TodoItem with id {id} was not found");
                return NotFound();
            }
            else
            {
                await _todoService.DeleteTodoItemViewModel(id);
            }

            return Ok();
        }
        /// <summary>
        /// Get All TodoItems
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllTodoItems")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<string> GetAllTodoItems()
        {
            IEnumerable<TodoItemViewModel> viewModels = await _todoService.GetAllTodoItemViewModels();

            string models = JsonSerializer.Serialize(viewModels);

            return models;
        }
    }
}
