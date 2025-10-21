using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Infrastructure.Data;

namespace stack_overflow.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly ApplicationDbContext  _context;
    public AuthRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public User Register(User user)
    {
        User createdUser =  _context.Users.Add(user).Entity;
        _context.SaveChanges();
        return createdUser;
    }

    public User? GetByEmail(string email)
    {
        return _context.Users.SingleOrDefault(u => u.Email == email);
    }
}