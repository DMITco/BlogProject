using BlogProject.Core.Models;
using BlogProject.Core.Services.Interfaces;
using BlogProject.DataLayer.Context;
using BlogProject.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Core.Services
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

        public async Task<bool> AddRole(int IdUser, int IdRole)
        {
            var UR = new UserToRole()
            {
                IsActive = true,
                RoleId = IdRole,
                UserId = IdUser
            };
            await _context.UserRoles.AddAsync(UR);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> CountUser()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<User> Find(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserId == id);
        }

        public Task<User> FindByUserPass(Login login)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.UserName == login.UserName && u.Password == login.Password);
        }

        public async Task<IEnumerable<User>> GetUsers(int PageNumber = 1, int PageSize = 20)
        {
            int skip = (PageNumber - 1) * PageSize;
            return await _context.Users.OrderBy(u => u.Family).Skip(skip).Take(PageSize).ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Users.AnyAsync(u => u.UserId == id);
        }

        public async Task<bool> IsExistsByUserName(string Username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == Username);
        }

        public async Task<User> Remove(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
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
