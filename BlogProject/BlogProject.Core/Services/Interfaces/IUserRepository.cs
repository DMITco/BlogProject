
using BlogProject.Core.Models;
using BlogProject.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Core.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(int PageNumber = 1, int PageSize = 20);
        Task<User> Add(User user);
        Task<User> Find(int id);
        Task<User> FindByUserPass(Login login);
        Task<User> Update(User user);
        Task<User> Remove(int id);
        Task<bool> IsExists(int id);
        Task<bool> IsExistsByUserName(string Username);
        Task<int> CountUser();

        Task<bool> AddRole(int IdUser, int IdRole);
    }
}
