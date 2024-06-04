using API.Infrastracture;
using API.Repository;
using HostingEnvironmentExtensions = Microsoft.Extensions.Hosting.HostingEnvironmentExtensions;

namespace API.Register;
// отправка данных в базу

public class UserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IJwtProvider _jwtProvider;

    public UserService(
        IUsersRepository usersRepository,
        IJwtProvider jwtProvider)
    {
        _usersRepository = usersRepository;
        _jwtProvider = jwtProvider;
    }
    
    public async Task Register(string userName, string email, string password)
    {
        var user = new User(Guid.NewGuid(), userName, password, email);

        await _usersRepository.Add(user);
    }

    public async Task<LoginResponse> Login(string email, string password)
    {
        var user = await _usersRepository.GetByEmail(email);

        var result = password == user.PasswordHash;

        if (result == false)
        {
            throw new Exception("Ошибка входа");
        }

        var token = _jwtProvider.GenerateToken(user);

        LoginResponse loginResponse = new(){UserName = user.UserName, Token = token};
        return loginResponse;
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public string UserName { get; set;}
    }
}

