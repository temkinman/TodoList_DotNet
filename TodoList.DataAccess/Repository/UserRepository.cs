﻿using Microsoft.EntityFrameworkCore;
using TodoList.DataAccess.Data;
using TodoList.DataAccess.Interfaces;
using TodoList.DataAccess.Models;

namespace TodoList.DataAccess.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IQueryable<User> users => _dbContext.Users;

        public async Task Create(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetDefaultUser() => await _dbContext.Users.FirstOrDefaultAsync();
    }
}
