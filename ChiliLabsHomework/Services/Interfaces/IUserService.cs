using Ajax;
using ChiliLabsHomework.Controllers;

namespace ChiliLabsHomework.Services.Interfaces
{
    public interface IUserService
    {
        JSend Registration(string nickname, string password);
        JSend Login(string nickname, string password);
    }
}
