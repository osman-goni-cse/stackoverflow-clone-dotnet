using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces.IServices;

public interface IAuthService
{
    public User Register(User user);
    public string Login(UserDto user);
}