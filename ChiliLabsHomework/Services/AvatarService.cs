using Ajax;
using ChiliLabsHomework.Data;
using ChiliLabsHomework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ChiliLabsHomework.Services
{
    public class AvatarService : IAvatarService
    {
        private readonly ApiContext _context;

        public AvatarService(ApiContext context)
        {
            _context = context;
        }

        public JSend UploadAvatar(string nickname, IFormFile avatar)
        {
            var user = _context.DbUsers.FirstOrDefault(u => u.Nickname == nickname);
            if (user == null)
            {
                return JSend.Error("User not found.");
            }

            if (avatar == null || avatar.Length == 0)
            {
                return JSend.Error("No avatar file provided.");
            }

            if (!IsValidImage(avatar))
            {
                return JSend.Error("Invalid image format.");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/avatars", nickname + Path.GetExtension(avatar.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                avatar.CopyTo(stream);
            }

            user.AvatarUrl = "/avatars/" + nickname + Path.GetExtension(avatar.FileName);
            _context.SaveChanges();

            return JSend.Success(new { AvatarUrl = user.AvatarUrl });
        }

        private bool IsValidImage(IFormFile avatar)
        {
            try
            {
                using (var image = System.Drawing.Image.FromStream(avatar.OpenReadStream()))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
