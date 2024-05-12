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

    public async Task<string> Login(string email, string password) //здесь регистрация 10:00
    {
        var user = await _usersRepository.GetByEmail(email);

        var result = password == user.PasswordHash;

        if (result == false)
        {
            throw new Exception("Ошибка входа");
        }

        var token = _jwtProvider.GenerateToken(user);
        
        return token;
    }
}

