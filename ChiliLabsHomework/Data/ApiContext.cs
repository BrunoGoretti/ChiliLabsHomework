using ChiliLabsHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace ChiliLabsHomework.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
        : base(options) { }
        public DbSet<UserModel> DbUsers { get; set; }
    }
}
