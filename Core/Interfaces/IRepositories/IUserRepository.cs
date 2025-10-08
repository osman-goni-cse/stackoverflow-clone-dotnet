using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces;

public interface IUserRepository
{
    public User Create(User user);
    public User Update(User user);
    public User Delete(User user);
    public User Get(int id);
    
    public User GetByEmail(string email);
}