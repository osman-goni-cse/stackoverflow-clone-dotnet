using Microsoft.AspNetCore.Mvc;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    // private readonly ITagRepository _tagRepository;
    private readonly ITagService _tagService;
    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }
    
    [HttpGet]
    public List<Tag> GetAllTags()
    {
        return _tagService.GetAllTags();
    }

    [HttpGet("{id}")]
    public ActionResult<Tag> GetTagById(int id)
    {
        Tag? tag = _tagService.GetTagById(id);
        if (tag == null)
        {
            return NotFound();
        }

        return Ok(tag);
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]
    public Tag Create(Tag tag)
    {
        return _tagService.Create(tag);
    }
    
    [HttpPut("{id}")]
    public ActionResult<Tag> Update(int id, Tag tag)
    {

        if (id != tag.ID)
        {
            return BadRequest();
        }
        
        return _tagService.Update(tag);
    }

    [HttpDelete("{id}")]
    public ActionResult<Tag> Delete(int id)
    {
        return _tagService.Delete(id);
    }
    
}