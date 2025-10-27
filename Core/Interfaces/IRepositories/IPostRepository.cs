using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces;

public interface IPostRepository
{
    public Task<Post> Create(Post post);
    public Post Get(int id);
    public Task<Post> GetAsync(int id);
    public IEnumerable<Post> GetAllPosts();
}