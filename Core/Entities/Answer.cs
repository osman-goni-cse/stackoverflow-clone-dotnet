using System.Text.Json.Serialization;

namespace stack_overflow.Core.Entities;

public class Answer
{
    public int Id { get; set; }
    public string Body { get; set; }
    
    /*
     cascading behavior to work, otherwise it will form cycle,
     User can have List of Posts and Post can have List of Answers
     what will be the cascading behavior if User deleted,
     SQL SERVER will throw exception if we don't make one of the relationships nullable
    */
    public int? PostId { get; set; } 
    [JsonIgnore]
    public Post Post { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}