using BlogProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Core.Services.Interfaces
{
    public interface IAuthRepository
    {
        Task<Auth> Authenticate(Login login);
    }
}
