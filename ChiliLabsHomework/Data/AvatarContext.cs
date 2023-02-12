using ChiliLabsHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace ChiliLabsHomework.Data
{
    public class AvatarContext : DbContext
    {
        public AvatarContext(DbContextOptions<AvatarContext> avatarOptions)
        : base(avatarOptions) { }
        public DbSet<AvatarModel> Avatars { get; set; }
    }
}
