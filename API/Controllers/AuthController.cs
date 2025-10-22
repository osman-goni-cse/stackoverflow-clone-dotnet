using Microsoft.AspNetCore.Mvc;
using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Exceptions;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public ActionResult<User> Register(User requestUser)
    {
        try
        {
            var user = _authService.Register(requestUser);
            return user;
        }
        catch (UserAlreadyExistsException e)
        {
            return BadRequest(new { error = e.Message });
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> Login([FromBody] UserDto requestUser)
    {
        try
        {
            var userToken =  _authService.Login(requestUser);
            Response.Cookies.Append("jwt", userToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.Now.AddHours(1)
            });
            
            return Ok(new { message = "Successfully logged in" });
        }
        catch (UserCredentialIncorrectException e)
        {
            return Unauthorized(new { message = e.Message });
        }
    }

    [HttpGet("me")]
    public IActionResult GetMe()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            var userInfo = new
            {
                Username = User.Identity.Name,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            };
            
            return Ok(new {isLoggedIn = true, userInfo=userInfo});
        }
        return Ok(new {isLoggedIn = false});
    }

    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Logout()
    {
        if (Request.Cookies.ContainsKey("jwt"))
        {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax
            });
        }
        return Ok(new {message = "Successfully logged out" });
    }
}