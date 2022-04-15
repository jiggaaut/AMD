﻿namespace DB.Repositories.User;
using Entities;

public class EfUserRepository : IUserRepository
{
    private readonly EfDatabaseContext _context;

    public EfUserRepository(EfDatabaseContext context)
    {
        _context = context;
    }

    public User? GetItem(ulong id)
    {
        var user = _context.Users.Find(id);
        return user;
    }
}