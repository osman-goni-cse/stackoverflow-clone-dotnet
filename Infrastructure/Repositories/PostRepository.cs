using Microsoft.EntityFrameworkCore;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Infrastructure.Data;

namespace stack_overflow.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Post Get(int id)
    {
        return _context.Posts
            .Include(p => p.User)
            .Include(p => p.Tags)
            .Include(p => p.Answers)
            .ThenInclude(a => a.User)
            .FirstOrDefault(p => p.Id == id);
    }
    public Post Create(Post post)
    {
        // _context.Entry(post.User).State = EntityState.Unchanged;
        Post createdPost = _context.Posts.Add(post).Entity;
        _context.SaveChanges();
        return createdPost;
    }

    public IEnumerable<Post> GetAllPosts()
    {
        return _context.Posts;
    }
}