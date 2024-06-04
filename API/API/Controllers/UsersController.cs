using API.Register;
using API.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")] 
public class UsersController  : ControllerBase
{
    private readonly UserService userService;

    public UsersController(UserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register(RegisterRequest request)
    {
        await userService.Register(request.UserName, request.Email, request.Password);
        var loginRequest = new LoginRequest(request.Email, request.Password);
        
        return await Login(loginRequest);
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginRequest request)
    {
        var loginResponse = await userService.Login(request.Email, request.Password);
        
        return Ok(loginResponse);
    }
}