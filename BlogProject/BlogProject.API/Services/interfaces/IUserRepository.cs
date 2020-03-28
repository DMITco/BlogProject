using BlogProject.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.API.Services.interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        Task<User> Add(User user);
        Task<User> Find(int id);
        Task<User> Update(User user);
        Task<User> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> CountUser();
    }
}
