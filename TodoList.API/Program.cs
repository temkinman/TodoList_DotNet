using Microsoft.EntityFrameworkCore;
using TodoList.API.Interfaces;
using TodoList.API.Services;
using TodoList.DataAccess.Data;
using TodoList.DataAccess.Interfaces;
using TodoList.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITodoService, TodoItemService>();
builder.Services.AddScoped<ITodoItem, TodoItemRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options
        // .UseLazyLoadingProxies()
#if DEBUG
        .EnableSensitiveDataLogging()
#endif
        .UseNpgsql(builder.Configuration.GetConnectionString(nameof(ApplicationDbContext)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
