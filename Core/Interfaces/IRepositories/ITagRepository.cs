using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces;

public interface ITagRepository
{
    Tag Create(Tag tag);
}