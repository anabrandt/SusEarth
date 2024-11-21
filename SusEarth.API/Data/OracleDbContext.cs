using Microsoft.EntityFrameworkCore;
using SusEarth.API.Models;

namespace SusEarth.API.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
