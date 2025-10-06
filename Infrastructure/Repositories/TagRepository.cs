using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Infrastructure.Data;

namespace stack_overflow.Infrastructure.Repositories;

public class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _context;
    
    public TagRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Tag Create(Tag tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return tag;
    }

    public List<Tag> GetAllTags()
    {
        return _context.Tags.ToList();
    }

    public Tag? GetTagById(int id)
    {
        return _context.Tags.Find(id);
    }

    public Tag Update(Tag tag)
    {
        _context.Tags.Update(tag);
        _context.SaveChanges();
        return tag;
    }

    public Tag Delete(int id)
    {
        Tag tagToDelete = GetTagById(id);
        _context.Tags.Remove(tagToDelete);
        _context.SaveChanges();
        return tagToDelete;
    }
}