using Microsoft.AspNetCore.Http.HttpResults;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.Core.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    
    public PostService(IPostRepository postRepository,  IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }
    
    public IEnumerable<Post> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public Post Create(Post post)
    {
        User user = _userRepository.Get(post.User.ID);
        if (user == null)
        {
            throw new InvalidOperationException($"User with ID {post.User.ID} not found");
        }
        return _postRepository.Create(post);
    }
}