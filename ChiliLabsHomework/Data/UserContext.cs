using ChiliLabsHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace ChiliLabsHomework.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
        : base(options) { }
        public DbSet<UserModel> DbUsers { get; set; }
    }
}
