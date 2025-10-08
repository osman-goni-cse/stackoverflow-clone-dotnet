using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public User Create(User user)
    {
        User userExists = _userRepository.GetByEmail(user.Email);
        if (userExists != null)
        {
            throw new InvalidOperationException($"User with email {user.Email} already exists");
        }
        
        User newUser = _userRepository.Create(user);
        return newUser;
    }

    public User Update(User user)
    {
        throw new NotImplementedException();
    }

    public User Delete(int id)
    {
        throw new NotImplementedException();
    }

    public User? Get(int id)
    {
        throw new NotImplementedException();
    }
}