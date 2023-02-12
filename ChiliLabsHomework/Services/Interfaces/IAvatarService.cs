using Ajax;

namespace ChiliLabsHomework.Services.Interfaces
{
    public interface IAvatarService
    {
        JSend UploadAvatar(int userId, IFormFile avatar);
    }
}
