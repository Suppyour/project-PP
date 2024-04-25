using API.Infrastracture;
using Microsoft.AspNetCore.Identity;

namespace API;

public class PasswordHasher : IPasswordHasher // 6:07 // проверить правильно сделал или нет
{
    public string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}