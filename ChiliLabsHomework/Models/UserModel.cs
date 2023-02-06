using System.ComponentModel.DataAnnotations;

namespace ChiliLabsHomework.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Identifier { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
