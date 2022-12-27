using Microsoft.AspNetCore.Mvc;
using System;
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
        /// <param name="logger"></param>
        /// <param name="todoService"></param>
        /// <param name="userService"></param>
        [HttpGet]
        [ProducesResponseType(typeof(TodoItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTodoItem(Guid id)
        {
            var result = await _todoService.Get(id);
            return Ok(result);
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
            UserViewModel userViewModel = await _userService.GetDefault();
            viewModel.Id = Guid.NewGuid();
            viewModel.UserId = userViewModel.Id;

            await _todoService.Create(viewModel);

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
            TodoItemViewModel todoItem = await _todoService.Get(viewModel.Id);

            if(todoItem == null)
            {
                _logger.LogWarning($"TodoItem with id {viewModel.Id} was not found");
                return NotFound();
            }
            else
            {
                await _todoService.Update(viewModel);
            }

            return Ok();
        }

        /// <summary>
        /// Delete TodoItem    
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpDelete("{id: Guid}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            TodoItemViewModel todoItem = await _todoService.Get(id);

            if (todoItem == null)
            {
                _logger.LogWarning($"TodoItem with id {id} was not found");
                return NotFound();
            }
            else
            {
                await _todoService.Delete(id);
            }

            return Ok();
        }
    }
}
