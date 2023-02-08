using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ChiliLabsHomework.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; } 
        public byte[] PasswordHash { get; set; } 
        public string? AvatarUrl { get; set; } = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png";
    }
}
