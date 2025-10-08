using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces.IServices;

public interface IUserService
{
    public User Create(User user);
    public User Update(User user);
    public User Delete(int id);
    public User? Get(int id);
}