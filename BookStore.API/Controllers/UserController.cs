using BookStore.API.Contracts;
using BookStore.CoreDomain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    public IUsersService _usersService { get; }

    public UserController(IUsersService usersService)
    {
        _usersService = usersService;
    }


    [HttpPost]
    public async Task<IResult> Register(RegisterUserRequest request)
    {
        await _usersService.Register(request.UserName, request.Email, request.Password);

        return Results.Ok();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IResult> Login(LoginUserRequest request)
    {
        var token = await _usersService.Login(request.Email, request.Password);

        HttpContext.Response.Cookies.Append("jwttoken", token);

        return Results.Ok(token);
    }
}
