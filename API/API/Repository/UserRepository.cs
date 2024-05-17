using System.Collections.Concurrent;
using API.Infrastracture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class UsersRepository : IUsersRepository
{
    private static readonly ConcurrentDictionary<Guid, User> Users = new();
    private static readonly ConcurrentDictionary<string, Guid> IdsByEmail = new();

    public async Task Add(User user)
    {
        Users.TryAdd(user.Id, user);
        IdsByEmail.TryAdd(user.Email, user.Id);
    }

    public async Task<User> GetByEmail(string email)
    {
        if (!IdsByEmail.TryGetValue(email, out var userId))
            throw new Exception("Not found");

        if (!Users.TryGetValue(userId, out var user))
            throw new Exception("Not found");

        return user;
    }
}