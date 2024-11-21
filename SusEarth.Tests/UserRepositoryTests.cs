using Moq;
using SusEarth.API.Models;
using SusEarth.API.Data;
using SusEarth.API.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace SusEarth.Tests
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository;
        private readonly OracleDbContext _context;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<OracleDbContext>()
                .UseInMemoryDatabase(databaseName: "SusEarthDb") 
                .Options;

            _context = new OracleDbContext(options);
            _userRepository = new UserRepository(_context);
        }

        [Fact]
        public async Task CreateUserAsync_ShouldAddUser()
        {
            var user = new User { Id = 1, Name = "John", Address = "123 Street" };

            var result = await _userRepository.CreateUserAsync(user);

            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
        }
    }
}
