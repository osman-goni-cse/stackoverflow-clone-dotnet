using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces.IServices;

public interface ITagService
{
    Tag Create(Tag tag);
    List<Tag> GetAllTags();
    Tag? GetTagById(int id);
    Tag Update(Tag tag);
    Tag Delete(int id);
}