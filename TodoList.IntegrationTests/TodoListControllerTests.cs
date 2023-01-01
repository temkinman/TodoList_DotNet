using System.Net.Http.Json;
using AutomaticBroccoli.IntegrationTests;
using Microsoft.AspNetCore.Http;
using TodoList.API.Interfaces;
using TodoList.DataAccess.Interfaces;
using TodoList.ViewModels.Models;

namespace TodoList.IntegrationTests
{
    public class TodoListControllerTests : IntegrationTestBase
    {
        private readonly ITodoService _todoService;

        public TodoListControllerTests(ITodoService todoService)
        {
            _todoService = todoService;


        }

        [Fact] public async Task Get_InvalidTodoItem_ShouldReturn404Status()
        {
            Guid todoId = new Guid("24a9b4ad-1a9d-47b5-a93d-dc20348cf38e");
            var result = await GetTodoItemViewModel(todoId);
            
            Assert.NotNull(result);
        }
        
        private async Task<TodoItemViewModel?> GetTodoItemViewModel(Guid todoItemId)
        {
            var response = await Client.GetAsync($"/TodoItems?id={todoItemId}");
            Assert.NotNull(response?.Content);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
           
            var result = await response!.Content!.ReadFromJsonAsync<TodoItemViewModel>();
            return result;
        }

        private void SeedData()
        {
            //ITodoItem todoItem = new ITodoItem ();
        }
    }
}