using BlogProject.API.Services.interfaces;
using BlogProject.DataLayer.Context;
using BlogProject.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.API.Services
{
    public class UserRepository : IUserRepository
    {

        private BlogProjectContext _context;

        public UserRepository(BlogProjectContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<int> CountUser()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<User> Find(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserId == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Users.AnyAsync(u => u.UserId == id);
        }

        public async Task<User> Remove(int id)
        {
            var user = await _context.Users.SingleAsync(u => u.UserId == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;

        }
    }
}
