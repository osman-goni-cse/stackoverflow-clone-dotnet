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
    private readonly IFileStorageService _fileStorageService;
    
    public PostService(IFileStorageService fileStorageService, IPostRepository postRepository,  
        IUserRepository userRepository, ITagRepository tagRepository)
    {
        _fileStorageService = fileStorageService;
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

    public async Task<Post?> GetAsync(int id)
    {
        return await _postRepository.GetAsync(id);
    }

    public async Task<Post> Create(CreatePostRequestDto PostRequestDto)
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

        if (PostRequestDto.Files != null && PostRequestDto.Files.Any())
        {
            foreach (var file in PostRequestDto.Files)
            {
                PostFile postFile = await _fileStorageService.SaveFileAsync(file, post.Id);
                post.Files.Add(postFile);
            }
        }
        
        return await _postRepository.Create(post);
    }
}