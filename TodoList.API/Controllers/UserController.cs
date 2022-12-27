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
    public class UserController : ControllerBase
    {
        private readonly ILogger<TodoItemsController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<TodoItemsController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public IActionResult CreateUser([FromBody] UserViewModel viewModel)
        {
            viewModel.Id = Guid.NewGuid();
            _userService.CreateUserViewModel(viewModel);

            return Ok(viewModel.Id);
        }
    }
}
