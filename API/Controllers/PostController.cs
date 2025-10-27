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

    // [HttpGet("{id}")]
    // public ActionResult<Post> Get(int id)
    // {
    //     return Ok(_postService.Get(id));
    // }
    
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm] CreatePostRequestDto PostRequestDto)
    {
        try
        {
            Post createdPost = await _postService.Create(PostRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPost.Id }, createdPost);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _postService.GetAsync(id);
        if (post == null) return NotFound();

        return Ok(post);
    }
}