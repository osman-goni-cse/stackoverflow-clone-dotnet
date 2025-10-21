using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Exceptions;
using stack_overflow.Core.Interfaces;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.Core.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IAuthRepository authRepository, IConfiguration configuration)
    {
        _authRepository = authRepository;
        _configuration = configuration;
    }
    public User Register(User user)
    {
        
        var isExists = _authRepository.GetByEmail(user.Email);

        if (isExists != null)
        {
            throw new UserAlreadyExistsException(user.Email);
        }
        
        var hashedPassword = new PasswordHasher<User>()
            .HashPassword(user, user.Password);
        
        user.Password = hashedPassword;

        User registeredUser = _authRepository.Register(user);
        return registeredUser;
    }

    public string Login(UserDto requestUser)
    {
        User user = _authRepository.GetByEmail(requestUser.Email);
        if (user == null)
        {
            throw new UserCredentialIncorrectException();
        }

        if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, requestUser.Password) 
            == PasswordVerificationResult.Failed)
        {
            throw new UserCredentialIncorrectException();
        }

        string token = CreateToken(requestUser);
        return token;
    }
    
    private string CreateToken(UserDto user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            // new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
            new Claim(ClaimTypes.Role, "admin")
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
        
        var tokenDescriptor = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
            audience: _configuration.GetValue<string>("AppSettings:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}