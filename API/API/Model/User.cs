using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace API;

public class User
{
    private User(Guid id, string userName, string passwordHash, string email)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
    }

    public Guid Id { get; set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email{ get; private set; }

    public static User Create(Guid id, string userName, string passwordHash, string email)
    {
        return new User(id, userName, passwordHash, email); 
    }
}
/*
public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }
    // like dislike не важно
    // avatarky не важно
    // регистрация 
*/