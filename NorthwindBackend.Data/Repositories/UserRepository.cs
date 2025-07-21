using AutoMapper;
using NorthwindBackend.Data.Context;
using NorthwindBackend.Data.Entities;
using NorthwindBackend.Domain.Entities;
using NorthwindBackend.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            var userMapped = _mapper.Map<User>(user);

            return userMapped;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var userMapped = _mapper.Map<UserDataModel>(user);

            _context.Users.Add(userMapped);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

    }
}
