using Ajax;
using ChiliLabsHomework.Controllers;
using ChiliLabsHomework.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChiliLabsHomework.Services.Interfaces
{
    public interface IUserService
    {
        JSend Registration([FromBody] RegistrationRequestModel request);
        JSend Login([FromBody] LoginRequestModel request);
    }
}
