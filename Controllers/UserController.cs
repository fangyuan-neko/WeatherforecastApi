using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace Controller;

[ApiController]
[Route("api/[action]")]
public class UserController(UserService userService) : ControllerBase
{
    private readonly UserService UserService = userService;
    [HttpPost]
    public bool Register(UserModel user)
    {
        user.Token = UserService.GenerateJWT(user.Username);
        bool status = UserService.AddUser(user);
        return status;
    }
    [HttpGet]
    public string GetToken(string Username, string Password)
    {
        return UserService.GetTokenByUsernameAndPassword(Username, Password);
    }
}

[ApiController]
[Route("backend/[action]")]
public class AdminController(UserService userService) : ControllerBase
{
    private readonly UserService UserService = userService;
    [HttpGet]
    public List<UserModel> GetUsers()
    {
        return UserService.GetAllUser();
    }
    [HttpGet]
    public UserModel GetUser(string Email)
    {
        return UserService.GetUser(Email);
    }
}