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
    public List<Tag> GetAllTags()
    {
        return _tagRepository.GetAllTags();
    }

    [HttpGet("{id}")]
    public ActionResult<Tag> GetTagById(int id)
    {
        Tag? tag = _tagRepository.GetTagById(id);
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
        return _tagRepository.Create(tag);
    }
    
    [HttpPut("{id}")]
    public ActionResult<Tag> Update(int id, Tag tag)
    {

        if (id != tag.ID)
        {
            return BadRequest();
        }
        
        return _tagRepository.Update(tag);
    }

    [HttpDelete("{id}")]
    public ActionResult<Tag> Delete(int id)
    {
        return _tagRepository.Delete(id);
    }
    
}