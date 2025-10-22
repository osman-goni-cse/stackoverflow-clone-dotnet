using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    
    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Post>> GetAllPosts()
    {
        return Ok(_postService.GetAllPosts());
    }

    [HttpGet("{id}")]
    public ActionResult<Post> Get(int id)
    {
        return Ok(_postService.Get(id));
    }
    
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Post> Create(CreatePostRequestDto PostRequestDto)
    {
        try
        {
            Post createdPost = _postService.Create(PostRequestDto);
            return StatusCode(StatusCodes.Status201Created, createdPost);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}