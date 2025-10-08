using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces.IServices;

public interface IPostService
{
    public IEnumerable<Post> GetAllPosts();
    public Post Create(Post post);
}