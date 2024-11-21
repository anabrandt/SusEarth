using SusEarth.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SusEarth.API.Data.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly OracleDbContext _context;

        public UserRepository(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
