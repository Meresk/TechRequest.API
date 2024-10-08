﻿using Microsoft.EntityFrameworkCore;
using TechRequest.API.Data;
using TechRequest.API.Dtos.User;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _dbContext;

        public UserRepository(Context context)
        {
            _dbContext = context;
        }

        public async Task<User?> CreateAsync(string login, string password)
        {
            var userExist = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            if (userExist != null)
                return null;

            var user = new User
            {
                Login = login,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                RefreshToken = Guid.NewGuid().ToString()
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var userModel = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (userModel == null)
            {
                return null;
            }

            _dbContext.Users.Remove(userModel);
            await _dbContext.SaveChangesAsync();

            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserDto userDto)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (existingUser == null)
                return null;

            existingUser.Login = userDto.Login;
            existingUser.Password = userDto.Password;

            await _dbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
