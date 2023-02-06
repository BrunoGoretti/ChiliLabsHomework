using ChiliLabsHomework.Controllers;

namespace ChiliLabsHomework.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Registration(string identifier, string password);
    }
}
