using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.Core.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITagRepository _tagRepository;
    
    public PostService(IPostRepository postRepository,  IUserRepository userRepository, ITagRepository tagRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _tagRepository = tagRepository;
    }
    
    public IEnumerable<Post> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public Post Get(int id)
    {
        return _postRepository.Get(id);
    }

    public Post Create(CreatePostRequestDto PostRequestDto)
    {
        // User user = _userRepository.Get(post.User.ID);
        // if (user == null)
        // {
        //     throw new InvalidOperationException($"User with ID {post.User.ID} not found");
        // }
        List<Tag> tags = _tagRepository.GetAllTags()
            .Where(tag => PostRequestDto.TagIds.Contains(tag.ID)).ToList();
        
        User user = _userRepository.Get(PostRequestDto.UserId);

        var post = new Post
        {
            Title = PostRequestDto.Title,
            Content = PostRequestDto.Content,
            User = user,
            Tags = tags
        };
        
        return _postRepository.Create(post);
    }
}