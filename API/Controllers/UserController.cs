using Microsoft.AspNetCore.Mvc;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<User> Create(User user)
    {
        try
        {
            User newUser = _userService.Create(user);
            return StatusCode(201, newUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }        
    }
}