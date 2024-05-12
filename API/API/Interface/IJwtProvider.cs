namespace API.Infrastracture;

public interface IJwtProvider
{
    string GenerateToken(User user);
}