using Microsoft.EntityFrameworkCore;
using stack_overflow.Core.Entities;

namespace stack_overflow.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Tag> Tags {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Post> Posts {get; set;}
}