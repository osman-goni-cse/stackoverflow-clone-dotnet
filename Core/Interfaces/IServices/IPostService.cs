using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces.IServices;

public interface IPostService
{
    public IEnumerable<Post> GetAllPosts();
    public Post Get(int id);
    public Task<Post> GetAsync(int id);
    public Task<Post> Create(CreatePostRequestDto PostRequestDto);
}