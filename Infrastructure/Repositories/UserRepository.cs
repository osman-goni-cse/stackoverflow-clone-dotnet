using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Infrastructure.Data;

namespace stack_overflow.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public User Create(User user)
    {
        User createdUser =  _context.Users.Add(user).Entity;
        _context.SaveChanges();
        return createdUser;
    }

    public User Update(User user)
    {
        throw new NotImplementedException();
    }

    public User Delete(User user)
    {
        throw new NotImplementedException();
    }

    public User Get(int id)
    {
        return _context.Users.Find(id);
    }

    public User GetByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }
}