using Ajax;

namespace ChiliLabsHomework.Services.Interfaces
{
    public interface IAvatarService
    {
        JSend UploadAvatar(string nickname, IFormFile avatar);
    }
}
