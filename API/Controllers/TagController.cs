using Microsoft.AspNetCore.Mvc;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;

namespace stack_overflow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private readonly ITagRepository _tagRepository;
    
    public TagController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    
    [HttpGet]
    public ActionResult<String> Get()
    {
        return "tag";
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]
    public Tag Create(Tag tag)
    {
        return _tagRepository.Create(tag);
    }
    
}