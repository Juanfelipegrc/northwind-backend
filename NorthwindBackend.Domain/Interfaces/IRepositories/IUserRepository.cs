using NorthwindBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Domain.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(User user);
    }
}
