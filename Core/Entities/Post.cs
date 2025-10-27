using System.Text.Json.Serialization;

namespace stack_overflow.Core.Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    
    public User User { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();
    
    //[JsonIgnore]
    public List<Answer> Answers { get; set; } = new List<Answer>();

    public List<PostFile> Files { get; set; } = new();
}