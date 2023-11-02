using Microsoft.AspNetCore.Mvc;
using OpenScienceProjects.API.Domain.Models.Users;
using OpenScienceProjects.API.Domain.Reponses.Users;
using OpenScienceProjects.API.Services;

namespace OpenScienceProjects.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(
        IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public Task CreateUser(UserCreateModel userCreateModel)
    {
        return _userService.CreateUser(userCreateModel);
    }
    
    [HttpPost]
    public Task LoginUser(UserLoginModel loginModel)
    {
        return _userService.LoginUser(loginModel);
    }

    [HttpGet("{token}")]
    public int? ValidateTokenUser(string token)
    {
        return _userService.ValidateUserToken(token);
    }
    
    [HttpGet("{id}")]
    public Task<UserListByIdResponse> GetUserListById(int id)
    {
        return _userService.GetUserListById(id);
    }

    [HttpGet("name/{name}")]
    public Task<UserListByNameResponse> GetUserListByName(string name)
    {
        return _userService.GetUserListByName(name);
    }

    [HttpGet("email/{email}")]
    public Task<UserListByEmailResponse> GetUserListByEmail(string email)
    {
        return _userService.GetUserListByEmail(email);
    }

    [HttpGet("{id}/tags")]
    public Task<UserListTagsByIdResponse> GetUserListTagsByUserId(int id)
    {
        return _userService.GetUserListTagsByUserId(id);
    }
}