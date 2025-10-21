using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces;

public interface IAuthRepository
{
    public User Register(User user);
    public User? GetByEmail(string email);
}