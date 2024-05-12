namespace API.Infrastracture;

public interface IUsersRepository
{
    Task Add(User user);
    Task<User> GetByEmail(string email);
}