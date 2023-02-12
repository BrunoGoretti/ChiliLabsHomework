using System.ComponentModel.DataAnnotations;

namespace ChiliLabsHomework.Models
{
    public class AvatarModel
    {
        [Key]
        public int AvatarId { get; set; }
        public string AvatarUrl { get; set; }
    }
}
