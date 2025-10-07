using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.Core.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;
    
    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    
    public Tag Create(Tag tag)
    {
        return _tagRepository.Create(tag);
    }

    public List<Tag> GetAllTags()
    {
        return _tagRepository.GetAllTags();
    }

    public Tag? GetTagById(int id)
    {
        return _tagRepository.GetTagById(id);
    }

    public Tag Update(Tag tag)
    {
        return _tagRepository.Update(tag);
    }

    public Tag Delete(int id)
    {
        return _tagRepository.Delete(id);
    }
}