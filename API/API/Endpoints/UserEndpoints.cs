using API.Register;
using API.Request;

namespace API.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndopints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);

        app.MapPost("login", Login);

        return app;
    }

    private static async Task<IResult> Register(
        RegisterRequest request,
        UserService userService)
    {
        await userService.Register(request.UserName, request.Email, request.Password);  
        
        return Results.Ok();
    }

    private static async Task<IResult> Login(
        LoginRequest request,
        UserService userService)
    {
        var token = await userService.Login(request.Email, request.Password);
        
        return Results.Ok(token);
    }
    
}